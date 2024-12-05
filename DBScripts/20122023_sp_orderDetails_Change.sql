CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_OrderDetails`(_userId varchar(30),_usertype varchar(30))
BEGIN
      if exists(select `userId` from `zeeuser_login` where `userId`=_userid and (_usertype=1 or _usertype=2)) then
             with zonelist as(
						select   zl.zoneId,zm.stateId 
						from  zeelab.zeeuser_login as zl
						left JOIN zeelab.zonestatemapping AS zm ON zm.zoneId = zl.zoneId
						WHERE zl.zoneId IS NOT NULL AND zl.zoneId != 0 and zl.userId=_userId)
						select 'Y' as 'id','List Found' as 'Result',
						ze.pk_order_id as 'order_Id',
                        ze.zl_orderShipID as 'SaleQuotation',
						ze.zl_orderID as 'OrderID',
						COALESCE(NULLIF(zl.storeCode,''), 'NA') AS 'StoreCode',
						COALESCE(NULLIF(zl.storeName,''), 'NA') AS 'StoreName',  
						ze.SAPOrderStatusId as  'StatusId',
						(case when ze.SAPOrderStatusId in (1,2,3,4) then s.name
										else 'Pending' end) as 'Status',
						COALESCE(NULLIF(format(ze.zl_totaloforder ,2),''), 'NA') AS 'TotalAmount',
                           ze.zl_orderDate as 'OrderDate',
                         ze.zl_indate as 'OrderInDate',
						zli.stateId
						from zonelist as zli
						inner join  zeelab.zeeuser_login as zl on zl.stateId=zli.stateId
						inner join zeelab.zeeorder_track AS ze on  ze.fk_userID = zl.userId
						left  join zeelab.saporderstatuses as s on ze.SAPOrderStatusId= s.id
                        order by ze.pk_order_id desc;
	ELSE IF EXISTS (SELECT `userId` FROM `zeeuser_login` WHERE `userId` = _userid AND (_usertype = 4))
THEN
    WITH citylist AS (
        SELECT cm.city_id, cm.stateId
        FROM zeelab.zeeuser_login AS cl
		JOIN zeelab.regionalusercities AS cm ON cm.userId = cl.userId
        WHERE cl.userId = _userId
    )

    SELECT 'Y' AS 'id', 'List Found' AS 'Result',
        ze.pk_order_id AS 'order_Id',
        ze.zl_orderShipID AS 'SaleQuotation',
        ze.zl_orderID AS 'OrderID',
        COALESCE(NULLIF(cl.storeCode, ''), 'NA') AS 'StoreCode',
        COALESCE(NULLIF(cl.storeName, ''), 'NA') AS 'StoreName',
        ze.SAPOrderStatusId AS 'StatusId',
        (CASE WHEN ze.SAPOrderStatusId IN (1, 2, 3, 4) THEN s.name
            ELSE 'Pending' END) AS 'Status',
        COALESCE(NULLIF(FORMAT(ze.zl_totaloforder, 2), ''), 'NA') AS 'TotalAmount',
        ze.zl_orderDate AS 'OrderDate',
        ze.zl_indate AS 'OrderInDate',
        cli.stateId
    FROM citylist AS cli
    INNER JOIN zeelab.zeeuser_login AS cl ON cl.cityId = cli.city_id
    INNER JOIN zeelab.zeeorder_track AS ze ON ze.fk_userID = cl.userId
    LEFT JOIN zeelab.saporderstatuses AS s ON ze.SAPOrderStatusId = s.id
    ORDER BY ze.pk_order_id DESC;
	else
				select distinct 'Y' as 'id','List Found' as 'Result',
                d.pk_order_id as 'order_Id',
                d.zl_orderID as 'OrderID',
                 d.zl_orderShipID as 'SaleQuotation',
                COALESCE(NULLIF(l.storeCode,''), 'NA') AS 'StoreCode',
				COALESCE(NULLIF(l.storeName,''), 'NA') AS 'StoreName',  
                d.SAPOrderStatusId as 'StatusId',
                 (case d.zl_orderStatus 
                 when d.SAPOrderStatusId =1 then s.name
                 when d.SAPOrderStatusId =2 then s.name
                 when d.SAPOrderStatusId =3 then s.name
                 when d.SAPOrderStatusId =4 then s.name
                 else 'Pending' end) as 'Status',
                 COALESCE(NULLIF(format(d.zl_totaloforder ,2),''), 'NA') AS 'TotalAmount',
                 d.zl_orderDate as 'OrderDate',
                         d.zl_indate as 'OrderInDate'
                from `zeelab`.`zeeorder_track`  as d
                inner join `zeelab`.`zeeuser_login` as l on  d.fk_userID=l.userId
                left outer join `zeelab`.`saporderstatuses` as s on d.SAPOrderStatusId= s.id
                 order by d.pk_order_id desc;
                 end if;
                 end if;              
	END