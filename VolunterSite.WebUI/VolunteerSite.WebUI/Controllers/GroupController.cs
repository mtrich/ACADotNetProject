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
using VolunteerSite.Data.Context;

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

        public IActionResult BrowseGroups(BrowseGroupsViewModel vm)
        {
            var userId = _userManager.GetUserId(User);
            Volunteer volunteer = _volunteerService.GetByUserId(userId);
            IEnumerable<GroupMember> userGroupMembers = _GroupMemberService.GetAllByVolunteerId(volunteer.Id);
            vm.Groups = _volunteerGroupService.GetAll();
            List<VolunteerGroup> alteredList = new List<VolunteerGroup>();
            List<VolunteerGroup> groupsToRemove = new List<VolunteerGroup>();
            foreach (var groupMember in userGroupMembers)
            {
                groupsToRemove.Add(_volunteerGroupService.GetById(groupMember.VolunteerGroupId));
            }
            foreach(var g in vm.Groups)
            {
                alteredList.Add(g);
                if(g.GroupAdminId == userId)
                {
                    alteredList.Remove(g);
                }
            }
            foreach(var r in groupsToRemove)
            { 
                foreach(var g in vm.Groups)
                {
                    if(g.Id == r.Id)
                    {
                        alteredList.Remove(g);
                    }
                }
            }
            vm.Groups = alteredList;
            return View(vm);
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

            GroupMember groupMember = new GroupMember
            {
                FirstName = volunteer.FirstName,
                LastName = volunteer.LastName,
                Email = volunteer.Email,
                PhoneNumber = volunteer.PhoneNumber,
                //groupMember.Volunteer = volunteer;
                VolunteerId = volunteer.Id,
                //groupMember.VolunteerGroup = group;
                VolunteerGroupId = group.Id
            };

            _GroupMemberService.Create(groupMember);
            List<GroupMember> groupMembers = new List<GroupMember>();
            groupMembers.Append(groupMember);
            group.GroupMembers = groupMembers;
            _volunteerGroupService.Update(group);
            
            return View("BrowseGroups");
        }

        public IActionResult JoinedGroups(List<VolunteerGroup> joinedGroups)
        {
            //get volunteer
            Volunteer currentUser = _volunteerService.GetByUserId(_userManager.GetUserId(User));
            //get groupmembers by volunteerId
            IEnumerable<GroupMember> userGroupMembers = _GroupMemberService.GetAllByVolunteerId(currentUser.Id);
            //get groups by groupmembers
            foreach(var groupMember in userGroupMembers)
            {
                joinedGroups.Add(_volunteerGroupService.GetById(groupMember.VolunteerGroupId));
            }
            
            return View(joinedGroups);
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

        public IActionResult GroupPage(int id, GroupDetailsViewModel vm)
        {
            vm.Group = _volunteerGroupService.GetById(id);
            vm.GroupMembers = vm.Group.GroupMembers;
            return View(vm);
        }
    }
}