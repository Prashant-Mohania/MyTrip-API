CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_Productlist`()
BEGIN
              SELECT
              `pk_product_id`,
              `ItemCode`,
              `ItemName`,
              `FrgnName`,
              COALESCE(NULLIF(format(`OnHand` ,2),''), 'NA') AS 'OnHand',
			  COALESCE(NULLIF(format(`Available` ,2),''), 'NA') AS 'Available',
              COALESCE(NULLIF(format(`MRP` ,2),''), 'NA') AS 'MRP',			  
              CASE WHEN `F_1` = 0 OR `F_1` = '' THEN 0 ELSE `F_1` END AS 'F_1',
              CASE WHEN `F_2` = 0 OR `F_2` = '' THEN 0 ELSE `F_2` END AS 'F_2',
              `F_3`,
              `F_4`, 
              `F_5`,`prod_images` 
              FROM `productlist`;
	END