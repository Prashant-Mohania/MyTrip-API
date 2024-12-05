CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_zladdtoCart`(
_userid VARCHAR(10),
_productName varchar(300),
 _count VARCHAR(30),
_mrp varchar(40),
 _proid VARCHAR(30))
BEGIN
    DECLARE onHandQuantity INT;
    DECLARE existingQuantity INT;
    DECLARE updatedCount INT;

    IF EXISTS(SELECT `userId` FROM `zeeuser_login` WHERE `userId` = _userid) THEN
        IF NOT EXISTS (SELECT `zl_product_id`  FROM `zeeorder_details` WHERE `zl_product_id` = _proid AND `fk_userID` = _userid
        ) THEN
           if (cast(_count as unsigned) > cast((select `OnHand` from productlist where `itemcode` = _proid)as unsigned)) then
					SELECT 'Fail' AS 'id','Can not insert as not enough quantity available in inventory' AS 'Result';	
            ELSE
                INSERT INTO `zeeorder_details`(`fk_userID`,`zl_productName`,`zl_count`,`zl_mrp`,`zl_status`,`zl_indate`,`zl_totalAmnt`,zl_product_id) 
                 VALUES (_userid,_productName,_count,_mrp,'C',NOW(),(_count*_mrp),_proid);
                 SELECT 'Y' AS 'id','Product added to cart' AS 'Result';

                SELECT 'Y' AS `id`, 'Cart Added' AS `Result`;
            END IF;
        ELSE
            SET existingQuantity = (SELECT `zl_count` FROM `zeeorder_details` WHERE `zl_status` = 'C' AND `zl_product_id` = _proid AND `fk_userID` = _userid);
            SET updatedCount = existingQuantity + CAST(_count AS SIGNED);
            SET onHandQuantity = (SELECT `OnHand` FROM productlist WHERE `itemcode` = _proid);

            IF (CAST(updatedCount AS UNSIGNED) > CAST(onHandQuantity AS UNSIGNED)) THEN
                SELECT 'Fail' AS `id`, 'You cannot update as there is not enough quantity available in inventory' AS `Result`;
            ELSE
				if not exists(SELECT `zl_product_id`  FROM `zeeorder_details` WHERE `zl_product_id` = _proid AND `fk_userID` = _userid and `zl_status`='C') THEN
					INSERT INTO `zeeorder_details`(`fk_userID`,`zl_productName`,`zl_count`,`zl_mrp`,`zl_status`,`zl_indate`,`zl_totalAmnt`,`zl_product_id`) 
					VALUES (_userid,_productName,_count,_mrp,'C',NOW(),(_count*_mrp),_proid);
                     SELECT 'Y' AS `id`, 'Same product added to cart' AS `Result`;
				Else
					UPDATE `zeeorder_details` SET
                    `zl_count` = updatedCount,
                    `zl_totalAmnt`=(updatedCount*_mrp)
					WHERE `zl_status` = 'C' AND `zl_product_id` = _proid AND `fk_userID` = _userid;

                SELECT 'Y' AS `id`, 'Cart Updated' AS `Result`;
            END IF;
        END IF;
    END IF;
    END IF;
END