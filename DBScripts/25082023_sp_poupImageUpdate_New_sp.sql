CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_poupImageUpdate`(
_popupImageId varchar(10),
_imageName varchar(50),
_image varchar(200),
_productId varchar(300),
_status varchar(10))
BEGIN
              if exists(select `id` from `popupimage` where `status`='1'  and `id`=_popupImageId) then
					                    
					update `popupimage` 
					set `imageName`=_imageName,
                    `image`=_image,
                    `productId`=_productId,
                    `status`=_status,
                    updatedBy='Admin',updatedDate=now()
				  where `status`='1' AND `id`=_popupImageId;
                  
               
                  
                 select 'Y' as 'id','Details Updated' as 'desc';
                 else
                 SELECT 'N' AS 'id','Image Not Found' AS 'desc';
                 end if;
              
	END