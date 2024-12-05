CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CityList`(_stateId int)
BEGIN
              SELECT `id`,`name` FROM `city` where `stateId`=_stateId;
	END