﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolunteerSite.Domain.Models
{
    public class JobListing
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PositionsAvailable { get; set; }
        public string Description { get; set; }
        public string TypeOfJob { get; set; }
        public DateTime Date { get; set; }

        public string OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}
