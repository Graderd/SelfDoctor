﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Selfdoctor.Infrastructure.DbContexts;

#nullable disable

namespace Selfdoctor.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Selfdoctor.Domain.Models.BreastCancerDiagnosis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BreastCancerDiagnoses");
                });

            modelBuilder.Entity("Selfdoctor.Domain.Models.BreastCancerDiagnostic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float>("AreaMean")
                        .HasColumnType("real");

                    b.Property<float>("AreaSe")
                        .HasColumnType("real");

                    b.Property<float>("AreaWorst")
                        .HasColumnType("real");

                    b.Property<int>("BreaastCancerDiagnosisId")
                        .HasColumnType("int");

                    b.Property<int>("BreastCancerDiagnosisId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("CompactnessMean")
                        .HasColumnType("real");

                    b.Property<float>("CompactnessSe")
                        .HasColumnType("real");

                    b.Property<float>("CompactnessWorst")
                        .HasColumnType("real");

                    b.Property<float>("ConcavePointsMean")
                        .HasColumnType("real");

                    b.Property<float>("ConcavePointsSe")
                        .HasColumnType("real");

                    b.Property<float>("ConcavePointsWorst")
                        .HasColumnType("real");

                    b.Property<float>("ConcavityMean")
                        .HasColumnType("real");

                    b.Property<float>("ConcavitySe")
                        .HasColumnType("real");

                    b.Property<float>("ConcavityWorst")
                        .HasColumnType("real");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<float>("FractalDimensionMean")
                        .HasColumnType("real");

                    b.Property<float>("FractalDimensionSe")
                        .HasColumnType("real");

                    b.Property<float>("FractalDimensionWorst")
                        .HasColumnType("real");

                    b.Property<float>("PerimeterMean")
                        .HasColumnType("real");

                    b.Property<float>("PerimeterSe")
                        .HasColumnType("real");

                    b.Property<float>("RadiusMean")
                        .HasColumnType("real");

                    b.Property<float>("RadiusSe")
                        .HasColumnType("real");

                    b.Property<float>("RadiusWorst")
                        .HasColumnType("real");

                    b.Property<float>("SmoothnessMean")
                        .HasColumnType("real");

                    b.Property<float>("SmoothnessSe")
                        .HasColumnType("real");

                    b.Property<float>("SmoothnessWorst")
                        .HasColumnType("real");

                    b.Property<float>("SymmetryMean")
                        .HasColumnType("real");

                    b.Property<float>("SymmetrySe")
                        .HasColumnType("real");

                    b.Property<float>("SymmetryWorst")
                        .HasColumnType("real");

                    b.Property<float>("TextureMean")
                        .HasColumnType("real");

                    b.Property<float>("TextureSe")
                        .HasColumnType("real");

                    b.Property<float>("TextureWorst")
                        .HasColumnType("real");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<float>("perimeter_worst")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("BreastCancerDiagnosisId");

                    b.HasIndex("UserId");

                    b.ToTable("BreastCancerDiagnostics");
                });

            modelBuilder.Entity("Selfdoctor.Domain.Models.DiabetesDiagnostic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<float>("BMI")
                        .HasColumnType("real");

                    b.Property<int>("BloodPeresure")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<float>("DiabetesPedigreeFunction")
                        .HasColumnType("real");

                    b.Property<int>("Glucose")
                        .HasColumnType("int");

                    b.Property<int>("Insulin")
                        .HasColumnType("int");

                    b.Property<short>("Outcome")
                        .HasColumnType("smallint");

                    b.Property<int>("Pregnancies")
                        .HasColumnType("int");

                    b.Property<int>("SkinThickness")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("DiabetesDiagnostics");
                });

            modelBuilder.Entity("Selfdoctor.Domain.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("Selfdoctor.Domain.Models.HepatitiscCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HepatitiscCategories");
                });

            modelBuilder.Entity("Selfdoctor.Domain.Models.HepatitiscDiagnostic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float>("ALB")
                        .HasColumnType("real");

                    b.Property<float>("ALP")
                        .HasColumnType("real");

                    b.Property<float>("ALT")
                        .HasColumnType("real");

                    b.Property<float>("AST")
                        .HasColumnType("real");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<float>("BIL")
                        .HasColumnType("real");

                    b.Property<float>("CHE")
                        .HasColumnType("real");

                    b.Property<float>("CHOL")
                        .HasColumnType("real");

                    b.Property<int>("CREA")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<float>("GGT")
                        .HasColumnType("real");

                    b.Property<int>("GendenId")
                        .HasColumnType("int");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<float>("PROT")
                        .HasColumnType("real");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("GenderId");

                    b.HasIndex("UserId");

                    b.ToTable("HepatitiscDiagnostics");
                });

            modelBuilder.Entity("Selfdoctor.Domain.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("Selfdoctor.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Selfdoctor.Domain.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Selfdoctor.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Selfdoctor.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Selfdoctor.Domain.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Selfdoctor.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Selfdoctor.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Selfdoctor.Domain.Models.BreastCancerDiagnostic", b =>
                {
                    b.HasOne("Selfdoctor.Domain.Models.BreastCancerDiagnosis", "BreastCancerDiagnosis")
                        .WithMany("BreastCancerDiagnostics")
                        .HasForeignKey("BreastCancerDiagnosisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Selfdoctor.Domain.Models.User", "User")
                        .WithMany("BreastCancerDiagnostics")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BreastCancerDiagnosis");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Selfdoctor.Domain.Models.DiabetesDiagnostic", b =>
                {
                    b.HasOne("Selfdoctor.Domain.Models.User", "User")
                        .WithMany("DiabetesDiagnostics")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Selfdoctor.Domain.Models.HepatitiscDiagnostic", b =>
                {
                    b.HasOne("Selfdoctor.Domain.Models.HepatitiscCategory", "Category")
                        .WithMany("HepatitiscDiagnostics")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Selfdoctor.Domain.Models.Gender", "Gender")
                        .WithMany("HepatitiscDiagnostics")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Selfdoctor.Domain.Models.User", "User")
                        .WithMany("HepatitiscDiagnostics")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Gender");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Selfdoctor.Domain.Models.BreastCancerDiagnosis", b =>
                {
                    b.Navigation("BreastCancerDiagnostics");
                });

            modelBuilder.Entity("Selfdoctor.Domain.Models.Gender", b =>
                {
                    b.Navigation("HepatitiscDiagnostics");
                });

            modelBuilder.Entity("Selfdoctor.Domain.Models.HepatitiscCategory", b =>
                {
                    b.Navigation("HepatitiscDiagnostics");
                });

            modelBuilder.Entity("Selfdoctor.Domain.Models.User", b =>
                {
                    b.Navigation("BreastCancerDiagnostics");

                    b.Navigation("DiabetesDiagnostics");

                    b.Navigation("HepatitiscDiagnostics");
                });
#pragma warning restore 612, 618
        }
    }
}
