CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_OfferList`(
    IN p_status varchar(10)
)
BEGIN
    IF p_status IS NULL OR p_status = '' THEN
        -- If p_status is NULL or an empty string, select all records
        SELECT
            `id`,
            `name`,
            `description`,
            `FromDate`,
            `ToDate`,
            `eligibilityQty`,
            `offerQty`,
            `status`,
            `createdBy`,
            `createdDate`,
            `updatedBy`,
            `updatedDate`
        FROM `offer`;
    ELSE
        -- If p_status is not NULL, select records based on the specified status
        SELECT
            `id`,
            `name`,
            `description`,
            `FromDate`,
            `ToDate`,
            `eligibilityQty`,
            `offerQty`,
            `status`,
            `createdBy`,
            `createdDate`,
            `updatedBy`,
            `updatedDate`
        FROM `offer`
        WHERE `status` = p_status;
    END IF;
END