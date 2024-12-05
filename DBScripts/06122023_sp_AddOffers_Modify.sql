CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_Addoffer`(
    Name VARCHAR(300),
    Description VARCHAR(300),
    FromDate DATETIME,
    ToDate DATETIME,
    EligibilityQty VARCHAR(300),
    OfferQty VARCHAR(30),
    ProductIdsJSON VARCHAR(5000),
    Status VARCHAR(50),
    CreatedBy VARCHAR(50),
    CreatedOn DATETIME,
    UpdatedBy VARCHAR(50),
    UpdatedOn DATETIME
)
BEGIN
    DECLARE lastOfferId INT;
    DECLARE i INT DEFAULT 0;
    DECLARE product_id INT;

    -- Insert into the main 'offer' table
    INSERT INTO `offer`(
        `name`, `description`, `FromDate`, `ToDate`, `eligibilityQty`, `offerQty`,
        `status`, `createdBy`, `createdDate`, `updatedBy`, `updatedDate`
    ) 
   VALUES (
    Name, Description, FromDate, ToDate, EligibilityQty, OfferQty,
    Status,
    CreatedBy, CreatedOn, UpdatedBy, UpdatedOn
);

    -- Get the last inserted offer id
    SET lastOfferId = LAST_INSERT_ID();

    -- Insert into the 'offer_product_mapping' table for each product id
    WHILE i < JSON_LENGTH(ProductIdsJSON) DO
        SET product_id = JSON_UNQUOTE(JSON_EXTRACT(ProductIdsJSON, CONCAT('$[', i, ']')));
        INSERT INTO `offerproduct`(`offer_id`, `product_id`)
        VALUES (lastOfferId, product_id);
        SET i = i + 1;
    END WHILE;

    SELECT 'Y' AS 'id', 'Offer Added Successfully' AS 'desc';
END