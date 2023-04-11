using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Selfdoctor.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BreastCancerDiagnoses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreastCancerDiagnoses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HepatitiscCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HepatitiscCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BreastCancerDiagnostics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreaastCancerDiagnosisId = table.Column<int>(type: "int", nullable: false),
                    RadiusMean = table.Column<float>(type: "real", nullable: false),
                    TextureMean = table.Column<float>(type: "real", nullable: false),
                    PerimeterMean = table.Column<float>(type: "real", nullable: false),
                    AreaMean = table.Column<float>(type: "real", nullable: false),
                    SmoothnessMean = table.Column<float>(type: "real", nullable: false),
                    CompactnessMean = table.Column<float>(type: "real", nullable: false),
                    ConcavityMean = table.Column<float>(type: "real", nullable: false),
                    ConcavePointsMean = table.Column<float>(type: "real", nullable: false),
                    SymmetryMean = table.Column<float>(type: "real", nullable: false),
                    FractalDimensionMean = table.Column<float>(type: "real", nullable: false),
                    RadiusSe = table.Column<float>(type: "real", nullable: false),
                    TextureSe = table.Column<float>(type: "real", nullable: false),
                    PerimeterSe = table.Column<float>(type: "real", nullable: false),
                    AreaSe = table.Column<float>(type: "real", nullable: false),
                    SmoothnessSe = table.Column<float>(type: "real", nullable: false),
                    CompactnessSe = table.Column<float>(type: "real", nullable: false),
                    ConcavitySe = table.Column<float>(type: "real", nullable: false),
                    ConcavePointsSe = table.Column<float>(type: "real", nullable: false),
                    SymmetrySe = table.Column<float>(type: "real", nullable: false),
                    FractalDimensionSe = table.Column<float>(type: "real", nullable: false),
                    RadiusWorst = table.Column<float>(type: "real", nullable: false),
                    TextureWorst = table.Column<float>(type: "real", nullable: false),
                    perimeter_worst = table.Column<float>(type: "real", nullable: false),
                    AreaWorst = table.Column<float>(type: "real", nullable: false),
                    SmoothnessWorst = table.Column<float>(type: "real", nullable: false),
                    CompactnessWorst = table.Column<float>(type: "real", nullable: false),
                    ConcavityWorst = table.Column<float>(type: "real", nullable: false),
                    ConcavePointsWorst = table.Column<float>(type: "real", nullable: false),
                    SymmetryWorst = table.Column<float>(type: "real", nullable: false),
                    FractalDimensionWorst = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BreastCancerDiagnosisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreastCancerDiagnostics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BreastCancerDiagnostics_BreastCancerDiagnoses_BreastCancerDiagnosisId",
                        column: x => x.BreastCancerDiagnosisId,
                        principalTable: "BreastCancerDiagnoses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BreastCancerDiagnostics_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiabetesDiagnostics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pregnancies = table.Column<int>(type: "int", nullable: false),
                    Glucose = table.Column<int>(type: "int", nullable: false),
                    BloodPeresure = table.Column<int>(type: "int", nullable: false),
                    SkinThickness = table.Column<int>(type: "int", nullable: false),
                    Insulin = table.Column<int>(type: "int", nullable: false),
                    BMI = table.Column<float>(type: "real", nullable: false),
                    DiabetesPedigreeFunction = table.Column<float>(type: "real", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Outcome = table.Column<short>(type: "smallint", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiabetesDiagnostics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiabetesDiagnostics_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HepatitiscDiagnostics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    GendenId = table.Column<int>(type: "int", nullable: false),
                    ALB = table.Column<float>(type: "real", nullable: false),
                    ALP = table.Column<float>(type: "real", nullable: false),
                    ALT = table.Column<float>(type: "real", nullable: false),
                    AST = table.Column<float>(type: "real", nullable: false),
                    BIL = table.Column<float>(type: "real", nullable: false),
                    CHE = table.Column<float>(type: "real", nullable: false),
                    CHOL = table.Column<float>(type: "real", nullable: false),
                    CREA = table.Column<int>(type: "int", nullable: false),
                    GGT = table.Column<float>(type: "real", nullable: false),
                    PROT = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HepatitiscDiagnostics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HepatitiscDiagnostics_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HepatitiscDiagnostics_HepatitiscCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "HepatitiscCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HepatitiscDiagnostics_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_BreastCancerDiagnostics_BreastCancerDiagnosisId",
                table: "BreastCancerDiagnostics",
                column: "BreastCancerDiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_BreastCancerDiagnostics_UserId",
                table: "BreastCancerDiagnostics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DiabetesDiagnostics_UserId",
                table: "DiabetesDiagnostics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HepatitiscDiagnostics_CategoryId",
                table: "HepatitiscDiagnostics",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HepatitiscDiagnostics_GenderId",
                table: "HepatitiscDiagnostics",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_HepatitiscDiagnostics_UserId",
                table: "HepatitiscDiagnostics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BreastCancerDiagnostics");

            migrationBuilder.DropTable(
                name: "DiabetesDiagnostics");

            migrationBuilder.DropTable(
                name: "HepatitiscDiagnostics");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "BreastCancerDiagnoses");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "HepatitiscCategories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
