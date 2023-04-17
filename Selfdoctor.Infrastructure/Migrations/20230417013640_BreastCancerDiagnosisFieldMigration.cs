using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Selfdoctor.Infrastructure.Migrations
{
    public partial class BreastCancerDiagnosisFieldMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BreaastCancerDiagnosisId",
                table: "BreastCancerDiagnostics");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BreaastCancerDiagnosisId",
                table: "BreastCancerDiagnostics",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
