CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_bannerUpdate`(
_bannerId varchar(10),
_bannerName varchar(50),
_image varchar(200),_sequence varchar(10))
BEGIN
              if exists(select `id` from `banner` where `status`='1'  and `id`=_bannerId) then
					                    
					update `banner` 
					set `name`=_bannerName,
                    `image`=_image,`sequence`=_sequence,
                    updatedBy='Admin',updatedDate=now()
				  where `status`='1' AND `id`=_bannerId;
                  
               
                  
                 select 'Y' as 'id','Details Updated' as 'desc';
                 else
                 SELECT 'N' AS 'id','banner Not Found' AS 'desc';
                 end if;
              
	END