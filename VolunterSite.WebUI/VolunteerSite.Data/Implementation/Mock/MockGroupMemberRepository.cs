using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolunteerSite.Data.Interfaces;
using VolunteerSite.Domain.Models;

namespace VolunteerSite.Data.Implementation.Mock
{
    public class MockGroupMemberRepository : IGroupMemberRepository
    {
        private List<GroupMember> GroupMembers = new List<GroupMember>()
        {
            
        };

        public GroupMember GetById(int groupMemberId)
        {
            return GroupMembers.Single(g => g.Id == groupMemberId);
        }

        public GroupMember Create(GroupMember newHome)
        {
            newHome.Id = GroupMembers.OrderByDescending(g => g.Id).Single().Id + 1;
            GroupMembers.Add(newHome);

            return newHome;
        }

        public GroupMember Update(GroupMember updatedGroupMember)
        {
            DeleteById(updatedGroupMember.Id); // delete the existing home
            GroupMembers.Add(updatedGroupMember);

            return updatedGroupMember;
        }

        public bool DeleteById(int groupMemberId)
        {
            var GroupMember = GetById(groupMemberId);
            GroupMembers.Remove(GroupMember);
            return true;
        }

        public ICollection<GroupMember> GetByGroupId(string volunteerGroupId)
        {
            return GroupMembers.FindAll(m => m.VolunteerGroupId == volunteerGroupId);
        }
    }
}
