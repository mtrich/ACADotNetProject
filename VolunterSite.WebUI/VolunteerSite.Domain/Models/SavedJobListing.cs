using System;
using System.Collections.Generic;
using System.Text;

namespace VolunteerSite.Domain.Models
{
    public class SavedJobListing
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        //fk
        public int JobListingId { get; set; }
        public JobListing JobListing { get; set; }

        public int VolunteerId { get; set; }
        public Volunteer Volunteer { get; set; }
    }
}
