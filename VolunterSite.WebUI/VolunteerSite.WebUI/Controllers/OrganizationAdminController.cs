using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VolunteerSite.Domain.Models;
using VolunteerSite.Service.Services;
using VolunteerSite.WebUI.ViewModels;

namespace VolunteerSite.WebUI.Controllers
{
    [Authorize(Roles = "OrganizationAdmin")]
    public class OrganizationAdminController : Controller
    {
        private readonly IJobListingService _jobListingService;
        private readonly ISavedJobListingService _savedJobListingService;
        private readonly IVolunteerService _volunteerService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IOrganizationService _organizationService;
        private readonly IHostingEnvironment _environment;

        public OrganizationAdminController (IJobListingService jobListingService,
            ISavedJobListingService savedJobListingService,
            IVolunteerService volunteerService,
            UserManager<AppUser> userManager,
            IOrganizationService organizationService,
            IHostingEnvironment environment)
        {
            _jobListingService = jobListingService;
            _savedJobListingService = savedJobListingService;
            _volunteerService = volunteerService;
            _userManager = userManager;
            _organizationService = organizationService;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var adminId = _userManager.GetUserId(User);

            Organization organization = _organizationService.GetByAdminId(adminId);
            //var jobListing = _jobListingService.GetById(1);
            return View(organization);
        }

        public IActionResult List()
        {
            var adminId = _userManager.GetUserId(User);

            Organization organization = _organizationService.GetByAdminId(adminId);

            var jobListings = _jobListingService.GetByOrganizationId(organization.Id);

            return View(jobListings);
        }

        public IActionResult SignedVolunteers(int id, List<Volunteer> volunteers)
        {
            IEnumerable <SavedJobListing> signedVolunteers = _savedJobListingService.GetByJobListingId(id);
            foreach(var volunteer in signedVolunteers)
            {
                volunteers.Add(_volunteerService.GetById(volunteer.VolunteerId));
            }

            return View(volunteers);
        }

        public IActionResult VolunteerProfile(int id)
        {
            Volunteer viewedVolunteer = _volunteerService.GetById(id);
            return View(viewedVolunteer);
        }

        [HttpGet]
        public IActionResult CreateOrg() => View();

        [HttpPost]
        public IActionResult CreateOrg(CreateOrganizationViewModel vm)
        {
            Organization newOrganization = vm.Organization;
            IFormFile image = vm.Image;

            if(image != null && image.Length > 0)
            {
                // _environment.WebRootPath --> ~/wwwroot/images/Organization
                string storageFolder = Path.Combine(_environment.WebRootPath,"images/organization");

                string newImageName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(image.FileName)}";

                // ~/wwwroot/images/home/GUID.jpg
                string fullPath = Path.Combine(storageFolder, newImageName);

                using (var stream = new FileStream(fullPath,FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                // append new image location to newHome
                newOrganization.LogoImageURL = $"/images/Organization/{newImageName}";
            }

            // Add the Admin
            newOrganization.OrganizationAdminId = _userManager.GetUserId(User);

            // save newOrganization
            _organizationService.Create(newOrganization);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditOrg()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditOrg(EditOrganizationViewModel input)
        {
            var organization = _organizationService.GetByAdminId(_userManager.GetUserId(User));
            
            IFormFile image = input.Image;

            if (image != null && image.Length > 0)
            {
                // _environment.WebRootPath --> ~/wwwroot/images/Organization
                string storageFolder = Path.Combine(_environment.WebRootPath, "images/organization");

                string newImageName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(image.FileName)}";

                // ~/wwwroot/images/home/GUID.jpg
                string fullPath = Path.Combine(storageFolder, newImageName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                // append new image location to newHome
                organization.LogoImageURL = $"/images/Organization/{newImageName}";
            }

            organization.CompanyName = input.CompanyName;
            organization.Address = input.Address;
            organization.City = input.City;
            organization.State = input.State;
            organization.Email = input.Email;
            organization.PhoneNumber = input.PhoneNumber;

            _organizationService.Update(organization);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateJob() => View();
        [HttpPost]
        public IActionResult CreateJob(CreateJobViewModel vm)
        {
            var adminId = _userManager.GetUserId(User);
            var newJobListing = vm.JobListing;
            Organization organization = _organizationService.GetByAdminId(adminId);
            newJobListing.OrganizationId = organization.Id;

            _jobListingService.Create(newJobListing);
            

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult EditJob(int Id)
        {
            var model = _jobListingService.GetById(Id);

            return View(model);
        }

        [HttpPost]
        public IActionResult EditJob(int Id, JobEditViewModel input)
        {
            var jobListing = _jobListingService.GetById(Id);
            jobListing.Address = input.Address;
            jobListing.City = input.City;
            jobListing.State = input.State;
            jobListing.PositionsAvailable = input.PositionsAvailable;
            jobListing.Description = input.Description;
            jobListing.TypeOfJob = input.TypeOfJob;
            jobListing.Date = input.Date;
            if (jobListing != null && ModelState.IsValid)
            {
                _jobListingService.Update(jobListing);
                return RedirectToAction("List", "OrganizationAdmin");
            }
            return View(jobListing);
        }

        [HttpGet]
        public IActionResult DeleteJob(int Id)
        {
            var model = _jobListingService.GetById(Id);
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteJob(int Id, JobEditViewModel input)
        {
            var jobListing = _jobListingService.GetById(Id);
            if (jobListing != null && ModelState.IsValid)
            {
                _jobListingService.DeleteById(Id);
                return RedirectToAction("List", "OrganizationAdmin");
            }
            return View();
        }
    }
}