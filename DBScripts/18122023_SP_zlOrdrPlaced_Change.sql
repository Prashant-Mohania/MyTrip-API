CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_zlOrderPlace`(_userid varchar(20))
BEGIN

DECLARE _mrp DECIMAL(30,6) DEFAULT 0;
DECLARE _orderID,_productname,_productID,_count VARCHAR(200);
	
SELECT ZEEORDERID(_userid) INTO _orderID;			
		
IF EXISTS(SELECT `fk_userID` FROM `zeeorder_details` WHERE `zl_status`='C' AND `fk_userID`=_userid) THEN
	SELECT SUM(`zl_totalAmnt`) INTO _mrp FROM `zeeorder_details` WHERE `zl_status`='C' AND `fk_userID`=_userid;
   UPDATE `productlist` AS t1
JOIN (
    SELECT `zl_product_id`, `zl_count`,`fk_userID`,`zl_status`
    FROM `zeeorder_details`
    WHERE `zl_product_id` IN (`zl_product_id`)
) AS t2 ON  t1.`ItemCode` =t2.`zl_product_id`
SET t1.`OnHand` = t1.`OnHand` - t2.`zl_count`
where t2.`fk_userID`=_userid and t2.`zl_status` = 'C';	

UPDATE `zeeorder_details` AS zd
JOIN `productlist` AS pl ON zd.`zl_product_id` = pl.`ItemCode`
LEFT JOIN `offer` ON current_date() BETWEEN date(offer.`FromDate`) AND date(offer.`ToDate`)
                  AND zd.`zl_count` >= offer.`eligibilityQty`
                  AND EXISTS (SELECT 1 FROM `offerproduct` op WHERE op.`offer_id` = offer.`id` AND op.`product_id` = pl.`pk_product_id`)
SET zd.`gst` = CASE WHEN pl.`F_1` = 0 OR pl.`F_1` = '' THEN 0 ELSE (zd.`zl_totalAmnt` * (pl.`F_1` / 100)) END,
    zd.`offer_qty` = FLOOR(offer.`offerQty` * FLOOR(zd.`zl_count` / offer.`eligibilityQty`)),
    zd.`zl_status` = 'P',
    zd.`zl_order_ID` = CASE WHEN zd.`zl_status` = 'C' THEN _orderID ELSE zd.`zl_order_ID` END
WHERE zd.`fk_userID` = _userid AND zd.`zl_status` IN ('C', 'P');

INSERT INTO `zeeorder_track`(`fk_userID`, `zl_orderID`, `zl_orderDate`, `zl_comment`, `zl_totaloforder`, `SAPOrderStatusId`)
VALUES (_userid, _orderID, NOW(), 'Placed', _mrp, '1')
ON DUPLICATE KEY UPDATE `zl_orderID` = _orderID, `zl_orderDate` = NOW(), `zl_comment` = 'Placed', `zl_totaloforder` = _mrp, `SAPOrderStatusId` = '1';

				
	SELECT 'Y' AS 'id', 'Order Placed Successfully!' AS 'Result';
					
	
					
ELSE
	SELECT 'N' AS 'id','Product not found in cart' AS 'Result';
END IF;
end