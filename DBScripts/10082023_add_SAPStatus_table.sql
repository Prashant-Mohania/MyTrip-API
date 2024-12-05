Create table zeelab.SAPOrderStatuses(
id int auto_increment not null primary key,
name varchar(30),
status int,
createdBy varchar(10),
createdDate datetime,
updatedBy varchar(10),
updatedDate datetime)


insert into zeelab.SAPOrderStatuses(name,status,createdBy,createdDate) values
('InProgress',1,'Admin',now());
insert into zeelab.SAPOrderStatuses(name,status,createdBy,createdDate) values
('Dispatched',1,'Admin',now());
insert into zeelab.SAPOrderStatuses(name,status,createdBy,createdDate) values
('Rejected',1,'Admin',now());
insert into zeelab.SAPOrderStatuses(name,status,createdBy,createdDate) values
('Processed',1,'Admin',now());