CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE IF NOT EXISTS `Budgets` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `user_id` int NOT NULL,
    `create_date` datetime(6) NOT NULL,
    `update_date` datetime(6) NOT NULL,
    CONSTRAINT `PK_Budgets` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE IF NOT EXISTS `Users` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `Phone` longtext CHARACTER SET utf8mb4 NULL,
    `create_date` datetime(6) NOT NULL,
    `update_date` datetime(6) NOT NULL,
    CONSTRAINT `PK_Users` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE IF NOT EXISTS `Transactions` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `user_id` int NOT NULL,
    `budget_id` int NOT NULL,
    `Amount` decimal(65,30) NOT NULL,
    `Description` longtext CHARACTER SET utf8mb4 NULL,
    `create_date` datetime(6) NOT NULL,
    `update_date` datetime(6) NOT NULL,
    CONSTRAINT `PK_Transactions` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Transactions_Budgets_budget_id` FOREIGN KEY (`budget_id`) REFERENCES `Budgets` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE INDEX `IX_Budgets_user_id` ON `Budgets` (`user_id`);

CREATE INDEX `IX_Transactions_budget_id` ON `Transactions` (`budget_id`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220410120936_initial', '6.0.3');

COMMIT;

START TRANSACTION;

ALTER TABLE `Users` RENAME COLUMN `Name` TO `Password`;

ALTER TABLE `Users` ADD `Email` longtext CHARACTER SET utf8mb4 NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220508104753_NewUsers', '6.0.3');

COMMIT;


