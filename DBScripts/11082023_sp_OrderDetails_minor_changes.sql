CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_OrderDetails`()
BEGIN
      
                select 'Y' as 'id','List Found' as 'Result',
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
                from `zeeorder_track`  as d
                inner join `zeeuser_login` as l on  d.fk_userID=l.userId
                left outer join `sapordersstatuses` as s on d.SAPOrderStatusId= s.id;
              
	END