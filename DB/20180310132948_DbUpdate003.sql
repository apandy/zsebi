USE `zsebi`;

ALTER TABLE `Articles` MODIFY COLUMN `Title` varchar(100) NULL;
ALTER TABLE `Articles` ALTER COLUMN `Title` DROP DEFAULT;
ALTER TABLE `Articles` ADD `Url` varchar(100);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180310132948_DbUpdate003', '2.0.0-rtm-26452');