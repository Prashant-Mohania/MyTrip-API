CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_productList_insert`(
    _ItemCode VARCHAR(300),
    _ItemName VARCHAR(300),
    _FrgnName VARCHAR(300),
    _OnHand VARCHAR(300),
    _Available VARCHAR(300),
    _MRP VARCHAR(300),
    _F1 VARCHAR(300),
    _F2 VARCHAR(300),
    _F3 VARCHAR(300),
    _F4 VARCHAR(300),
    _F5 VARCHAR(300)
)
BEGIN
    DECLARE productExists INT;

    SELECT `pk_product_id` INTO productExists
    FROM `productlist` AS pl
    WHERE `ItemCode` = _ItemCode
    LIMIT 1;

    IF productExists IS NULL THEN
        INSERT INTO `productlist` (
            `ItemCode`,
            `ItemName`,
            `FrgnName`,
            `OnHand`,
            `Available`,
            `MRP`,
            `F_1`,
            `F_2`,
            `F_3`,
            `F_4`,
            `F_5`
        ) VALUES (
            _ItemCode,
            _ItemName,
            _FrgnName,
            _OnHand,
            _Available,
            _MRP,
            _F1,
            _F2,
            _F3,
            _F4,
            _F5
        );
    ELSE
        UPDATE `productlist` AS pl
        SET
            `ItemName` = _ItemName,
            `FrgnName` = _FrgnName,
            `OnHand` = _OnHand,
            `Available` = _Available,
            `MRP` = _MRP,
            `F_1` = _F1,
            `F_2` = _F2,
            `F_3` = _F3,
            `F_4` = _F4,
            `F_5` = _F5
        WHERE `pk_product_id` = productExists;

        IF ROW_COUNT() > 0 THEN
            SELECT 'Y' AS 'id', IF(ROW_COUNT() = 1, 'Product List Inserted', 'Product List Updated') AS 'desc';
        ELSE
            SELECT 'N' AS 'id', 'No changes' AS 'desc';
        END IF;
    END IF;
END