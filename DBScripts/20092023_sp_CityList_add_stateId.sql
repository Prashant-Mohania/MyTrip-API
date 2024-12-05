CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CityList`(_stateId varchar(20))
BEGIN
              SELECT `id`,`name` FROM `city` where `stateId`=_stateId;
             
	END