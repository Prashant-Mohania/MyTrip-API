CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_userList`()
BEGIN
    SELECT
        l.userId AS 'Id',
        COALESCE(NULLIF(l.firstName,''), 'NA') AS 'FirstName',
        COALESCE(NULLIF(l.lastName,''), 'NA') AS 'LastName',
        COALESCE(NULLIF(l.mobile,''), 'NA') AS 'Mobile',
        COALESCE(NULLIF(l.email,''), 'NA') AS 'Email',
        COALESCE(NULLIF(l.storeCode,''), 'NA') AS 'StoreCode',
        COALESCE(NULLIF(l.storeName,''), 'NA') AS 'StoreName',
        l.userTypeId as 'UserTypeId',
        COALESCE(NULLIF(u.name,''), 'NA') AS 'UserType',
        COALESCE(NULLIF(z.name,''), 'NA') AS 'Zone',
        COALESCE(NULLIF(s.name,''), 'NA') AS 'State',
        COALESCE(NULLIF(c.name,''), 'NA') AS 'City',
        GROUP_CONCAT(COALESCE(NULLIF(regc.name,''), 'NA')) AS 'RegionalCities'
    FROM zeelab.zeeuser_login AS l
    LEFT OUTER JOIN zeelab.usertype AS u ON l.userTypeId = u.id
    LEFT OUTER JOIN zeelab.zone AS z ON l.zoneId = z.id
    LEFT OUTER JOIN zeelab.state AS s ON l.stateId = s.id
    LEFT OUTER JOIN zeelab.city AS c ON l.cityId = c.id
    LEFT OUTER JOIN zeelab.regionalusercities AS rc ON l.userId = rc.`userId`
    LEFT OUTER JOIN zeelab.city AS regc ON regc.`id` = rc.`city_id`
    WHERE l.status = 1 AND (l.userTypeId = 1 OR l.userTypeId = 2 OR l.userTypeId = 4)
    GROUP BY l.userId;
END