﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolunteerSite.Domain.Models;

namespace VolunteerSite.WebUI.ViewModels
{
    public class JobDetailsViewModel
    {
        public JobListing JobListing { get; set; }
        public Organization Organization { get; set; }
    }
}