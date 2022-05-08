START TRANSACTION;

ALTER TABLE `Budgets` DROP INDEX `IX_Budgets_user_id`;

ALTER TABLE `Budgets` ADD `Name` varchar(255) CHARACTER SET utf8mb4 NULL;

CREATE UNIQUE INDEX `IX_Budgets_user_id_Name` ON `Budgets` (`user_id`, `Name`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220508105914_BudgetName', '6.0.3');

COMMIT;


alter table budgets modify Name varchar(255) null after user_id;

alter table budgets modify update_date datetime(6) not null after Name;

