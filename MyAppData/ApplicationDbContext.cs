using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MyAppData.Models;

namespace MyAppData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) // take the options and pass to the base class constructor (DbContext)
        {

        }
        public DbSet<TrailActions> TrailActions { get; set; }
        public DbSet<AuditTrail> AuditTrail { get; set; }
      
        public DbSet<States> States { get; set; }
        public DbSet<Lga> Lga { get; set; }
     
        public DbSet<MaritalStatus> MaritalStatus { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<ApplicationType> ApplicationType { get; set; }
        public DbSet<ApplicantType> ApplicantType { get; set; }
        public DbSet<LkTrade> LkTrade { get; set; }
        public DbSet<Disability> Disability { get; set; }
        public DbSet<Pictures> Pictures { get; set; }
        public DbSet<Applicants> Applicants { get; set; }
        public DbSet<JWTUser> JWTUser { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("core");

            modelBuilder.Entity<Applicants>()
              .HasIndex(p => new { p.FullName })
              .IsUnique(true);
            modelBuilder.Entity<Applicants>()
.Property(b => b.MiddleName)
.HasDefaultValue("");
            modelBuilder.Entity<Applicants>()
.Property(b => b.NumOfChildren)
.HasDefaultValue(0);
            modelBuilder.Entity<Applicants>()
.Property(b => b.DisabilityId)
.HasDefaultValue(8);
            modelBuilder.Entity<Applicants>()
.Property(b => b.LkTradeId)
.HasDefaultValue(8);
        }
    }
}
