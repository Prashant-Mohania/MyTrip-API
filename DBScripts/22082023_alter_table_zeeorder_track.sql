db change for place order:


ALTER TABLE zeelab.zeeorder_track
DROP FOREIGN KEY fk_saporder;

SET FOREIGN_KEY_CHECKS=0;
ALTER TABLE zeelab.zeeorder_track ADD CONSTRAINT fk_SAPOrderStatusId FOREIGN KEY (SAPOrderStatusId) REFERENCES zeelab.saporderstatuses(id);
SET FOREIGN_KEY_CHECKS=1;