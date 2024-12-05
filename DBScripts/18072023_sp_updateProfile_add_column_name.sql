DELIMITER  //

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_updateProfile`(_userID varchar(10),_userName varchar(50),_storeCode varchar(30),
_storeName varchar(50),
_address varchar(50),_pincode varchar(20),_cityId varchar(50),_stateId varchar(50),_firstName varchar(30),
 _lastName varchar(30))
BEGIN
              if exists(select `email` from `zeeuser_login` where `status`='1' and `userId`=_userID) then
                update `zeeuser_login` 
				set `userName`=_userName,`storeCode`=_storeCode,`storeName`=_storeName,
				`address`=_address,`firstName`=_firstName,`lastName`=_lastName,
                  `pincode`=_pincode,`cityId`=_cityId,`stateId`=_stateId ,updatedBy='Admin',updatedDate=now()
				  where `status`='1' AND `userId`=_userID;
                 select 'Y' as 'id','Details Updated' as 'desc';
                 else
                 SELECT 'N' AS 'id','User Not Found OR Deactive' AS 'desc';
                 end if;
              
	END;
    DELIMITER