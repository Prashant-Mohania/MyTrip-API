CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_ViewCart`(_userid varchar(20))
BEGIN
    -- Check if there are items in the cart for the specified user
    IF EXISTS (SELECT `fk_userID` FROM `zeeorder_details` WHERE `zl_status`='C' AND `fk_userID`=_userid) THEN 
        SELECT
            zd.`zl_product_id` AS 'ProductId',
            'Cart View' AS 'Result',
            zd.`zl_productName` AS 'ProductName',
            zd.`zl_count` AS 'Quantity',
            zd.`zl_mrp` AS 'MRP',
            zd.`zl_totalAmnt` AS 'TotalAmount',
            CASE WHEN pl.`F_1` = 0 OR `F_1` = '' THEN 0 ELSE (zd.`zl_totalAmnt` * (pl.`F_1` / 100)) END AS 'GST',
            CASE WHEN pl.`F_2` = 0 OR `F_2` = '' THEN 0 ELSE pl.`F_2` END AS 'PTR',       
            zd.`zl_indate` AS 'Adddate',
            CheckOfferValid(pl.`ItemCode`, zd.`zl_count`) AS 'Offer_Details'
        FROM `zeeorder_details` zd
        JOIN `productlist` pl ON zd.`zl_product_id` = pl.`ItemCode`  
        LEFT JOIN `offerproduct` op ON op.`product_id` = pl.`pk_product_id`
        LEFT JOIN `offer` offer ON op.`offer_id` = offer.`id`
        WHERE zd.`zl_status`='C' AND zd.`fk_userID`=_userid
        GROUP BY zd.`zl_product_id`, zd.`zl_productName`, zd.`zl_count`, zd.`zl_mrp`, zd.`zl_totalAmnt`, pl.`F_1`, pl.`F_2`, zd.`zl_indate`;
    ELSE
        SELECT 'N' AS 'id', 'Cart Empty' AS 'Result';
    END IF;
END