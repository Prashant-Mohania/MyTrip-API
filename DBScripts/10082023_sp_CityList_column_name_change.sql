CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_CityList`()
BEGIN
              SELECT `id`,`name` FROM `city`;
             
	END