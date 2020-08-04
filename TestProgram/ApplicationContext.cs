using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class ApplicationContext : DbContext
    {
        public DbSet<VisitType> VisitTypes { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();

            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=patientfiles;Trusted_Connection=True;");
        }
    }
}
