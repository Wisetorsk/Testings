using Microsoft.EntityFrameworkCore.Migrations;

namespace TestingDiscordRPGStuff.Migrations
{
    public partial class TestPlayerDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "UserID",
                table: "Players",
                type: "decimal(20,0)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Players");
        }
    }
}
