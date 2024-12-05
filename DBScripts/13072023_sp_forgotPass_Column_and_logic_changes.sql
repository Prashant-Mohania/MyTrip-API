CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_forgotPass`(_userEmail varchar(120),_password varchar(50))
BEGIN
              if exists(select `email` from `zeeuser_login` where `email`=_userEmail) then
                update `zeeuser_login` set `codedPass`=md5(_password),`passPlain`=_password where `email`=_userEmail;
                select 'Y' as 'id','Password Send' as 'desc';
                else
                 SELECT 'N' AS 'id','User Not Exits' AS 'desc';
                end if;
	END