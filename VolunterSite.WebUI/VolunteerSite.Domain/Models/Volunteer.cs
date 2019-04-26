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
        public string ProfileImageURL { get; set; }

        //fk
        public string UserId { get; set; }
        public AppUser User { get; set; }

        // Navigation Collection

        public ICollection<SavedJobListing> SavedJobListings { get; set; }

        public ICollection<VolunteerGroup> VolunteerGroups { get; set; }
    }
}
