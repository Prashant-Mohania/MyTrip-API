insert into zeelab.usertype (name,isDisplayed,status) values
('Super Admin',1,1)


insert into zeeuser_login(userName,email,mobile,codedPass,passPlain,userTypeId) values
('SA','superadmin@gmail.com','324235',md5('12345'),'12345',3);
