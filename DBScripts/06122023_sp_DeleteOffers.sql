CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeleteOffer`(
    _Id INT
)
BEGIN
    DECLARE i INT DEFAULT 0;
    DECLARE product_id INT;

    -- Delete existing entries in 'offerproduct' table
         DELETE FROM `offerproduct` WHERE `offer_id` = _Id;
         
    -- Delete from the main 'offer' table
    DELETE FROM `offer` WHERE `id` = _Id;
    
    -- Check if any rows were deleted
    IF ROW_COUNT() > 0 THEN
        SELECT 'Y' AS 'id', 'Offer Deleted Successfully' AS 'desc';
    ELSE
        SELECT 'N' AS 'id', 'Offer not Deleted' AS 'desc';
    END IF;
END