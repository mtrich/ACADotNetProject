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
        private readonly IOrganizationService _organizationService;
        private readonly IHostingEnvironment _environment;
        private readonly ISavedJobListingService _savedJobListingService;
        private readonly IGroupMemberService _groupMemberService;
        private readonly IVolunteerGroupService _volunteerGroupService;

        public VolunteerController(IVolunteerService volunteerService,
            IJobListingService jobListingService,
            UserManager<AppUser> userManager,
            IOrganizationService organizationService,
            IHostingEnvironment environment,
            ISavedJobListingService savedJobListingService,
            IGroupMemberService groupMemberService,
            IVolunteerGroupService volunteerGroupService)
        {
            _volunteerService = volunteerService;
            _jobListingService = jobListingService;
            _userManager = userManager;
            _organizationService = organizationService;
            _environment = environment;
            _savedJobListingService = savedJobListingService;
            _groupMemberService = groupMemberService;
            _volunteerGroupService = volunteerGroupService;
        }

        public IActionResult Index(VolunteerHomeViewModel vm)
        {
            var volunteerId = _userManager.GetUserId(User);
            vm.Volunteer = _volunteerService.GetByUserId(volunteerId);
            vm.JobListings = new List<JobListing>();
            vm.Groups = new List<VolunteerGroup>();

            IEnumerable<SavedJobListing> savedJobListings = _savedJobListingService.GetAllByVolunteerId(vm.Volunteer.Id);

            foreach (var jobListing in savedJobListings)
            {
                vm.JobListings.Add(_jobListingService.GetById(jobListing.JobListingId));
            }

            IEnumerable<GroupMember> userGroupMembers = _groupMemberService.GetAllByVolunteerId(vm.Volunteer.Id);

            foreach(var groupMember in userGroupMembers)
            {
                vm.Groups.Add(_volunteerGroupService.GetById(groupMember.VolunteerGroupId));
            }

            return View(vm);
        }

        [HttpGet]
        public IActionResult CreateProfile() => View();
        [HttpPost]
        public IActionResult CreateProfile(CreateVolunteerViewModel vm)
        {
            Volunteer newVolunteer = vm.Volunteer;

            IFormFile image = vm.Image;

            if (image != null && image.Length > 0)
            {
                // _environment.WebRootPath --> ~/wwwroot/images/Organization
                string storageFolder = Path.Combine(_environment.WebRootPath, "images/profile");

                string newImageName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(image.FileName)}";

                // ~/wwwroot/images/home/GUID.jpg
                string fullPath = Path.Combine(storageFolder, newImageName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                // append new image location to newHome
                newVolunteer.ProfileImageURL = $"/images/profile/{newImageName}";
            }

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
        public IActionResult EditProfile() {

            return View();
        }

        [HttpPost]
        public IActionResult EditProfile(VolunteerEditViewModel input)
        {
            var volunteer = _volunteerService.GetByUserId(_userManager.GetUserId(User));

            IFormFile image = input.Image;

            if (image != null && image.Length > 0)
            {
                // _environment.WebRootPath --> ~/wwwroot/images/Organization
                string storageFolder = Path.Combine(_environment.WebRootPath, "images/profile");

                string newImageName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(image.FileName)}";

                // ~/wwwroot/images/home/GUID.jpg
                string fullPath = Path.Combine(storageFolder, newImageName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                // append new image location to newHome
                volunteer.ProfileImageURL = $"/images/profile/{newImageName}";
            }

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
            return View(input);
        }
   
        public IActionResult JobList(JobListViewModel vm)
        {
                List<JobListing> alteredList = new List<JobListing>();
                List<JobListing> jobsToRemove = new List<JobListing>();
            if (User.IsInRole("Volunteer"))
            {
                var userId = _userManager.GetUserId(User);
                Volunteer volunteer = _volunteerService.GetByUserId(userId);
                IEnumerable<SavedJobListing> userJobListings = _savedJobListingService.GetAllByVolunteerId(volunteer.Id);
                vm.JobListings = _jobListingService.GetAll();
                

                foreach (var savedJobListing in userJobListings)
                {
                    jobsToRemove.Add(_jobListingService.GetById(savedJobListing.JobListingId));
                }

                foreach (var j in vm.JobListings)
                {
                    j.Organization = _organizationService.GetById(j.OrganizationId);
                    alteredList.Add(j);
                }
                foreach (var r in jobsToRemove)
                {
                    foreach (var j in vm.JobListings)
                    {
                        if (j.Id == r.Id)
                        {
                            alteredList.Remove(j);
                        }
                    }
                }
                vm.JobListings = alteredList;
                return View(vm);
            }
            else
            {
                vm.JobListings = _jobListingService.GetAll();

                foreach (var j in vm.JobListings)
                {
                    j.Organization = _organizationService.GetById(j.OrganizationId);
                    alteredList.Add(j);
                }
                vm.JobListings = alteredList;
                return View(vm);
            }
        }

        [HttpGet]
        public IActionResult Details(int id, JobDetailsViewModel vm)
        {
            JobListing detailedJobListing = _jobListingService.GetById(id);
            Organization organization = _organizationService.GetById(detailedJobListing.OrganizationId);
            vm.JobListing = detailedJobListing;
            vm.Organization = organization;
            return View(vm);
        }

        [HttpPost]
        public IActionResult Details(JobListing detailedJobListing)
        {

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult JoinJob(int Id)
        {
            var Job = _jobListingService.GetById(Id);
            var volunteer = _volunteerService.GetByUserId(_userManager.GetUserId(User));


            SavedJobListing selectedjobListing = new SavedJobListing
            {
                FirstName = volunteer.FirstName,
                LastName = volunteer.LastName,
                Email = volunteer.Email,
                PhoneNumber = volunteer.PhoneNumber,
                VolunteerId = volunteer.Id,
                JobListingId = Job.Id
            };

            _savedJobListingService.Create(selectedjobListing);
            List<SavedJobListing> savedJobListings = new List<SavedJobListing>();
            savedJobListings.Append(selectedjobListing);
            Job.SignedVolunteers = savedJobListings;
            _jobListingService.Update(Job);

            return RedirectToAction("JobList");
        }

        public IActionResult TrackedJobs(List<JobListing> jobListings)
        {
            //get volunteer
            Volunteer currentUser = _volunteerService.GetByUserId(_userManager.GetUserId(User));

            IEnumerable<SavedJobListing> savedJobListings = _savedJobListingService.GetAllByVolunteerId(currentUser.Id);

            foreach(var jobListing in savedJobListings)
            {
                jobListings.Add(_jobListingService.GetById(jobListing.JobListingId));
            }
            return View(jobListings);
        }

        public IActionResult LeaveJob(int id)
        {
            var volunteer = _volunteerService.GetByUserId(_userManager.GetUserId(User));
            var savedJobs = _savedJobListingService.GetAllByVolunteerId(volunteer.Id);

            foreach(var leftJob in savedJobs)
            {
                if(leftJob.JobListingId == id)
                {
                    _savedJobListingService.DeleteById(leftJob.Id);
                }
            }
            return RedirectToAction("TrackedJobs");
        }
    }
}