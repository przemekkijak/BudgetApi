using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetApp.Database.Migrations
{
    public partial class BudgetIsDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Budgets",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Budgets");
        }
    }
}
