CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_zlOrderPlace`(_userid VARCHAR(20))
BEGIN
    DECLARE _mrp DECIMAL(30, 6) DEFAULT 0;
    DECLARE _orderID, _productname, _productID, _count VARCHAR(200);

    SELECT ZEEORDERID(_userid) INTO _orderID;

    IF EXISTS (SELECT `fk_userID` FROM `zeeorder_details` WHERE `fk_userID` = _userid) THEN
 -- Update productlist OnHand
UPDATE `productlist` AS t1
JOIN (
    SELECT `zl_product_id`, `zl_count`, `fk_userID`, `zl_status`,`zl_product_ID_int`
    FROM `zeeorder_details`
    WHERE `zl_status` = 'C' AND `fk_userID` = _userid
) AS t2 ON t1.`pk_product_id` = t2.`zl_product_ID_int`
SET t1.`OnHand` = t1.`OnHand` - t2.`zl_count`
WHERE t2.`fk_userID` = _userid AND t2.`zl_status` = 'C';

-- Update zeeorder_details
UPDATE `zeeorder_details` AS zd
JOIN `productlist` AS pl ON zd.`zl_product_ID_int` = pl.`pk_product_id`
LEFT JOIN `offer` ON CURRENT_DATE() BETWEEN DATE(offer.`FromDate`) AND DATE(offer.`ToDate`)
                   AND zd.`zl_count` >= offer.`eligibilityQty`
                   AND EXISTS (SELECT 1 FROM `offerproduct` op WHERE op.`offer_id` = offer.`id` AND op.`product_id` = pl.`pk_product_id`)
SET zd.`gst` = CASE WHEN pl.`F_1` = 0 OR pl.`F_1` IS NULL THEN 0 ELSE (zd.`zl_totalAmnt` * (pl.`F_1` / 100)) END,
    zd.`offer_qty` = FLOOR(offer.`offerQty` * FLOOR(zd.`zl_count` / offer.`eligibilityQty`))
WHERE zd.`fk_userID` = _userid AND zd.`zl_status` = 'C' AND zd.`zl_product_ID_int` IS NOT NULL;

-- Update zeeorder_details status
UPDATE `zeeorder_details`
SET
    `zl_status` = 'P',
    `zl_order_ID` = _orderID
WHERE
    `fk_userID` = _userid AND `zl_status` = 'C' AND `zl_product_ID_int` IS NOT NULL;

        -- Insert into zeeorder_track
        INSERT INTO `zeeorder_track`(`fk_userID`, `zl_orderID`, `zl_orderDate`, `zl_comment`, `zl_totaloforder`, `SAPOrderStatusId`)
        VALUES (_userid, _orderID, NOW(), 'Placed', _mrp, '1');

        SELECT 'Y' AS 'id', 'Order Placed Successfully!' AS 'Result';

    ELSE
        SELECT 'N' AS 'id', 'Product not found in cart' AS 'Result';
    END IF;
END