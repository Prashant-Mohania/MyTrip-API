CREATE DEFINER=`root`@`localhost` FUNCTION `CheckOfferValid`(_productid VARCHAR(100), _count INT) RETURNS json
    DETERMINISTIC
BEGIN
    DECLARE result JSON;
    SELECT 
        MAX( 
            CASE 
                WHEN current_date() BETWEEN DATE(offer.`FromDate`) AND DATE(offer.`ToDate`)
                     AND CONVERT(_count, UNSIGNED INTEGER) >= CONVERT(offer.`eligibilityQty`, UNSIGNED INTEGER)
                     AND EXISTS (
                         SELECT 1 
                         FROM `offerproduct` op 
                         WHERE op.`offer_id` = offer.`id` 
                         AND op.`product_id` = pl.`pk_product_id`
                     )
                THEN 
                    JSON_OBJECT(
                        'offerid', offer.`id`, 
                        'offername', offer.`name`, 
                        'offeredproducts', FLOOR(offer.`offerQty` * (FLOOR( _count / offer.`eligibilityQty`)))
                    )
                ELSE NULL
            END
        ) INTO result
    FROM 
        `productlist` pl  
        LEFT JOIN `offerproduct` op ON op.`product_id` = pl.`pk_product_id`
        LEFT JOIN `offer` offer ON op.`offer_id` = offer.`id`
    WHERE 
    pl.`ItemCode` = _productid;
	
    RETURN result;
END