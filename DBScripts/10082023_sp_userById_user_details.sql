CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_userById`(_userid varchar(50))
BEGIN
             
                 select `userId` as 'id','Success' as 'Result',
				`storeName` as 'StoreName',
				 `address` as 'Address',`storeCode` as 'StoreCode',`storeName` as 'StoreName',
				 `pincode` as 'Pincode',`cityId` as 'City',
                 `stateId` as 'State',`zoneId` as 'Zone',
				`firstName` as 'FirstName',`lastName` as 'LastName'
                 from `zeeuser_login` where (`userId`=_userid ) ;
				
                
	END