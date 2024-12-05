CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_userById`(_userid varchar(50))
BEGIN
    SELECT 
        zl.userId as 'id',
        'Success' as 'Result',
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
        zl.lastName as 'LastName',
        GROUP_CONCAT(rc.`city_id`) AS CitiesIds
    FROM 
        `zeeuser_login` as zl 
        INNER JOIN `usertype` as zu ON zl.userTypeId=zu.id
        INNER JOIN `regionalusercities` rc ON zl.`userId` = rc.`userId`
    WHERE 
        zl.`userId`=_userid 
        AND zl.userTypeId = 4
    GROUP BY
        zl.`userId`

    UNION

    SELECT 
        zl.userId as 'id',
        'Success' as 'Result',
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
        zl.lastName as 'LastName',
        NULL AS CitiesIds
    FROM 
        `zeeuser_login` as zl 
        INNER JOIN `usertype` as zu ON zl.userTypeId=zu.id
        WHERE 
        zl.`userId`=_userid 
        AND zl.userTypeId <> 4
    GROUP BY
        zl.`userId`;
END