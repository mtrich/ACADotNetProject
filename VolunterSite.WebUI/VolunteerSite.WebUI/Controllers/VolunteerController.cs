using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VolunteerSite.Data.Context;
using VolunteerSite.Domain.Models;
using VolunteerSite.Service.Services;
using VolunteerSite.WebUI.ViewModels;

namespace VolunteerSite.WebUI.Controllers
{
    
    public class VolunteerController : Controller
    {
        private readonly IVolunteerService _volunteerService;
        private readonly IJobListingService _jobListingService;
        private readonly UserManager<AppUser> _userManager;

        public VolunteerController(IVolunteerService volunteerService,
            IJobListingService jobListingService,
            UserManager<AppUser> userManager)
        {
            _volunteerService = volunteerService;
            _jobListingService = jobListingService;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Profile() => View();
        [HttpPost]
        public IActionResult Profile(VolunteerEditViewModel vm)
        {
            Volunteer newVolunteer = vm.Volunteer;
            newVolunteer = new Volunteer
            {
                UserId = _userManager.GetUserId(User)
            };
            _volunteerService.Create(newVolunteer);

            return RedirectToAction("Index","Home");
        }
   
        public IActionResult JobList()
        {
            ICollection<JobListing> jobListings;
            jobListings = _jobListingService.GetAll();
            return View(jobListings);
        }
        [HttpPost]
        public IActionResult JoinJob(JoinJobViewModel vm)
        {
            JobListing selectedjobListing = vm.JobListing;
            Volunteer currentUser = _volunteerService.GetByUserId(_userManager.GetUserId(User));
            selectedjobListing.Volunteers.Add(currentUser);

            return View();
        }
    }
}