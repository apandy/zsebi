USE `zsebi`;

CREATE TABLE `Options` (
    `Name` varchar(100) NOT NULL,
    `Value` longtext,
    CONSTRAINT `PK_Options` PRIMARY KEY (`Name`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180303150550_DbUpdate002', '2.0.0-rtm-26452');