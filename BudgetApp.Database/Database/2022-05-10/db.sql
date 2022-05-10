START TRANSACTION;

ALTER TABLE `Budgets` ADD `IsDefault` tinyint(1) NOT NULL DEFAULT FALSE;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220510155248_BudgetIsDefault', '6.0.3');

COMMIT;

START TRANSACTION;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20220510155528_BudgetIsDefaultNotNullable', '6.0.3');

COMMIT;


