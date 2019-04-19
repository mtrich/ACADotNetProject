using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VolunteerSite.Domain.Models;
using VolunteerSite.Service.Services;

namespace VolunteerSite.WebUI.Controllers
{
    
    public class VolunteerController : Controller
    {
        private readonly IVolunteerService _volunteerService;
        private readonly IJobListingService _jobListingService;

        public VolunteerController(IVolunteerService volunteerService,
            IJobListingService jobListingService)
        {
            _volunteerService = volunteerService;
            _jobListingService = jobListingService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult JobList()
        {
            var jobListings = _jobListingService.GetAll();
            return View(jobListings);
        }
    }
}