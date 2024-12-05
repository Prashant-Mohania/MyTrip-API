	DELIMITER //

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_zladdtoCart`(_userid VARCHAR(10), _count VARCHAR(30), _proid VARCHAR(30))
BEGIN
    DECLARE onHandQuantity INT;
    DECLARE existingQuantity INT;
    DECLARE updatedCount INT;

    IF EXISTS(SELECT `userId` FROM `zeeuser_login` WHERE `userId` = _userid) THEN
        IF NOT EXISTS (SELECT `zl_product_id`  FROM `zeeorder_details` WHERE `zl_product_id` = _proid AND `fk_userID` = _userid
        ) THEN
           if (_count > (select `OnHand` from productlist where `itemcode` = _proid)) then
					SELECT 'Fail' AS 'id','Can not insert as not enough quantity available in inventory' AS 'Result';	
            ELSE
                INSERT INTO `zeeorder_details` (`fk_userID`, `zl_count`, `zl_status`, `zl_indate`, `zl_product_id`)
                VALUES (_userid, CAST(_count AS SIGNED), 'C', NOW(), _proid);

                SELECT 'Y' AS `id`, 'Cart Added' AS `Result`;
            END IF;
        ELSE
            SET existingQuantity = (SELECT `zl_count` FROM `zeeorder_details` WHERE `zl_status` = 'C' AND `zl_product_id` = _proid AND `fk_userID` = _userid);
            SET updatedCount = existingQuantity + CAST(_count AS SIGNED);
            SET onHandQuantity = (SELECT `OnHand` FROM productlist WHERE `itemcode` = _proid);

            IF (CAST(updatedCount AS UNSIGNED) > CAST(onHandQuantity AS UNSIGNED)) THEN
                SELECT 'Fail' AS `id`, 'You cannot update as there is not enough quantity available in inventory' AS `Result`;
            ELSE
                UPDATE `zeeorder_details` SET `zl_count` = updatedCount
                WHERE `zl_status` = 'C' AND `zl_product_id` = _proid AND `fk_userID` = _userid;

                SELECT 'Y' AS `id`, 'Cart Updated' AS `Result`;
            END IF;
        END IF;
    END IF;
END
DELIMITER ;