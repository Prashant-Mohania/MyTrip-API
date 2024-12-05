CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_PopupImageList`()
BEGIN
             

   SELECT p.id as 'id',
   p.imageName as 'imageName',
   p.image as 'image',
   pl.ItemName as 'ProductName',
    (case p.status when 1 then 'Active' when '2' then 'Deactive' end) as 'Status'
  from popupimage as p 
   inner join `productlist` as pl on p.productId=pl.pk_product_id where p.status=1 or p.status =2;

	END