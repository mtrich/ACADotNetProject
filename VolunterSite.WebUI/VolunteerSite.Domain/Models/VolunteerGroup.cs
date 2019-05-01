using System;
using System.Collections.Generic;
using System.Text;

namespace VolunteerSite.Domain.Models
{
    public class VolunteerGroup
    {
        public int Id { get; set; }
        public string GroupName { get; set; }

        //Foreign Key
        public string GroupAdminId { get; set; }
        public AppUser GroupAdmin { get; set; }

        // Navigation Collection
        public IEnumerable<GroupMember> GroupMembers { get; set; }
    }
}
