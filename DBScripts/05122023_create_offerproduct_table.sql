USE zeelab;
CREATE TABLE `offerproduct` (
  `id` int NOT NULL AUTO_INCREMENT,
 `offer_id` INT,
    `product_id` INT,
  `status` int DEFAULT NULL,
  `createdBy` varchar(10) DEFAULT NULL,
  `createdDate` datetime DEFAULT NULL,
  `updatedBy` varchar(10) DEFAULT NULL,
  `updatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
    FOREIGN KEY (`offer_id`) REFERENCES `offer`(`id`),
    FOREIGN KEY (`product_id`) REFERENCES `productlist` (`pk_product_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
