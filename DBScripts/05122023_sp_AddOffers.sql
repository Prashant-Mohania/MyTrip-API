CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_Addoffer`(
Name varchar(300),
Description VARCHAR(300),
FromDate datetime,
ToDate datetime,
EligibilityQty VARCHAR(300),
OfferQty VARCHAR(300))
BEGIN             
               insert into `offer`(`name`,`description`,`FromDate`,`ToDate`,`eligibilityQty`,`offerQty`) 
               values (Name,Description,FromDate,ToDate,EligibilityQty,OfferQty);
END