CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteBanner`(_bannerid varchar(20))
BEGIN
               if  exists(select `id` from `banner` where `id`=_bannerid 
               and `status`=1) then
				DELETE FROM `banner` WHERE  `status`=1 AND `id`=_bannerid ;
                
                 select 'Y' as 'id','Banner Removed' as 'desc';
                 else
                 SELECT 'N' AS 'id','Banner is not found' AS 'desc';
                end if;

	END