using System;
using System.Collections.Generic;
using System.Text;

namespace VolunteerSite.Domain.Models
{
    public class Volunteer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string SkillsAndExperience { get; set; } 

        // Navigation Collection
        public IEnumerable<VolunteerGroup> VolunteerGroups { get; set; }
    }
}
