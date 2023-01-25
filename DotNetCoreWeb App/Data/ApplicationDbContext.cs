using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DotNetCoreWeb_App.Models;

namespace DotNetCoreWeb_App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DotNetCoreWeb_App.Models.Aliases> Aliases { get; set; }
        public DbSet<DotNetCoreWeb_App.Models.Appeals> Appeals { get; set; }
        public DbSet<DotNetCoreWeb_App.Models.Crime_charges> Crime_charges { get; set; }
        public DbSet<DotNetCoreWeb_App.Models.CrimeCodes> CrimeCodes { get; set; }
        public DbSet<DotNetCoreWeb_App.Models.Crimes> Crimes { get; set; }
        public DbSet<DotNetCoreWeb_App.Models.Criminals> Criminals { get; set; }
        public DbSet<DotNetCoreWeb_App.Models.CriminalsDW> CriminalsDW { get; set; }
        public DbSet<DotNetCoreWeb_App.Models.Officers> Officers { get; set; }
        public DbSet<DotNetCoreWeb_App.Models.ProbationOfficers> ProbationOfficers { get; set; }
        public DbSet<DotNetCoreWeb_App.Models.Sentences> Sentences { get; set; }
        public DbSet<DotNetCoreWeb_App.Models.ProbationContact> ProbationContact { get; set; }
    }
}
