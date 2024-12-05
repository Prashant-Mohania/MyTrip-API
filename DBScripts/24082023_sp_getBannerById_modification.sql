CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_getBannerById`(_bannerId varchar(50))
BEGIN
             
                 select `id` as 'Id','Success' as 'Result',
				`name` as 'BannerName',
                `image` as 'ImageUrl',
                `sequence` as 'Sequence'
                 from `banner` where `id`=_bannerId and `status`=1;
				
             
	END