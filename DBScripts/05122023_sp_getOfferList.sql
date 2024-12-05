CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_OfferList`()
BEGIN
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
END
