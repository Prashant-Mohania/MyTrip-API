CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_GetOfferByID`(
    IN p_offerID INT
)
BEGIN
    -- Fetch offer details
    SELECT
        o.`id`,
        o.`name`,
        o.`description`,
        o.`FromDate`,
        o.`ToDate`,
        o.`eligibilityQty`,
        o.`offerQty`,
        o.`status`,
        o.`createdBy`,
        o.`createdDate`,
        o.`updatedBy`,
        o.`updatedDate`,
        p.`product_id`
    FROM
        `offer` o
    LEFT JOIN
        `offerproduct` p ON o.`id` = p.`offer_id`
    WHERE
        o.`id` = p_offerID;
END