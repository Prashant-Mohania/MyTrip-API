CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_OrderList`(_userid varchar(20))
BEGIN
    IF EXISTS (SELECT `fk_userID` FROM zeelab.zeeorder_track WHERE `fk_userID` = _userid) THEN 
        SELECT 
            'Y' AS 'id',
            'List Found' AS 'Result',
            ze.zl_orderID AS 'OrderID',
            ze.zl_orderDate AS 'DateOrder',
            ze.SAPOrderStatusId AS 'StatusId',
            (CASE WHEN ze.SAPOrderStatusId IN (1, 2, 3, 4) THEN s.name ELSE 'Pending' END) AS 'Status',
            ze.zl_orderShipID AS 'OrderShipID',
            ze.zl_billDate AS 'BillDate',
            ze.zl_shipDate AS 'ShipDate',
            COALESCE(NULLIF(zl.storeCode, ''), 'NA') AS 'StoreCode',
            COALESCE(NULLIF(zl.storeName, ''), 'NA') AS 'StoreName', 
            (zd.`zl_totalAmnt` + zd.`gst`) AS 'TotalAmount',
            (
                SELECT COUNT(*)
                FROM zeeorder_details AS zd
                WHERE zd.zl_order_ID = ze.zl_orderID
            ) AS 'Totality'
        FROM 
            zeelab.zeeorder_track AS ze 
            LEFT JOIN zeelab.saporderstatuses AS s ON ze.SAPOrderStatusId = s.id
            LEFT JOIN zeelab.zeeuser_login AS zl ON ze.fk_userID = zl.userId
            LEFT JOIN zeelab.zeeorder_details AS zd ON zd.zl_order_ID = ze.zl_orderID
        WHERE 
            ze.fk_userID = _userid;
    ELSE
        SELECT 'N' AS 'id', 'List Not Found' AS 'Result';
    END IF;
END