using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetApp.Database.Migrations
{
    public partial class BudgetName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Budgets_user_id",
                table: "Budgets");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Budgets",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_user_id_Name",
                table: "Budgets",
                columns: new[] { "user_id", "Name" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Budgets_user_id_Name",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Budgets");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_user_id",
                table: "Budgets",
                column: "user_id");
        }
    }
}
