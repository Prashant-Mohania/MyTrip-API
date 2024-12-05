CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_getByZoneId`(_zoneId varchar(50))
BEGIN
             
                 select `id` as 'Id','Success' as 'Result',
				`name` as 'ZoneName'
                 from `zone` where (`id`=_zoneId ) ;
				
                
	END