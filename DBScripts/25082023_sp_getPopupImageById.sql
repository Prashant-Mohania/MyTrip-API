CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_getPopupImageById`(_popupImageId varchar(50))
BEGIN
             if exists(select `id` from `popupimage` where `id`=_popupImageId and `status`=1)  then
                 select `id` as 'Id','Success' as 'Result',
				`imageName` as 'ImageName',
                `image` as 'ImageUrl',
                `productId` as 'Product',
                `status` as 'Status'
                 from `popupimage`where `id`=_popupImageId and `status`=1 ;
				 else
                 SELECT 'N' AS 'Id','Image is not active' AS 'Result';
                 end if;
             
	END