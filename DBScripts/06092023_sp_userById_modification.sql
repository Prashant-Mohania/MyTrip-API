CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_userById`(_userid varchar(50))
BEGIN
             
                 select 
                 zl.userId as 'id','Success' as 'Result',
				 zl.userName as 'Username',
                 zl.mobile as 'Mobile',
                 zl.email as 'Email',
				 zl.address as 'Address',
                 zl.storeCode as 'StoreCode',
                 zl.storeName as 'StoreName',
				 zl.pincode as 'Pincode',
                 zl.cityId as 'City', 
				 zl.userTypeId as 'UsertypeId',
                 zu.name as 'Usertype',
                 zl.stateId as 'State',
                 zl.zoneId as 'Zone',
				 zl.firstName as 'FirstName',
                 zl.lastName as 'LastName'
                 from `zeeuser_login` as zl 
                 inner join `usertype` as zu on zl.userTypeId=zu.id
                 where (`userId`=_userid ) ;
				
                
	END