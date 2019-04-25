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
        private readonly IGroupMemberService _GroupMemberService;
        private readonly IVolunteerService _volunteerService;

        public GroupController (
            UserManager<AppUser> userManager,
            IVolunteerGroupService volunteerGroupService,
            IGroupMemberService groupMemberService,
            IVolunteerService volunteerService)
        {
            _userManager = userManager;
            _volunteerGroupService = volunteerGroupService;
            _GroupMemberService = groupMemberService;
            _volunteerService = volunteerService;
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

        public IActionResult MyGroups(IEnumerable<VolunteerGroup> UserGroups)
        {
            var adminId = _userManager.GetUserId(User);
            UserGroups = _volunteerGroupService.GetByAdminId(adminId);

            return View(UserGroups);
        }

        [HttpGet]
        public IActionResult EditGroup(int Id)
        {
            var model = _volunteerGroupService.GetById(Id);

            return View(model);
        }

        [HttpPost]
        public IActionResult EditGroup(int Id, GroupEditViewModel input)
        {
            var VolunteerGroup = _volunteerGroupService.GetById(Id);
            VolunteerGroup.GroupName = input.GroupName;
            if (VolunteerGroup != null && ModelState.IsValid)
            {
                _volunteerGroupService.Update(VolunteerGroup);
                return RedirectToAction("MyGroups", "Group");
            }
            return View(VolunteerGroup);
        }

        [HttpGet]
        public IActionResult DeleteGroup(int Id)
        {
            var model = _volunteerGroupService.GetById(Id);
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteGroup(int Id, GroupEditViewModel input)
        {
            var deletedGroup = _volunteerGroupService.GetById(Id);
            if (deletedGroup != null && ModelState.IsValid)
            {
                _volunteerGroupService.DeleteById(Id);
                return RedirectToAction("MyGroups", "Group");
            }
            return View();
        }

        [HttpPost]
        public IActionResult JoinGroup(int Id)
        {
            var group = _volunteerGroupService.GetById(Id);
            var volunteer = _volunteerService.GetByUserId(_userManager.GetUserId(User));
            var groupMember = _GroupMemberService.GetByVolunteerId(volunteer.Id);
            if(groupMember == null)
            {
                groupMember = new GroupMember();
                groupMember.FirstName = volunteer.FirstName;
                groupMember.LastName = volunteer.LastName;
                groupMember.Email = volunteer.Email;
                groupMember.PhoneNumber = volunteer.PhoneNumber;
                groupMember.VolunteerId = volunteer.Id;
                groupMember.VolunteerGroupId = group.Id;
                _GroupMemberService.Create(groupMember);
                group.GroupMembers.Append(groupMember);
            }
            else
            {
                groupMember.VolunteerGroup = group;
                _GroupMemberService.Update(groupMember);
                group.GroupMembers.Append(groupMember);
            }
            
            return View("Index");
        }

        public IActionResult JoinedGroups()
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
            return RedirectToAction("MyGroups");
        }
    }
}