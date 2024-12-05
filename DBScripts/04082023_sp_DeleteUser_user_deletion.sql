CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteUser`(_userid varchar(20))
BEGIN
               if  exists(select `userId` from `zeeuser_login` where `userId`=_userid 
               and `status`=1) then
                 UPDATE  `zeeuser_login` set `status`=2
                 WHERE  `status`=1 AND `userId`=_userid;
                 select 'Y' as 'id','User Removed' as 'desc';
                 else
                 SELECT 'N' AS 'id','User is not found' AS 'desc';
                end if;

	END