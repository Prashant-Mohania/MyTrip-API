CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_UserOrderDetails`(_orderId varchar(30))
BEGIN

		   select `zl_orderID` as orderID,       
                  Date(`zl_orderDate`) as OrderDate, 
                  `firstName` as CustomerDetail,
                   `email` as customeremailid,
                   `mobile` as MobileNo,
                   `address` as Address,
                   c.name as City,
                   s.name as State,
                   `pincode` as ZipCode,
                  `zl_product_id` as itemCode,
                  `zl_count` as qty,
                  `zl_mrp` as unitPrice
                  from `zeeorder_track` as ordDetails
                  inner join  `zeeuser_login` on `fk_userID` = `userId` 
                  inner join `zeeorder_details`  on  `zl_orderID` = `zl_order_ID` 
                  inner join `state` as s  on `stateId` = s.id 
                  inner join `city` as c on `cityId` = c.id 
                  where `zl_orderID`=_orderId;
                  
                  
         
                  
                  
         
END