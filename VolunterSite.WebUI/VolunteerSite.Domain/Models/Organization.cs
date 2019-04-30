﻿using System;
using System.Collections.Generic;
using System.Text;
using VolunterSite.WebUI.Models;

namespace VolunteerSite.Domain.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string OrganizationAdminId { get; set; }
        public AppUser OrganizationAdmin { get; set; }

        public ICollection<JobListing> JobListings { get; set; }
    }
}
