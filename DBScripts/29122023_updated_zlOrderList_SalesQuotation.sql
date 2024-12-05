CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_zlOrderList`(_orderId varchar(50))
BEGIN
    IF EXISTS(SELECT `fk_userID` FROM `zeeorder_details` WHERE `zl_order_ID` = _orderId) THEN 
        SELECT 'Y' AS 'id', 'List Found' AS 'Result',
               `zd`.`pk_orderDet_id` AS ordid, `zd`.`fk_userID` AS uid, `zd`.`zl_order_ID` AS orderID,
               `zd`.`zl_productName` AS ProductName, `zd`.`zl_count` AS Counts, `zd`.`zl_mrp` AS mrp,
               (CASE `zd`.`zl_status` WHEN 'P' THEN 'Accept' WHEN 'R' THEN 'Cancel' WHEN 'N' THEN 'Remove' ELSE 'ETC' END) AS 'Status',
               `zd`.`zl_indate` AS 'Date', `zd`.`zl_totalAmnt` AS 'Tamount', `zd`.`ptr` AS ptr, `zd`.`gst` AS gst,
               `zd`.`offer_qty` AS offer_qty, zt.zl_orderShipID AS 'SaleQuotation'
        FROM `zeeorder_details` AS `zd`
        LEFT JOIN `zeelab`.`zeeorder_track` AS `zt` ON `zd`.`zl_order_ID` = `zt`.`zl_orderID`
        WHERE `zd`.`zl_order_ID` = _orderId;
    ELSE
        SELECT 'N' AS 'id', 'List Not Found' AS 'Result';
    END IF;
END