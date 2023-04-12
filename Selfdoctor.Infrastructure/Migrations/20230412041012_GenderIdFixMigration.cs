using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Selfdoctor.Infrastructure.Migrations
{
    public partial class GenderIdFixMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GendenId",
                table: "HepatitiscDiagnostics");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GendenId",
                table: "HepatitiscDiagnostics",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
