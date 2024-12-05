CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_ZoneList`()
BEGIN
              SELECT `id`,`name` FROM `zone` where `status`=1;
	END