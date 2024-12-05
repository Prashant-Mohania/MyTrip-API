alter table zeelab.zeeorder_track  add  SAPAPIResponses longtext;

ALTER TABLE zeelab.zeeorder_track ADD COLUMN SAPOrderStatusId INT NOT NULL;
SET FOREIGN_KEY_CHECKS=0;
ALTER TABLE zeelab.zeeorder_track ADD CONSTRAINT fk_saporder FOREIGN KEY (SAPOrderStatusId) REFERENCES zeelab.sapordersstatuses(id);
SET FOREIGN_KEY_CHECKS=1;