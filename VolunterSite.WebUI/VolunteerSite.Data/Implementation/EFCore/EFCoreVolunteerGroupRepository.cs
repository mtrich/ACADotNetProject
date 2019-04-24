using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolunteerSite.Data.Context;
using VolunteerSite.Data.Interfaces;
using VolunteerSite.Domain.Models;

namespace VolunteerSite.Data.Implementation.EFCore
{
    public class EFCoreVolunteerGroupRepository : IVolunteerGroupRepository
    {
        public VolunteerGroup Create(VolunteerGroup newVolunteerGroup)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                context.VolunteerGroups.Add(newVolunteerGroup);
                context.SaveChanges();

                return newVolunteerGroup;
            }
        }

        public bool DeleteById(int volunteerGroupId)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                var volunteerGroupToBeDeleted = GetById(volunteerGroupId);
                context.Remove(volunteerGroupToBeDeleted);
                context.SaveChanges();

                if (GetById(volunteerGroupId) == null)
                {
                    return true;
                }

                return false;
            }
        }

        public VolunteerGroup GetById(int volunteerGroupId)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                
                return context.VolunteerGroups.Single(v => v.Id == volunteerGroupId);
            }
        }

        public ICollection<VolunteerGroup> GetAll()
        {
            using (var context = new VolunteerSiteDbContext())
            {

                return context.VolunteerGroups.AsEnumerable().ToList();
            }
        }

        public IEnumerable<VolunteerGroup> GetByAdminId(string adminId)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                IEnumerable<VolunteerGroup> returnedGroups = context.VolunteerGroups.AsEnumerable().TakeWhile(g => g.GroupAdminId == adminId).ToList();
                return returnedGroups;
            }
        }

        public VolunteerGroup Update(VolunteerGroup updatedVolunteerGroup)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                var existingVolunteerGroup = GetById(updatedVolunteerGroup.Id);
                context.Entry(existingVolunteerGroup).CurrentValues.SetValues(updatedVolunteerGroup);
                context.SaveChanges();

                return existingVolunteerGroup;
            }
        }
    }
}
