using Microsoft.EntityFrameworkCore;
using VolunteerSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace VolunteerSite.Data.Context
{
    public class VolunteerSiteDbContext : DbContext
    {
        public VolunteerSiteDbContext(DbContextOptions<VolunteerSiteDbContext> options): base(options) { }

        public DbSet<Volunteer> Volunteers { get; set; }
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

        //Seeding - populate db with initial data

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
