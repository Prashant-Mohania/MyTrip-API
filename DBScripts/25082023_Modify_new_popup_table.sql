create table zeelab.PopupImage (
  id int auto_increment not null primary key,
  imageName varchar(100),
  image varchar(200),
  productId int,
  status int not null,
  createdBy varchar(10),
  createdDate datetime,
  updatedBy varchar(10),
  updatedDate datetime,
   CONSTRAINT fk_product_image
    FOREIGN KEY (productId) 
        REFERENCES zeelab.productlist(pk_product_id)
);