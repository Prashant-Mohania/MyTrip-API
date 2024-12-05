CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_zlOrderList`(_orderId varchar(50))
BEGIN
              if exists(select `fk_userID` from `zeeorder_details` where `zl_order_ID`=_UserList) then 
                  select `pk_orderDet_id` as ordid,`fk_userID` as uid,`zl_order_ID` as orderID,`zl_productName` as ProductName,`zl_count` as Counts,
                  `zl_mrp` as mrp,(CASE `zl_status` WHEN 'P' THEN 'Accept' WHEN 'R' THEN 'Cancel' WHEN 'N' THEN 'Remove' ELSE 'ETC' END) as 'Status',`zl_indate` as 'Date',
                  `zl_totalAmnt` as 'Tamount' from `zeeorder_details` where `zl_order_ID`=_orderId;
                  end if;
	END