CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_productList_insert`(
_ItemCode varchar(300),
_ItemName VARCHAR(300),
_FrgnName VARCHAR(300),
_OnHand VARCHAR(300),
_Available VARCHAR(300),
_MRP VARCHAR(300),
_F1 VARCHAR(300),
_F2 VARCHAR(300),
_F3 VARCHAR(300),
_F4 VARCHAR(300),
_F5 VARCHAR(300))
BEGIN
             if not exists(select `ItemCode` from `productlist` where `ItemCode`=_ItemCode) then
               insert into `productlist`(`ItemCode`,`ItemName`,`FrgnName`,`OnHand`,`Available`,`MRP`,`F_1`,`F_2`,`F_3`,`F_4`,`F_5`) 
               values (_ItemCode,_ItemName,_FrgnName,_OnHand,_Available,_MRP,_F1,_F2,_F3,_F4,_F5);
               SELECT 'Y' AS 'id','Product List Inserted' AS 'desc';
             else
               update `productlist` set `OnHand`=_OnHand,`Available`=_Available,`MRP`=_MRP,`F_1`=_F1,`F_2`=_F2,`F_3`=_F3,`F_4`=_F4,`F_5`=_F5 
                where `ItemCode`=_ItemCode;
                Select 'Y' as 'id','Product List Updated' as 'desc';
             end if;
	END