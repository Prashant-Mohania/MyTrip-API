
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_createUser`(
_username varchar(50),
_usermobile varchar(20),_useremail varchar(100),
    _address varchar(50),_pincode varchar(20),_password varchar(30),_firstName varchar(30),_lastName varchar(30),
	_storeCode varchar(30), _storeName varchar(30),_userTypeId int , _zoneId int, _cityId int, _stateId int)
BEGIN	
              if not exists(select `email` from `zeeuser_login` where `mobile`=_usermobile) then
                 insert into `zeeuser_login`(`userName`,`mobile`,`email`,`codedPass`,`address`,
				 `pincode`,`status`,`passPlain`,`firstName`,`lastName`,`storeCode`,`storeName`,
				 `createdBy`,`createdDate`,`userTypeId`,`zoneId`,`cityId`,`stateId`)
                  values(_username,_usermobile,_useremail,md5(_password),_address,
				  _pincode,1,_password,_firstName,_lastName,_storeCode,_storeName,'Admin',now(),
				  _userTypeId,_zoneId,
				  _cityId ,_stateId);
                 select 'Y' as 'id','User Created' as 'desc';
                else
                 SELECT 'N' AS 'id','User Already Exists!' AS 'desc';
                 end if;
	END;
    DELIMITER