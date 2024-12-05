create table zeelab.PopupImage (
  id int auto_increment not null primary key,
  imageName varchar(100),
  image varchar(200),
  productId varchar(300),
  status int not null,
  createdBy varchar(10),
  createdDate datetime,
  updatedBy varchar(10),
  updatedDate datetime
);