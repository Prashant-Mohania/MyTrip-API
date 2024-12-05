CREATE DEFINER=`zeelab`@`%` PROCEDURE `sp_zoneUpdate`(
_zoneId varchar(10),
_zoneName varchar(50),
_stateId varchar(50))
BEGIN
 if exists(select `stateId` from `zonestatemapping` where `status`='1'  and `zoneId`=_zoneId) then
					delete from zonestatemapping where  `status`='1' and `zoneId`=_zoneId ;
                    
					update `zone` 
					set `name`=_zoneName,updatedBy='Admin',updatedDate=now()
				  where `status`='1' AND `zoneId`=_zoneId;
                  
                  Insert into zonestatemapping (`stateId`,`zoneId`,`status`,`createdBy`,`createdDate`) 
                  values (_stateId,_zoneId,1,'Admin',now());
                  
                 select 'Y' as 'id','Details Updated' as 'desc';
                 else
                 SELECT 'N' AS 'id','Zone Not Found' AS 'desc';
                 end if;
END
END