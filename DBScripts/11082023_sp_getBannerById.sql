CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_getBannerById`(_bannerId varchar(50))
BEGIN
             
                 select `id` as 'Id','Success' as 'Result',
				`name` as 'BannerName'
                 from `banner` where (`id`=_bannerId ) ;
				
                
	END