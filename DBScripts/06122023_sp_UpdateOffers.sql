CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_UpdateOffer`(
    _Id INT,
    _Name VARCHAR(300),
    _Description VARCHAR(300),
    _FromDate DATETIME,
    _ToDate DATETIME,
    _EligibilityQty VARCHAR(300),
    _OfferQty VARCHAR(300),
    _ProductIdsJSON VARCHAR(5000),
     _Status VARCHAR(50),
     _UpdatedBy VARCHAR(50),
    _UpdatedOn DATETIME,
    _CreatedBy VARCHAR(50),
    _CreatedOn DATETIME
)
BEGIN
    DECLARE i INT DEFAULT 0;
    DECLARE product_id INT;

    -- Update the main 'offer' table
    UPDATE `offer`
    SET
        `name` = _Name,
        `description` = _Description,
        `FromDate` = _FromDate,
        `ToDate` = _ToDate,
        `eligibilityQty` = _EligibilityQty,
        `offerQty` = _OfferQty,
        `status` =  _Status,
        `updatedBy` = _UpdatedBy, 
        `updatedDate` = _UpdatedOn       
    WHERE `id` = _Id;

    -- Delete existing entries in 'offerproduct' table
    DELETE FROM `offerproduct` WHERE `offer_id` = _Id;

    -- Insert updated product ids into the 'offerproduct' table
    WHILE i < JSON_LENGTH(_ProductIdsJSON) DO
        SET product_id = JSON_UNQUOTE(JSON_EXTRACT(_ProductIdsJSON, CONCAT('$[', i, ']')));
        INSERT INTO `offerproduct`(`offer_id`, `product_id`)
        VALUES (_Id, product_id);
        SET i = i + 1;
    END WHILE;

    -- Check if any rows were updated
    IF ROW_COUNT() > 0 THEN
        SELECT 'Y' AS 'id', 'Offer Updated Successfully' AS 'desc';
    ELSE
        SELECT 'N' AS 'id', 'Offer not Updated' AS 'desc';
    END IF;
END