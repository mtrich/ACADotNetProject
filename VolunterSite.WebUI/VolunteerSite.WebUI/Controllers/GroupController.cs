using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VolunteerSite.Data.Interfaces;
using VolunteerSite.Domain.Models;
using VolunteerSite.Service.Services;
using VolunteerSite.WebUI.ViewModels;

namespace VolunteerSite.WebUI.Controllers
{
    public class GroupController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IVolunteerGroupService _volunteerGroupService;

        public GroupController (
            UserManager<AppUser> userManager,
            IVolunteerGroupService volunteerGroupService)
        {
            _userManager = userManager;
            _volunteerGroupService = volunteerGroupService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BrowseGroups()
        {
            ICollection<VolunteerGroup> groups = _volunteerGroupService.GetAll();
            return View(groups);
        }

        public IActionResult MyGroup(IEnumerable<VolunteerGroup> UserGroups)
        {
            var adminId = _userManager.GetUserId(User);
            UserGroups = _volunteerGroupService.GetByAdminId(adminId);

            return View(UserGroups);
        }

        public IActionResult MyGroups()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateGroup() => View();

        [HttpPost]
        public IActionResult CreateGroup(CreateGroupViewModel vm)
        {
            VolunteerGroup newGroup = vm.Group;
            newGroup.GroupAdminId = _userManager.GetUserId(User);
            _volunteerGroupService.Create(newGroup);
            return RedirectToAction("MyGroup");
        }
    }
}