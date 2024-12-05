CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CreatePopupImage`(
_imageName varchar(50),
_image varchar(200),_productId varchar(300))
BEGIN	
				
              	if not exists(select `status` from `popupimage` where  `status`=1) then
                 insert into `popupimage`(`imageName`,`image`,`productId`,`status`,createdBy,createdDate)
                  values(_imageName,_image,_productId,1,'Admin',now());
                 select 'Y' as 'id','Image Added' as 'desc';
                              else
                 SELECT 'N' AS 'id','Sequence Already Exists! Please select other sequence' AS 'desc';
                 end if;
                
	END