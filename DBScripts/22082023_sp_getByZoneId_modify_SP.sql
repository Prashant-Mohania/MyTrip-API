CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_getByZoneId`(_zoneId varchar(50))
BEGIN
           declare selectedState varchar(30);  
           
                 select z.id as 'Id','Success' as 'Result',
				z.name as 'ZoneName',group_concat(zs.stateId) as 'SelectedStates'
                 from `zone` as z 
                 left outer join `zonestatemapping` as zs on z.id=zs.zoneid
                 where (z.id=_zoneId ) 
               GROUP BY z.id, z.name;
    
				
                
	END