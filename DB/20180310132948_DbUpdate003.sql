USE `zsebi`;

ALTER TABLE `Articles` ADD `Url` varchar(50);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180310132948_DbUpdate003', '2.0.0-rtm-26452');