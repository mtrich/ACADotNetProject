using System;
using System.Collections.Generic;
using System.Text;

namespace VolunteerSite.Domain.Models
{
    public class GroupMember
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int TotalHours { get; set; }

        //foreign Key
        public string VolunteerGroupId { get; set; }
        public VolunteerGroup VolunteerGroup { get; set; }
    }
}
