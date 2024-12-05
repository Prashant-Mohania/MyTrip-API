SET SQL_SAFE_UPDATES = 0;
UPDATE zeelab.productlist SET prod_images=null;
SET SQL_SAFE_UPDATES = 1;



SET SQL_SAFE_UPDATES = 0;
UPDATE zeelab.productlist SET prod_images = CONCAT(ItemCode,'.jpg') ;
SET SQL_SAFE_UPDATES = 1;