-- create table query

create table zeelab.userType (
  id int auto_increment not null primary key,
  name varchar(10),
  isDisplayed boolean not null,
  status int 
);

create table zeelab.state (
  id int auto_increment not null primary key,
  name varchar(30),
  status int 
);

create table zeelab.city (
  id int auto_increment not null primary key,
  name varchar(30),
  stateId int,
  status int not null,
   CONSTRAINT fk_state
    FOREIGN KEY (stateId) 
        REFERENCES zeelab.state(id)
);
-- changes in zone table 07-07-23
create table zeelab.zone (
  id int auto_increment not null primary key,
  name varchar(50),
  status int not null
);

create table zeelab.ZoneStateMapping (
  id int auto_increment not null primary key,
  stateId int,
  zoneId int,
  status int not null,
   CONSTRAINT fk_state
    FOREIGN KEY (stateId) 
        REFERENCES zeelab.state(id),
	CONSTRAINT fk_zone
    FOREIGN KEY (zoneId) 
        REFERENCES zeelab.zone(id)
);


-- add column query
ALTER TABLE zeelab.zeeuser_login ADD firstName varchar(30);
ALTER TABLE zeelab.zeeuser_login ADD lastName varchar(30);
ALTER TABLE zeelab.zeeuser_login ADD storeCode varchar(10);
ALTER TABLE zeelab.zeeuser_login ADD storeName varchar(50);
ALTER TABLE zeelab.zeeuser_login ADD createdBy varchar(50);
ALTER TABLE zeelab.zeeuser_login ADD createdDate DATETIME ;
ALTER TABLE zeelab.zeeuser_login ADD updatedBy varchar(50);
ALTER TABLE zeelab.zeeuser_login ADD updatedDate DATETIME ;

-- add foreign key query


ALTER TABLE zeelab.zeeuser_login ADD COLUMN userTypeId INT NOT NULL;
SET FOREIGN_KEY_CHECKS=0;
ALTER TABLE zeelab.zeeuser_login ADD CONSTRAINT fk_usertype FOREIGN KEY (userTypeId) REFERENCES zeelab.usertype(id);
SET FOREIGN_KEY_CHECKS=1;

ALTER TABLE zeelab.zeeuser_login ADD COLUMN zoneId INT NOT NULL;
SET FOREIGN_KEY_CHECKS=0;
ALTER TABLE zeelab.zeeuser_login ADD CONSTRAINT fk_zone FOREIGN KEY (zoneId) REFERENCES zeelab.zone(id);
SET FOREIGN_KEY_CHECKS=1;

ALTER TABLE zeelab.zeeuser_login ADD COLUMN cityId INT NOT NULL;
SET FOREIGN_KEY_CHECKS=0;
ALTER TABLE zeelab.zeeuser_login ADD CONSTRAINT fk_city FOREIGN KEY (cityId) REFERENCES zeelab.city(id);
SET FOREIGN_KEY_CHECKS=1;

ALTER TABLE zeelab.zeeuser_login ADD COLUMN stateId INT NOT NULL;
SET FOREIGN_KEY_CHECKS=0;
ALTER TABLE zeelab.zeeuser_login ADD CONSTRAINT fk_user_state FOREIGN KEY (stateId) REFERENCES zeelab.state(id);
SET FOREIGN_KEY_CHECKS=1;

-- update column name query

ALTER TABLE zeelab.zeeuser_login RENAME COLUMN pk_user_id TO userId;
ALTER TABLE zeelab.zeeuser_login RENAME COLUMN zl_usrName TO userName;

ALTER TABLE zeelab.zeeuser_login RENAME COLUMN zl_usrMobile TO mobile;

ALTER TABLE zeelab.zeeuser_login RENAME COLUMN zl_usrEmail TO email;

ALTER TABLE zeelab.zeeuser_login RENAME COLUMN zl_codedPass TO codedPass;

ALTER TABLE zeelab.zeeuser_login RENAME COLUMN zl_address TO address;

ALTER TABLE zeelab.zeeuser_login RENAME COLUMN zl_pincode TO pincode;

ALTER TABLE zeelab.zeeuser_login RENAME COLUMN zl_passPlain TO passPlain;

-- update column name with datatype

ALTER TABLE zeelab.zeeuser_login CHANGE zl_status status int;

-- Drop column query

ALTER TABLE zeelab.zeeuser_login DROP COLUMN zl_UserID;

ALTER TABLE zeelab.zeeuser_login DROP COLUMN zl_shopName;

ALTER TABLE zeelab.zeeuser_login DROP COLUMN zl_city;

ALTER TABLE zeelab.zeeuser_login DROP COLUMN zl_state;

ALTER TABLE zeelab.zeeuser_login DROP COLUMN zl_indate;

ALTER TABLE zeelab.zeeuser_login DROP COLUMN zl_pancardNo;

ALTER TABLE zeelab.zeeuser_login DROP COLUMN zl_aadharNo;



SET SQL_SAFE_UPDATES = 0;
update zeelab.zeeuser_login set zl_status=null ;
SET SQL_SAFE_UPDATES = 1;


ALTER TABLE zeelab.zeeuser_login ADD COLUMN userTypeId INT NOT NULL;
SET FOREIGN_KEY_CHECKS=0;
ALTER TABLE zeelab.zeeuser_login ADD CONSTRAINT fk_usertype FOREIGN KEY (userTypeId) REFERENCES zeelab.usertype(id);
SET FOREIGN_KEY_CHECKS=1;


SELECT * FROM zeelab.usertype;
SELECT * FROM zeelab.state;
SELECT * FROM zeelab.city;
ALTER TABLE zeelab.usertype modify  name varchar(30);
insert into zeelab.usertype(name, isDisplayed, status) values ('Franchise User',1,1);
insert into zeelab.state(name,  status) values ('Gujarat',1);
insert into zeelab.city(name,stateId,  status) values ('Ahmedabad',1,1);