

-- Step 1: Disable Auto-Increment
SET SESSION sql_mode='NO_AUTO_VALUE_ON_ZERO';

-- Step 2: Insert the Manual Value

INSERT INTO zeelab.state (id, name,status,createdBy,createdDate) VALUES(1,'Andhra Pradesh',1,'Admin',now());
INSERT INTO zeelab.state (id, name,status,createdBy,createdDate) VALUES(2,'Arunachal Pradesh',1,'Admin',now());
INSERT INTO zeelab.state (id, name,status,createdBy,createdDate) VALUES(3,'Assam',1,'Admin',now());
INSERT INTO zeelab.state (id, name,status,createdBy,createdDate) VALUES(4,'Bihar',1,'Admin',now());
INSERT INTO zeelab.state (id, name,status,createdBy,createdDate) VALUES(5,'Chhattisgarh',1,'Admin',now());
INSERT INTO zeelab.state (id, name,status,createdBy,createdDate) VALUES(6,'Goa',1,'Admin',now());
INSERT INTO zeelab.state (id, name,status,createdBy,createdDate) VALUES(7,'Gujarat',1,'Admin',now());
INSERT INTO zeelab.state (id, name,status,createdBy,createdDate) VALUES(8,'Haryana',1,'Admin',now());
INSERT INTO zeelab.state (id, name,status,createdBy,createdDate) VALUES(9,'Himachal Pradesh',1,'Admin',now());
INSERT INTO zeelab.state (id, name,status,createdBy,createdDate) VALUES(10,'Jharkhand',1,'Admin',now());
INSERT INTO zeelab.state (id, name,status,createdBy,createdDate) VALUES(11,'Karnataka',1,'Admin',now());
INSERT INTO zeelab.state (id, name,status,createdBy,createdDate) VALUES(12,'Kerala',1,'Admin',now());
INSERT INTO zeelab.state (id, name,status,createdBy,createdDate) VALUES(13,'Madhya Pradesh',1,'Admin',now());
INSERT INTO zeelab.state (id, name,status,createdBy,createdDate) VALUES(14,'Maharashtra',1,'Admin',now());
INSERT INTO zeelab.state (id, name,status,createdBy,createdDate) VALUES(15,'Manipur',1,'Admin',now());
INSERT INTO zeelab.state (id, name,status,createdBy,createdDate) VALUES(16,'Meghalaya',1,'Admin',now());
INSERT INTO zeelab.state (id, name,status,createdBy,createdDate) VALUES(17,'Mizoram',1,'Admin',now());
INSERT INTO zeelab.state (id, name,status,createdBy,createdDate) VALUES(18,'Nagaland',1,'Admin',now());
INSERT INTO zeelab.state (id, name,status,createdBy,createdDate) VALUES(19,'Odisha',1,'Admin',now());
INSERT INTO zeelab.state (id, name,status,createdBy,createdDate) VALUES(20,'Punjab',1,'Admin',now());
INSERT INTO zeelab.state (id, name,status,createdBy,createdDate) VALUES(21,'Rajasthan',1,'Admin',now());
INSERT INTO zeelab.state (id, name,status,createdBy,createdDate) VALUES(22,'Sikkim',1,'Admin',now());
INSERT INTO zeelab.state (id, name,status,createdBy,createdDate) VALUES(23,'Tamil Nadu',1,'Admin',now());
INSERT INTO zeelab.state (id, name,status,createdBy,createdDate) VALUES(24,'Telangana',1,'Admin',now());
INSERT INTO zeelab.state (id, name,status,createdBy,createdDate) VALUES(25,'Tripura',1,'Admin',now());
INSERT INTO zeelab.state (id, name,status,createdBy,createdDate) VALUES(26,'Uttar Pradesh',1,'Admin',now());
INSERT INTO zeelab.state (id, name,status,createdBy,createdDate) VALUES(27,'Uttarakhand',1,'Admin',now());
INSERT INTO zeelab.state (id, name,status,createdBy,createdDate) VALUES(28,'West Bengal',1,'Admin',now());

-- Step 3: Re-enable Auto-Increment
SET SESSION sql_mode='';