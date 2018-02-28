USE `zsebi`;
DELETE FROM `__EFMigrationsHistory`;
INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180225161638_DbUpdate001', '2.0.0-rtm-26452');
DROP TABLE IF EXISTS `aspnetroleclaims`;
DROP TABLE IF EXISTS `aspnetuserroles`;
DROP TABLE IF EXISTS `aspnetroles`;
DROP TABLE IF EXISTS `aspnetuserclaims`;
DROP TABLE IF EXISTS `aspnetuserlogins`;
DROP TABLE IF EXISTS `aspnetusers`;
DROP TABLE IF EXISTS `aspnetusertokens`;
DROP TABLE IF EXISTS  `galeria`;
DROP TABLE IF EXISTS  `news`;
DROP TABLE IF EXISTS  `persons`;
DROP TABLE IF EXISTS  `posts`;
DROP TABLE IF EXISTS  `sponsors`;
DROP TABLE IF EXISTS  `status`;
DROP TABLE IF EXISTS  `subsystems`;
DROP TABLE IF EXISTS  `systems`;