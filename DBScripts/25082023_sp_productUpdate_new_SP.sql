CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_productUpdate`(
_productId varchar(300),
_itemCode varchar(300),
_itemName varchar(300),
_frgnName varchar(300),
_onHand varchar(300),
_available varchar(300),
_mrp varchar(300),
_prodImages varchar(500))
BEGIN
              if exists(select `pk_product_id` from `productlist` where  `pk_product_id`=_productId) then
					                    
					update `productlist` 
					set `ItemCode`=_itemCode,
                    `ItemName`=_itemName,
                    `FrgnName`=_frgnName,
                    `OnHand`=_onHand,
                    `Available`=_available,
                    `MRP`=_mrp,
                    `prod_images`=_prodImages
				  where  `pk_product_id`=_productId;
                  
               
                  
                 select 'Y' as 'id','Product Updated' as 'desc';
               
                 end if;
              
	END