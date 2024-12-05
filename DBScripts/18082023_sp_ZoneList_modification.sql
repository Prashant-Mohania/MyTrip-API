CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_ZoneList`(_listData varchar(10))
BEGIN
	if(_listData = 'CreateUser' or _listData = 'EditUser') then
				select distinct z.id as 'id',
				z.name as 'name'
				from zeelab.zone as z
				inner join zeelab.zonestatemapping as zs on zs.zoneId=z.id
				where z.status=1;
		else
        select `id`,`name` from `zone` where `status`=1;
                end if;
	END