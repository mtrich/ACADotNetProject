using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolunteerSite.Domain.Models;

namespace VolunteerSite.WebUI.ViewModels
{
    public class VolunteerHomeViewModel
    {
        public Volunteer Volunteer { get; set; }
        public List<VolunteerGroup> Groups { get; set; }
        public List<JobListing> JobListings { get; set; }
    }
}
