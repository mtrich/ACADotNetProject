using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolunteerSite.Domain.Models;

namespace VolunteerSite.WebUI.ViewModels
{
    public class JobListViewModel
    {
        public ICollection<JobListing> JobListings { get; set; }

        public Organization Organization { get; set; }
    }
}
