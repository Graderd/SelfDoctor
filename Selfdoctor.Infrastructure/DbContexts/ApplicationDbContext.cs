using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Selfdoctor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selfdoctor.Infrastructure.DbContexts
{
    public class ApplicationDbContext: IdentityDbContext<User,Role,int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)  
        {

        }

        public DbSet<BreastCancerDiagnostic> BreastCancerDiagnostics { get; set; }
        public DbSet<BreastCancerDiagnosis> BreastCancerDiagnoses { get; set; }
        public DbSet<DiabetesDiagnostic> DiabetesDiagnostics { get; set;}
        public DbSet<Gender> Genders { get; set; }
        public DbSet<HepatitiscCategory> HepatitiscCategories { get;set; }
        public DbSet<HepatitiscDiagnostic> HepatitiscDiagnostics { get;set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("Users");
            builder.Entity<Role>().ToTable("Roles");

            FillGenders(builder);
            FillHepatitisCCategories(builder);
            FillBreastCancerDiagnosis(builder);
        }

        private void FillGenders(ModelBuilder builder)
        {
            var genders = new List<Gender>()
            {
                new Gender()
                {
                    Id = 1,
                    Description = "m"
                },
                new Gender()
                {
                    Id = 2,
                    Description = "f"
                }
            };

            builder.Entity<Gender>().HasData(genders);
        }

        private void FillHepatitisCCategories(ModelBuilder builder)
        {
            var hepatitisCCategories = new List<HepatitiscCategory>()
            {
                new HepatitiscCategory()
                {
                    Id = 1,
                    Description = "0=Blood Donor"
                },
                new HepatitiscCategory()
                {
                    Id = 2,
                    Description = "0s=suspect Blood Donor"
                },
                new HepatitiscCategory()
                {
                    Id = 3,
                    Description = "1=Hepatitis"
                },
                new HepatitiscCategory()
                {
                    Id = 4,
                    Description = "2=Fibrosis"
                },
                new HepatitiscCategory()
                {
                    Id = 5,
                    Description = "3=Cirrhosis"
                }
            };

            builder.Entity<HepatitiscCategory>().HasData(hepatitisCCategories);
        }

        private void FillBreastCancerDiagnosis(ModelBuilder builder)
        {
            var breastCancerDiagnoses = new List<BreastCancerDiagnosis>()
            {
                new BreastCancerDiagnosis()
                {
                    Id = 1,
                    Code = "M",
                    Description = "Maligno",
                },
                new BreastCancerDiagnosis()
                {
                    Id = 2,
                    Code = "B",
                    Description = "Benigno"
                }
            };

            builder.Entity<BreastCancerDiagnosis>().HasData(breastCancerDiagnoses);
        }
    }
}
