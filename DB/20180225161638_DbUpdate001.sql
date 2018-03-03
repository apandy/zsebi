USE `zsebi`;

CREATE TABLE `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `articles` (
    `ID` int NOT NULL AUTO_INCREMENT,
    `Excerpt` longtext,
    `HtmlBody` longtext,
    `MoreInfoUrl` longtext,
    `PublishDate` datetime(6) NOT NULL,
    `ThumbnailfileName` longtext,
    `Title` longtext,
    CONSTRAINT `PK_articles` PRIMARY KEY (`ID`)
);

CREATE TABLE `team` (
    `id` int NOT NULL AUTO_INCREMENT,
    `callsign` longtext,
    `email` longtext,
    `image` longtext,
    `name` longtext,
    `post` longtext,
    `status` longtext,
    `subsystem` longtext,
    `system` longtext,
    CONSTRAINT `PK_team` PRIMARY KEY (`id`)
);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20180225161638_DbUpdate001', '2.0.0-rtm-26452');