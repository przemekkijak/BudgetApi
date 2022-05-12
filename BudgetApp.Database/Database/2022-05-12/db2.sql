Build started...
Build succeeded.
info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
      Entity Framework Core 6.0.3 initialized 'BudgetContext' using provider 'Pomelo.EntityFrameworkCore.MySql:6.0.1' with options: MigrationsAssembly=BudgetApp.Database ServerVersion 8.0.28-mysql 
CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Budgets` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `user_id` int NOT NULL,
    `create_date` datetime(6) NOT NULL,
    `update_date` datetime(6) NOT NULL,
    CONSTRAINT `PK_Budgets` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Users` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NULL,
    `Phone` longtext CHARACTER SET utf8mb4 NULL,
    `create_date` datetime(6) NOT NULL,
    `update_date` datetime(6) NOT NULL,
    CONSTRAINT `PK_Users` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Transactions` (
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

START TRANSACTION;

ALTER TABLE `Budgets` DROP INDEX `IX_Budgets_user_id`;

ALTER TABLE `Budgets` ADD `Name` varchar(255) CHARACTER SET utf8mb4 NULL;

CREATE UNIQUE INDEX `IX_Budgets_user_id_Name` ON `Budgets` (`user_id`, `Name`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220508105914_BudgetName', '6.0.3');

COMMIT;

START TRANSACTION;

ALTER TABLE `Budgets` ADD `IsDefault` tinyint(1) NOT NULL DEFAULT FALSE;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220510155248_BudgetIsDefault', '6.0.3');

COMMIT;

START TRANSACTION;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220510155528_BudgetIsDefaultNotNullable', '6.0.3');

COMMIT;

START TRANSACTION;

ALTER TABLE `Transactions` DROP FOREIGN KEY `FK_Transactions_Budgets_budget_id`;

ALTER TABLE `Users` RENAME COLUMN `update_date` TO `UpdateDate`;

ALTER TABLE `Users` RENAME COLUMN `create_date` TO `CreateDate`;

ALTER TABLE `Transactions` RENAME COLUMN `user_id` TO `UserId`;

ALTER TABLE `Transactions` RENAME COLUMN `update_date` TO `UpdateDate`;

ALTER TABLE `Transactions` RENAME COLUMN `create_date` TO `CreateDate`;

ALTER TABLE `Transactions` RENAME COLUMN `budget_id` TO `BudgetId`;

ALTER TABLE `Transactions` RENAME INDEX `IX_Transactions_budget_id` TO `IX_Transactions_BudgetId`;

ALTER TABLE `Budgets` RENAME COLUMN `user_id` TO `UserId`;

ALTER TABLE `Budgets` RENAME COLUMN `update_date` TO `UpdateDate`;

ALTER TABLE `Budgets` RENAME COLUMN `create_date` TO `CreateDate`;

ALTER TABLE `Budgets` RENAME INDEX `IX_Budgets_user_id_Name` TO `IX_Budgets_UserId_Name`;

ALTER TABLE `Transactions` ADD `IsPaid` tinyint(1) NOT NULL DEFAULT FALSE;

ALTER TABLE `Transactions` ADD `PaymentDate` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00';

ALTER TABLE `Transactions` ADD CONSTRAINT `FK_Transactions_Budgets_BudgetId` FOREIGN KEY (`BudgetId`) REFERENCES `Budgets` (`Id`) ON DELETE CASCADE;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220512185237_TransactionIsPaid', '6.0.3');

COMMIT;

START TRANSACTION;

ALTER TABLE `Transactions` MODIFY COLUMN `PaymentDate` datetime(6) NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220512185509_TransactionPaymentDateNullable', '6.0.3');

COMMIT;

START TRANSACTION;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220512190927_BudgetTransationRelation', '6.0.3');

COMMIT;


