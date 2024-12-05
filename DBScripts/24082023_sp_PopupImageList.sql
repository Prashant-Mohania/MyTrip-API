CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_PopupImageList`()
BEGIN
             

   SELECT id,imageName,image,productId,status from popupimage where status=1 or status =2;

	END