using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Selfdoctor.Infrastructure.Migrations
{
    public partial class BreastCancerDiagnosisMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "BreastCancerDiagnoses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "BreastCancerDiagnoses",
                columns: new[] { "Id", "Code", "Description" },
                values: new object[] { 1, "M", "Maligno" });

            migrationBuilder.InsertData(
                table: "BreastCancerDiagnoses",
                columns: new[] { "Id", "Code", "Description" },
                values: new object[] { 2, "B", "Benigno" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BreastCancerDiagnoses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BreastCancerDiagnoses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Code",
                table: "BreastCancerDiagnoses");
        }
    }
}
