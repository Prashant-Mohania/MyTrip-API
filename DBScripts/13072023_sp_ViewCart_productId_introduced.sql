CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_ViewCart`(_userid varchar(20))
BEGIN
                if exists(select `fk_userID` from `zeeorder_details` where `zl_status`='C' and `fk_userID`=_userid) then 
                   select  `zl_product_id` AS 'ProductId','Cart View' AS 'Result',`zl_productName` as 'ProductName',`zl_count` as 'Quantity',`zl_mrp` as 'MRP',`zl_totalAmnt` as 'TotalAmount',
                   `zl_indate` as 'Adddate' from `zeeorder_details`
                   where `zl_status`='C' AND `fk_userID`=_userid;
                 else
                    select 'N' as 'id','Cart Empty' as 'Result';
                  end if;
	END