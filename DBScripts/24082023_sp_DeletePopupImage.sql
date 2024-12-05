CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeletePopupImage`(_popupImageId varchar(20))
BEGIN
               if  exists(select `id` from `popupimage` where `id`=_popupImageId 
               and `status`=1) then
                 UPDATE  `popupimage` set 
                  `status`=2
                 WHERE  `status`=1 AND `id`=_popupImageId ;
                 select 'Y' as 'id','Popup image Removed' as 'desc';
                 else
                 SELECT 'N' AS 'id','Popup image is not found' AS 'desc';
                end if;

	END