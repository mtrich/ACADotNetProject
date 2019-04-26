using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolunteerSite.Data.Context;
using VolunteerSite.Data.Interfaces;
using VolunteerSite.Domain.Models;

namespace VolunteerSite.Data.Implementation.EFCore
{
    public class EFCoreGroupMemberRepository : IGroupMemberRepository
    {
        public GroupMember Create(GroupMember newGroupMember)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                context.GroupMembers.Add(newGroupMember);
                context.SaveChanges();

                return newGroupMember;
            }
        }

        public bool DeleteById(int groupMemberId)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                var groupMemberToBeDeleted = GetById(groupMemberId);
                context.Remove(groupMemberToBeDeleted);
                context.SaveChanges();

                if (GetById(groupMemberId) == null)
                {
                    return true;
                }

                return false;
            }
        }

        public ICollection<GroupMember> GetByGroupId(int volunteerGroupId)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                return context.GroupMembers.Where(m => m.VolunteerGroupId == volunteerGroupId).ToList();
            }
        }

        public GroupMember GetById(int groupMemberId)
        {
            using (var context = new VolunteerSiteDbContext())
            {

                return context.GroupMembers.Single(m => m.Id == groupMemberId);
            }
        }

        public GroupMember GetByVolunteerId(int volunteerId)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                if(context.GroupMembers.Any(m => m.VolunteerId == volunteerId))
                {
                    var groupMember = context.GroupMembers.Single(m => m.VolunteerId == volunteerId);
                    return groupMember;

                }
                else
                {
                    return null;
                }
            }
        }

        public IEnumerable<GroupMember> GetAllByVolunteerId(int volunteerId)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                return context.GroupMembers.Where(m => m.VolunteerId == volunteerId).ToList();

            }
        }

        public GroupMember Update(GroupMember updatedGroupMember)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                var existingGroupMember = GetById(updatedGroupMember.Id);
                existingGroupMember.VolunteerGroup = updatedGroupMember.VolunteerGroup;
                context.Update(existingGroupMember);
                context.SaveChanges();

                return existingGroupMember;
            }
        }
    }
}
