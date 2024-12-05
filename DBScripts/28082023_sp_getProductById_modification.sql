CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_getProductById`(_productId varchar(50))
BEGIN
             
                 select `pk_product_id` as 'Id','Success' as 'Result',
                 `pk_product_id` as 'ProductId',
                 `ItemCode` as  'ItemCode',
				`ItemName` as 'ItemName',
                `FrgnName` as 'FrgnName',
                `OnHand` as 'OnHand',
                `Available` as 'Available',
                `MRP` as 'MRP',
                `F_1` as 'F_1',
				`F_2` as 'F_2',
				`F_3` as 'F_3',
				`F_4` as 'F_4',
				`F_5` as 'F_5',
                `prod_images` as 'ImageUrl'
                 from `productlist` where `pk_product_id`=_productId ;
				
             
	END