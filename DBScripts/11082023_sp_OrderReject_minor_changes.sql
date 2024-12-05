CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_OrderReject`(
_orderId varchar(50))
BEGIN

		if exists(select `_orderId` from `zeeorder_track` where `_orderId`=_orderId) then 
			UPDATE `zeeorder_track`  SET 
					`SAPOrderStatusId` = 3,
                    `zl_orderStatus`='R'
                    where `zl_orderId`=_orderId and zl_orderStatus='P';
			SELECT 'Y' AS 'id','Order Rejected' AS 'desc';
		else
			SELECT 'N' AS 'id','Order not found' AS 'desc';
      end if;
      
				

END