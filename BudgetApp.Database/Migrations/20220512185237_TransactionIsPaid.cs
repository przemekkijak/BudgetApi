using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetApp.Database.Migrations
{
    public partial class TransactionIsPaid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Budgets_budget_id",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "update_date",
                table: "Users",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "Users",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Transactions",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "update_date",
                table: "Transactions",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "Transactions",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "budget_id",
                table: "Transactions",
                newName: "BudgetId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_budget_id",
                table: "Transactions",
                newName: "IX_Transactions_BudgetId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Budgets",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "update_date",
                table: "Budgets",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "Budgets",
                newName: "CreateDate");

            migrationBuilder.RenameIndex(
                name: "IX_Budgets_user_id_Name",
                table: "Budgets",
                newName: "IX_Budgets_UserId_Name");

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Transactions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDate",
                table: "Transactions",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Budgets_BudgetId",
                table: "Transactions",
                column: "BudgetId",
                principalTable: "Budgets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Budgets_BudgetId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "PaymentDate",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Users",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Users",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Transactions",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Transactions",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Transactions",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "BudgetId",
                table: "Transactions",
                newName: "budget_id");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_BudgetId",
                table: "Transactions",
                newName: "IX_Transactions_budget_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Budgets",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Budgets",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Budgets",
                newName: "create_date");

            migrationBuilder.RenameIndex(
                name: "IX_Budgets_UserId_Name",
                table: "Budgets",
                newName: "IX_Budgets_user_id_Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Budgets_budget_id",
                table: "Transactions",
                column: "budget_id",
                principalTable: "Budgets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
