CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_Statelist`()
BEGIN
              SELECT `id`,`name` FROM `state`  where `status`=1;
	END