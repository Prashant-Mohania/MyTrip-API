USE zeelab;
Create table `offer`(
	`id` int NOT NULL AUTO_INCREMENT,
	`name` varchar(300) DEFAULT NULL,
	`description` varchar(300) DEFAULT NULL,
	`FromDate` datetime DEFAULT NULL,
	`ToDate` datetime DEFAULT NULL,
	`eligibilityQty` varchar(300) DEFAULT NULL,
	`offerQty` varchar(300) DEFAULT NULL,
    `status` int DEFAULT NULL,
	`createdBy` varchar(10) DEFAULT NULL,
	`createdDate` datetime DEFAULT NULL,
	`updatedBy` varchar(10) DEFAULT NULL,
	`updatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
)
