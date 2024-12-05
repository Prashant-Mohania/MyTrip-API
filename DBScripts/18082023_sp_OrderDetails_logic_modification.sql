CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_OrderDetails`(_userId varchar(30),_usertype varchar(30))
BEGIN
      if exists(select `userId` from `zeeuser_login` where `userId`=_userid and _usertype=1 or _usertype=2) then
             with zonelist as(
						select   zl.zoneId,zm.stateId 
						from  zeelab.zeeuser_login as zl
						left JOIN zeelab.zonestatemapping AS zm ON zm.zoneId = zl.zoneId
						WHERE zl.zoneId IS NOT NULL AND zl.zoneId != 0 and zl.userId=_userId)
						select 'Y' as 'id','List Found' as 'Result',
						ze.pk_order_id as 'order_Id',
						ze.zl_orderID as 'OrderID',
						COALESCE(NULLIF(zl.storeCode,''), 'NA') AS 'StoreCode',
						COALESCE(NULLIF(zl.storeName,''), 'NA') AS 'StoreName',  
						ze.SAPOrderStatusId as  'StatusId',
						(case when ze.SAPOrderStatusId in (1,2,3,4) then s.name
										else 'Pending' end) as 'Status',
						COALESCE(NULLIF(format(ze.zl_totaloforder ,2),''), 'NA') AS 'TotalAmount',
						zli.stateId
						from zonelist as zli
						inner join  zeelab.zeeuser_login as zl on zl.stateId=zli.stateId
						left join zeelab.zeeorder_track AS ze on  ze.fk_userID = zl.userId
						left  join zeelab.sapordersstatuses as s on ze.SAPOrderStatusId= s.id;
	else
				select distinct 'Y' as 'id','List Found' as 'Result',
                d.pk_order_id as 'order_Id',
                d.zl_orderID as 'OrderID',
                COALESCE(NULLIF(l.storeCode,''), 'NA') AS 'StoreCode',
				COALESCE(NULLIF(l.storeName,''), 'NA') AS 'StoreName',  
                d.SAPOrderStatusId as 'StatusId',
                 (case d.zl_orderStatus 
                 when d.SAPOrderStatusId =1 then s.name
                 when d.SAPOrderStatusId =2 then s.name
                 when d.SAPOrderStatusId =3 then s.name
                 when d.SAPOrderStatusId =4 then s.name
                 else 'Pending' end) as 'Status',
                 COALESCE(NULLIF(format(d.zl_totaloforder ,2),''), 'NA') AS 'TotalAmount'
                from `zeelab`.`zeeorder_track`  as d
                inner join `zeelab`.`zeeuser_login` as l on  d.fk_userID=l.userId
                left outer join `zeelab`.`sapordersstatuses` as s on d.SAPOrderStatusId= s.id;
                 end if;
              
	END