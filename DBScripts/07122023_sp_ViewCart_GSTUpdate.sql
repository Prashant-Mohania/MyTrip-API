CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_ViewCart`(_userid varchar(20))
BEGIN
    -- Check if there are items in the cart for the specified user
    IF EXISTS (SELECT `fk_userID` FROM `zeeorder_details` WHERE `zl_status`='C' AND `fk_userID`=_userid) THEN 
        SELECT  Distinct
            zd.`zl_product_id` AS 'ProductId',
            'Cart View' AS 'Result',          
            zd.`zl_productName` AS 'ProductName',
            zd.`zl_count` AS 'Quantity',
            zd.`zl_mrp` AS 'MRP',
            zd.`zl_totalAmnt` AS 'TotalAmount',
            CASE WHEN pl.`F_1` = 0 OR `F_1` = '' THEN 0 ELSE (zd.`zl_totalAmnt` * (pl.`F_1` / 100)) END AS 'GST',
            CASE WHEN pl.`F_2` = 0 OR `F_2` = '' THEN 0 ELSE pl.`F_2` END AS 'PTR',       
            zd.`zl_indate` AS 'Adddate',
            -- Include Offer Information
            CASE WHEN current_date() BETWEEN date(offer.`FromDate`) AND date(offer.`ToDate`)
                      AND zd.`zl_count` >= offer.`eligibilityQty`
                      AND EXISTS (SELECT 1 FROM `offerproduct` op WHERE op.`offer_id` = offer.`id` AND op.`product_id` = pl.`pk_product_id`)
                 THEN 
                     JSON_OBJECT('offerid', offer.`id`, 'offername', offer.`name`, 'offeredproducts', offer.`offerQty`)
                 ELSE NULL
            END AS 'Offer_Details'
        FROM `zeeorder_details` zd
        JOIN `productlist` pl ON zd.`zl_product_id` = pl.`ItemCode`  
        LEFT JOIN `offerproduct` op ON op.`product_id` = pl.`pk_product_id`
        LEFT JOIN `offer` offer ON op.`offer_id` = offer.`id`
        WHERE zd.`zl_status`='C' AND zd.`fk_userID`=_userid;
    ELSE
        SELECT 'N' AS 'id', 'Cart Empty' AS 'Result';
    END IF;
END