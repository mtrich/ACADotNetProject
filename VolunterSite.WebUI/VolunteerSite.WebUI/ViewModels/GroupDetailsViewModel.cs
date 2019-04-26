using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolunteerSite.Domain.Models;

namespace VolunteerSite.WebUI.ViewModels
{
    public class GroupDetailsViewModel
    {
        public VolunteerGroup Group { get; set; }
        public IEnumerable<GroupMember> GroupMembers { get; set; }
    }
}
