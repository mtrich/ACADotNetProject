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
    }
}
