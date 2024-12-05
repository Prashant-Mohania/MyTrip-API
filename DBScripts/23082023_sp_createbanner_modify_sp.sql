CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_createbanner`(
_bannerName varchar(50),
_image varchar(200),_sequence varchar(10))
BEGIN	
				
              	if not exists(select `sequence` from `banner` where `sequence`=_sequence and `status`=1) then
                 insert into `banner`(`name`,`image`,`sequence`,`status`,createdBy,createdDate)
                  values(_bannerName,_image,_sequence,1,'Admin',now());
                 select 'Y' as 'id','Banner Added' as 'desc';
                              else
                 SELECT 'N' AS 'id','Sequence Already Exists! Please select other sequence' AS 'desc';
                 end if;
                
	END