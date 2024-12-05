CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_zlLogin_User`(_userid varchar(50),_password varchar(150),_usertype varchar(10))
BEGIN
		declare usertype varchar(10);		
              if exists(select `email`,`userTypeId` from `zeeuser_login` where ((`email`=_userid or `mobile`=_userid) 
              and _usertype='web' and `userTypeId`= 2 and  `status`=1 ) 
			  and `codedPass`=md5(_password) limit 1) then
					
						select 'Y' as 'id','Success' as 'Result',
							`userId` as 'userId',
							`userName` as 'UserName',`storeName` as 'StoreName',
							`mobile` as 'Mobile',`email` as 'Email',
							`address` as 'Address',`storeCode` as 'StoreCode',`storeName` as 'StoreName',
							`pincode` as 'Pincode',`cityId` as 'City',
							`stateId` as 'State',`userTypeId` as 'UserType',`zoneId` as 'Zone',
							(case `status` when '1' then 'Active' when '2' then 'Deactive' else 'ETC' end) 
							as 'Status',
							`passPlain` as 'Pass',`firstName` as 'FirstName',`lastName` as 'LastName'
								from `zeeuser_login` where (`email`=_userid OR `mobile`=_userid) 
									AND `codedPass`=MD5(_password) LIMIT 1;
                                    	select 'Y' as 'id','Login successfully' AS 'Result';
                                        
             else  if exists(select `email`,`userTypeId` from `zeeuser_login` 
             where ((`email`=_userid or `mobile`=_userid) 
             and  `userTypeId`= 1 and _usertype='mobile' and  `status`=1) 
			  and `codedPass`=md5(_password) limit 1) then
					
					select 'Y' as 'id','Success' as 'Result',
							zl.userId as 'userId',
							zl.userName as 'UserName',`storeName` as 'StoreName',
							zl.mobile as 'Mobile',zl.email as 'Email',
							zl.address as 'Address',zl.storeCode as 'StoreCode',zl.storeName as 'StoreName',
							zl.pincode as 'Pincode',
							zc.name as 'City',
							zs.name as 'State',
							zl.userTypeId as 'UserType',`zoneId` as 'Zone',
						(case zl.status when '1' then 'Active' when '2' then 'Deactive' else 'ETC' end) 
						as 'Status'	,
						zl.passPlain as 'Pass',zl.firstName as 'FirstName',zl.lastName as 'LastName'
								from zeelab.zeeuser_login as zl
								inner join zeelab.state as zs on zl.stateId=zs.id
								inner join zeelab.city as zc on zl.cityId=zc.id
								where (`email`=_userid OR `mobile`=_userid) 
									AND `codedPass`=MD5(_password) LIMIT 1;
                                    	select 'Y' as 'id','Login successfully as Franchise User' AS 'Result';
			else  if exists(select `email`,`userTypeId` from `zeeuser_login` where ((`email`=_userid or `mobile`=_userid) 
             and  `userTypeId`= 3 and _usertype='web'and  `status`=1) 
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
                                    	select 'Y' as 'id','Login successfully as Franchise User' AS 'Result';
				else  if exists(select `email`,`userTypeId` from `zeeuser_login` 
             where (`email`=_userid
             and  `userTypeId`= 4 and _usertype='web' and  `status`=1) 
			  and `codedPass`=md5(_password) limit 1) then
					
					select 'Y' as 'id','Success' as 'Result',
							zl.userId as 'userId',
                            zl.mobile as 'Mobile',
                            zl.userName as 'UserName',
							zl.email as 'Email',	
                            `pincode` as 'Pincode',
                            `cityId` as 'City',
                            `zoneId` as 'Zone',
                            `address` as 'Address',`storeCode` as 'StoreCode',`storeName` as 'StoreName',
							COALESCE(NULLIF(regc.name,''), 'NA') AS 'CitiesIds',
							zs.name as 'State',
							zl.userTypeId as 'UserType',
						(case zl.status when '1' then 'Active' when '2' then 'Deactive' else 'ETC' end) 
						as 'Status'	,
						zl.passPlain as 'Pass',zl.firstName as 'FirstName',zl.lastName as 'LastName'
								from zeelab.zeeuser_login as zl
								inner join zeelab.state as zs on zl.stateId=zs.id
                                inner join zeelab.regionalusercities AS rc ON zl.userId = rc.`userId`
								inner join zeelab.city AS regc ON regc.`id` = rc.`city_id`
								where `email`=_userid AND `codedPass`=MD5(_password) LIMIT 1;						
							
			else
                 select 'N' as 'id','Invalid Credentials. Please check your credentials again.' AS 'Result';
                 end if;
                end if;
                end if;
                                end if;
	END