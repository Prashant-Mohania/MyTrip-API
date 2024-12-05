

create table zeelab.banner (
  id int auto_increment not null primary key,
  name varchar(30),
  image varchar(200),
  sequence int,
  status int,
  createdBy varchar(10),
  createdDate datetime,
  updatedBy varchar(10),
  updatedDate datetime
);



