CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_OrderToSAP`(
_orderId varchar(50),
_jsonArray longtext, 
_orderShipId varchar(50))
BEGIN

		if exists(select `_orderId` from `zeeorder_track` where `_orderId`=_orderId) then 
			UPDATE `zeeorder_track`  SET 
					`SAPOrderStatusId` = 4,
					`SAPAPIResponses`=_jsonArray,
					`zl_orderShipID`=_orderShipId 
					where `zl_orderId`=_orderId;
			SELECT 'Y' AS 'id','Order Processed' AS 'Result';
		else
			UPDATE `zeeorder_track`  SET 
					`SAPOrderStatusId` = 3,
					`SAPAPIResponses`=_jsonArray
                    where `zl_orderId`=_orderId;
					SELECT 'N' AS 'id','Order Rejected' AS 'Result';
      end if;
      
				

END