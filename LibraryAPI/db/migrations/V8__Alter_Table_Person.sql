﻿ALTER TABLE `person`
	ADD COLUMN `ENABLED` BIT(1) NOT NULL DEFAULT b'1' AFTER `gender`