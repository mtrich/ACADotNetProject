using Microsoft.EntityFrameworkCore;
using VolunteerSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace VolunteerSite.Data.Context
{
    public class VolunteerSiteDbContext : IdentityDbContext<AppUser>
    {
        //public DbSet<Volunteer> Volunteers { get; set; }


        public DbSet<VolunteerGroup> VolunteerGroups { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<JobListing> JobListings { get; set; }
        public DbSet<GroupMember> GroupMembers  { get; set; }

        // Setting up the provider (SQL Server) and location of the Database
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            // bad way of providing the connection string
            optionBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=volunteersite;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VolunteerGroup>()
                .HasOne(g => g.GroupAdmin)
                .WithMany(u => u.VolunteerGroups)
                .HasForeignKey(g => g.GroupAdminId)
                .HasConstraintName("ForeignKey_VolunteerGroup_AppUser");

            modelBuilder.Entity<Organization>()
                .HasOne(o => o.OrganizationAdmin)
                .WithMany(u => u.Organizations)
                .HasForeignKey(o => o.OrganizationAdminId)
                .HasConstraintName("ForeignKey_Organization_AppUser");
        }   
    }
}
