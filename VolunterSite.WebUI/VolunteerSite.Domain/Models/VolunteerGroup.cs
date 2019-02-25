using System;
using System.Collections.Generic;
using System.Text;

namespace VolunteerSite.Domain.Models
{
    public class VolunteerGroup
    {
        public int Id { get; set; }
        public string GroupName { get; set; }

        public string GroupOwnerId { get; set; }
        public Volunteer GroupOwner { get; set; }

        public IEnumerable<GroupMember> GroupMembers { get; set; }
    }
}
