CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_itemList`(
_orderId varchar(50))
BEGIN
    select 
                  `zl_product_id` as itemCode,
				   COALESCE(`zeeorder_details`.`offer_qty` + `zeeorder_details`.`zl_count`, `zeeorder_details`.`zl_count`) AS qty,
                  `zl_mrp` as unitPrice
                  from `zeeorder_track` as ordDetails
                  inner join  `zeeuser_login` on `fk_userID` = `userId` 
                  inner join `zeeorder_details`  on  `zl_orderID` = `zl_order_ID` 
                 where `zl_orderID`=_orderId;
End