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

        }
    }
}
