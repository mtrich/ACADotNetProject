using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace VolunteerSite.Domain.Models
{
    public class AppUser : IdentityUser
    {
        //Navigation Properties 
        public Volunteer Volunteer { get; set; }
        public Organization Organization { get; set; }
        public ICollection<VolunteerGroup> VolunteerGroups { get; set; } //Volunteer Group Admin
        public ICollection<JobListing> JobListings { get; set; }
    }
}
