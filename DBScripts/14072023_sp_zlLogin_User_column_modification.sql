CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_zlLogin_User`(_userid varchar(50),_password varchar(150))
BEGIN
              if exists(select `email` from `zeeuser_login` where (`email`=_userid or `mobile`=_userid) 
			  and `codedPass`=md5(_password) limit 1) then
                 select 'Y' as 'id','Success' as 'Result',
				 `userId` as 'userId',
				 `userName` as 'UserName',`storeName` as 'StoreName',
                 `mobile` as 'Mobile',`email` as 'Email',
				 `codedPass` as 'Passes',`address` as 'Address',`storeCode` as 'StoreCode',`storeName` as 'StoreName',
				 `pincode` as 'Pincode',`cityId` as 'City',
                 `stateId` as 'State',`userTypeId` as 'UserType',`zoneId` as 'Zone',
				 (case `status` when '1' then 'Active' when '2' then 'Deactive' else 'ETC' end) as 'Status'
				 ,`passPlain` as 'Pass',`firstName` as 'FirstName',`lastName` as 'LastName'
                 from `zeeuser_login` where (`email`=_userid OR `mobile`=_userid) 
				 AND `codedPass`=MD5(_password) LIMIT 1;
                 else
                 select 'N' as 'id','Invalid Credentials. Please check your credentials again.' AS 'Result';
                 end if;
	END