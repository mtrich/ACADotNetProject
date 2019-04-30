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
        public ICollection<Organization> Organizations { get; set; } //Organization Admin
        public ICollection<VolunteerGroup> VolunteerGroups { get; set; } //Volunteer Group Admin
    }
}
