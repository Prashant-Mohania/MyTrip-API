CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_OrderList`(_userid varchar(20))
BEGIN
              if exists(select `fk_userID` from zeelab.zeeorder_track where `fk_userID` =_userid) then 
                select 'Y' as 'id','List Found' as 'Result',
				ze.zl_orderID as 'OrderID',
				ze.zl_orderDate as 'DateOrder',
                (case when ze.SAPOrderStatusId in (1,2,3,4) 
                then s.name else 'Pending' end) as 'Status',
                ze.zl_orderShipID as 'OrderShipID',
				ze.zl_billDate as 'BillDate',
				ze.zl_shipDate as 'ShipDate',
				ze.zl_totaloforder as 'TotalAmount' 
                from zeelab.zeeorder_track as ze 
				left  join zeelab.saporderstatuses as s on ze.SAPOrderStatusId= s.id
				where ze.fk_userID =_userid;
               else
                SELECT 'N' AS 'id','List Not Found' AS 'Result';
                end if;
	END