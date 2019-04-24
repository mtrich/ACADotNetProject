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

        public IActionResult Index()
        {
            var volunteerId = _userManager.GetUserId(User);

            Volunteer volunteer = _volunteerService.GetByUserId(volunteerId);
            return View(volunteer);
        }

        [HttpGet]
        public IActionResult CreateProfile() => View();
        [HttpPost]
        public IActionResult CreateProfile(VolunteerEditViewModel vm)
        {
            Volunteer newVolunteer = vm.Volunteer;

            newVolunteer.UserId = _userManager.GetUserId(User);
            
            _volunteerService.Create(newVolunteer);

            return RedirectToAction("Index","Volunteer");
        }

        public IActionResult Profile()
        {
            var userId = _userManager.GetUserId(User);
            Volunteer currentVolunteer = _volunteerService.GetByUserId(userId);
            return View(currentVolunteer);
        }

        [HttpGet]
        public IActionResult EditProfile(int Id) {
            var model = _volunteerService.GetById(Id);

            return View(model);
        }

        [HttpPost]
        public IActionResult EditProfile(int Id, VolunteerEditViewModel input)
        {
            var volunteer = _volunteerService.GetById(Id);
            volunteer.FirstName = input.FirstName;
            volunteer.LastName = input.LastName;
            volunteer.Email = input.Email;
            volunteer.PhoneNumber = input.PhoneNumber;
            volunteer.SkillsAndExperience = input.SkillsAndExperience;
            if (volunteer != null && ModelState.IsValid)
            {
                _volunteerService.Update(volunteer);
               return RedirectToAction("Profile", new { id = volunteer.Id });
            }
            return View(volunteer);
        }
   
        public IActionResult JobList()
        {
            ICollection<JobListing> jobListings = _jobListingService.GetAll();
            return View(jobListings);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            JobListing detailedJobListing = _jobListingService.GetById(id);
            return View(detailedJobListing);
        }

        [HttpPost]
        public IActionResult Details(JobListing detailedJobListing)
        {

            return RedirectToAction("Index", "Home");
        }

        //[HttpPost]
        //public IActionResult JoinJob(JoinJobViewModel vm)
        //{
        //    JobListing selectedjobListing = vm.JobListing;
        //    Volunteer currentUser = _volunteerService.GetByUserId(_userManager.GetUserId(User));
        //    selectedjobListing.Volunteers.Add(currentUser);

        //    return View();
        //}
    }
}