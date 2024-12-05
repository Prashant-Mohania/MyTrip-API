-- before insert into state

ALTER TABLE city DROP CONSTRAINT fk_state;
ALTER TABLE zeeuser_login DROP CONSTRAINT fk_user_state;
ALTER TABLE zonestatemapping DROP CONSTRAINT fk_state_zone;

SET FOREIGN_KEY_CHECKS=0;
ALTER TABLE zeelab.city
ADD CONSTRAINT fk_state
FOREIGN KEY (stateId)
REFERENCES zeelab.state(id);
SET FOREIGN_KEY_CHECKS=1;

SET FOREIGN_KEY_CHECKS=0;
ALTER TABLE zeelab.zeeuser_login
ADD CONSTRAINT fk_user_state
FOREIGN KEY (stateId)
REFERENCES zeelab.state(id);
SET FOREIGN_KEY_CHECKS=1;

SET FOREIGN_KEY_CHECKS=0;
ALTER TABLE zeelab.zonestatemapping
ADD CONSTRAINT fk_state_zone
FOREIGN KEY (stateId)
REFERENCES zeelab.state(id);
SET FOREIGN_KEY_CHECKS=1;