DELIMITER  //

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_zlOrderPlace`(_userid varchar(20))
BEGIN

DECLARE _mrp DECIMAL(30,6) DEFAULT 0;
DECLARE _orderID,_productname,_productID,_count VARCHAR(200);
	
SELECT ZEEORDERID(_userid) INTO _orderID;			
		
IF EXISTS(SELECT `fk_userID` FROM `zeeorder_details` WHERE `zl_status`='C' AND `fk_userID`=_userid) THEN
	SELECT SUM(`zl_totalAmnt`) INTO _mrp FROM `zeeorder_details` WHERE `zl_status`='C' AND fk_userID=_userid;
   UPDATE `productlist` AS t1
JOIN (
    SELECT `zl_product_id`, `zl_count`,`fk_userID`,`zl_status` 
    FROM `zeeorder_details`
    WHERE `zl_product_id` IN (`zl_product_id`)
) AS t2 ON  t1.`ItemCode` =t2.`zl_product_id`
SET t1.`OnHand` = t1.`OnHand` - t2.`zl_count`
where t2.`fk_userID`=_userid and t2.`zl_status` = 'C';	
				
	UPDATE `zeeorder_details` 
	SET 
		`zl_status` = 'P',
		`zl_order_ID` = _orderID
	WHERE
		`fk_userID` = _userid;
					
					INSERT INTO `zeeorder_track`(`fk_userID`,`zl_orderID`,`zl_orderDate`,`zl_comment`,`zl_totaloforder`) VALUES
				(_userid,_orderID,NOW(),'Placed',_mrp);
				
	SELECT 'Y' AS 'id', 'Order Placed Successfully!' AS 'Result';
					
	
					
ELSE
	SELECT 'N' AS 'id','Product not found in cart' AS 'Result';
END IF;
end;
DELIMITER  