CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_changePass`(_userid varchar(50),_currentpass varchar(50),_newpass varchar(50))
BEGIN
              if exists(select `email` from `zeeuser_login` where (`email`=_userid or `mobile`=_userid) and `codedPass`=md5(_currentpass)) then
                update `zeeuser_login` set `codedPass`=md5(_newpass),`passPlain`=_newpass where (`email`=_userid OR `mobile`=_userid) AND `codedPass`=MD5(_currentpass);
                select 'Y' as 'id', 'Password Changed Successfully' as 'desc';
              else
                SELECT 'N' AS 'id', 'User Not Exists' AS 'desc';
              end if;
	END