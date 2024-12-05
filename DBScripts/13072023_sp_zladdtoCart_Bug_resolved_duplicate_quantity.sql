CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_zladdtoCart`(_userid VARCHAR(10),_productName VARCHAR(200),_count VARCHAR(30),_mrp VARCHAR(20),_proid VARCHAR(30))
BEGIN
          IF EXISTS(SELECT `userId` FROM `zeeuser_login` WHERE `userId`=_userid) THEN 
		  
               IF NOT EXISTS(SELECT `zl_product_id` FROM `zeeorder_details` WHERE `zl_product_id`=_proid AND `fk_userID`=_userid) THEN
                 INSERT INTO `zeeorder_details`
				 (`fk_userID`,`zl_productName`,`zl_count`,`zl_mrp`,`zl_status`,`zl_indate`,`zl_totalAmnt`,zl_product_id) 
                 VALUES (_userid,_productName,_count,_mrp,'C',NOW(),(_count*_mrp),_proid);
                 SELECT 'Y' AS 'id','Product added to cart' AS 'Result';
               ELSE 
                 UPDATE `zeeorder_details` SET zl_count=(zl_count+_count),zl_totalAmnt=((zl_count)*_mrp)
				 WHERE zl_status='C' AND `zl_product_id`=_proid AND `fk_userID`=_userid;
                 SELECT 'Y' AS 'id','Cart Updated' AS 'Result';
                END IF;
              END IF;        
	END