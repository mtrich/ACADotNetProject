using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace VolunteerSite.Domain.Models
{
    public class AppUser : IdentityUser
    {
        //All Users
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Volunteers
        public string SkillsAndExperience { get; set; }

        //Navigation Properties 
        public Organization Organizations { get; set; }
        public ICollection<VolunteerGroup> VolunteerGroups { get; set; } //Volunteer Group Admin
    }
}
