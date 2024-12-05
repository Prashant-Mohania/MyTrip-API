CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_UserOrderDetails`(_orderId varchar(30))
BEGIN

		   select `zl_orderID` as orderID,       
                  Date(`zl_orderDate`) as OrderDate, 
                  `firstName` as CustomerDetail,
                   `email` as customeremailid,
                   `mobile` as MobileNo,
                   `address` as Address,
                   `cityName` as City,
                   `name` as State,
                   `pincode` as ZipCode,
                  `zl_product_id` as itemCode,
                  `zl_count` as qty,
                  `zl_mrp` as unitPrice
                  from `zeeorder_track` as ordDetails
                  inner join  `zeeuser_login` on `fk_userID` = `userId` 
                  inner join `zeeorder_details`  on  `zl_orderID` = `zl_order_ID` 
                  inner join `state`  on `stateId` = `id` 
                  inner join `city` on `cityId` = `cId` 
                  where `zl_orderID`=_orderId;
                  
                  
         
                  
                  
         
END