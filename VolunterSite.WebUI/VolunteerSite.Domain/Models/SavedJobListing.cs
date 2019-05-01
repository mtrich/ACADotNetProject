using System;
using System.Collections.Generic;
using System.Text;

namespace VolunteerSite.Domain.Models
{
    public class SavedJobListing
    {
        public int Id { get; set; }
        //fk
        public int VolunteerId { get; set; }
        public Volunteer Volunteer { get; set; }
    }
}
