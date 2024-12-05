CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_zlLogin_User`(_userid varchar(50),_password varchar(150),_usertype varchar(10))
BEGIN
		declare usertype varchar(10);		
              if exists(select `email`,`userTypeId` from `zeeuser_login` where ((`email`=_userid or `mobile`=_userid) and _usertype='web' and `userTypeId`= 2 ) 
			  and `codedPass`=md5(_password) limit 1) then
					
						select 'Y' as 'id','Success' as 'Result',
							`userId` as 'userId',
							`userName` as 'UserName',`storeName` as 'StoreName',
							`mobile` as 'Mobile',`email` as 'Email',
							`address` as 'Address',`storeCode` as 'StoreCode',`storeName` as 'StoreName',
							`pincode` as 'Pincode',`cityId` as 'City',
							`stateId` as 'State',`userTypeId` as 'UserType',`zoneId` as 'Zone',
								(case `status` when '1' then 'Active' when '2' then 'Deactive' else 'ETC' end) as 'Status'
								,`passPlain` as 'Pass',`firstName` as 'FirstName',`lastName` as 'LastName'
								from `zeeuser_login` where (`email`=_userid OR `mobile`=_userid) 
									AND `codedPass`=MD5(_password) LIMIT 1;
                                    	select 'Y' as 'id','Login successfully' AS 'Result';
             else  if exists(select `email`,`userTypeId` from `zeeuser_login` where ((`email`=_userid or `mobile`=_userid) 
             and _usertype='mobile' and `userTypeId`= 1 ) 
			  and `codedPass`=md5(_password) limit 1) then
					
						select 'Y' as 'id','You are not allowed to login' AS 'Result';
				
			else
                 select 'N' as 'id','Invalid Credentials. Please check your credentials again.' AS 'Result';
                 end if;
                end if;
	END