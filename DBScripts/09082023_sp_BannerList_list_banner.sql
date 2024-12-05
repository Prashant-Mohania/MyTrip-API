CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_BannerList`()
BEGIN
             

   SELECT id,name,image,sequence from banner where status=1;

	END