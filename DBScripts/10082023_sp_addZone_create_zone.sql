CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_addZone`(
_zoneName varchar(50))
BEGIN	
				
              
                 insert into `zone`(`name`,`status`,createdBy,createdDate)
                  values(_zoneName,1,'Admin',now());
                 select 'Success' as 'id','Zone Added' as 'desc';
               
	END