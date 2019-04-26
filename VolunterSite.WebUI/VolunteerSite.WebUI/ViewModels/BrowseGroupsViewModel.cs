using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolunteerSite.Domain.Models;

namespace VolunteerSite.WebUI.ViewModels
{
    public class BrowseGroupsViewModel
    {
        public ICollection<VolunteerGroup> Groups { get; set; }
        public IEnumerable<GroupMember> GroupMembers { get; set; }
    }
}
