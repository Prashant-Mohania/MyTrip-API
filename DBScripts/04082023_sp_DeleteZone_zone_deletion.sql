CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteZone`(_zoneId varchar(20))
BEGIN
               if  exists(select `id` from `zone` where `id`=_zoneId 
               and `status`=1) then
                 UPDATE  `zone` set `status`=2
                 WHERE  `status`=1 AND `id`=_zoneId;
                 select 'Y' as 'id','Zone Removed' as 'desc';
                 else
                 SELECT 'N' AS 'id','Zone is not found' AS 'desc';
                end if;

	END