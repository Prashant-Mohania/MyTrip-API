CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetOrderDetailsById`(_orderId varchar(50))
BEGIN
      if exists(select `zl_orderID` from `zeeorder_track` where `zl_orderID`=_orderId ) then
            
						select 'Y' as 'id','List Found' as 'Result',
						ze.pk_order_id as 'order_Id',
                        COALESCE(NULLIF( ze.zl_orderShipID,''), 'NA') AS 'SaleQuotation',
						ze.zl_orderID as 'OrderID',
						COALESCE(NULLIF(zl.storeCode,''), 'NA') AS 'StoreCode',
						COALESCE(NULLIF(zl.storeName,''), 'NA') AS 'StoreName',  
						ze.SAPOrderStatusId as  'StatusId',
						(case when ze.SAPOrderStatusId in (1,2,3,4) then s.name
										else 'Pending' end) as 'Status',
						COALESCE(NULLIF(format(ze.zl_totaloforder ,2),''), 'NA') AS 'TotalAmount'
						
						from zeelab.zeeorder_track AS ze 
						inner join  zeelab.zeeuser_login as zl on zl.userId=ze.fk_userID
						left  join zeelab.saporderstatuses as s on ze.SAPOrderStatusId= s.id
                        where ze.zl_orderID=_orderId 
                        order by ze.pk_order_id desc;
					
                    
                 end if;
           
	END