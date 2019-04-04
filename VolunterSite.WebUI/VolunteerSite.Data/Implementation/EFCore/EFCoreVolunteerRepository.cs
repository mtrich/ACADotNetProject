using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolunteerSite.Data.Context;
using VolunteerSite.Data.Interfaces;
using VolunteerSite.Domain.Models;

namespace VolunteerSite.Data.Implementation.EFCore
{
    public class EFCoreVolunteerRepository : IVolunteerRepository
    {
        public Volunteer Create(Volunteer newVolunteer)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                context.Volunteers.Add(newVolunteer);
                context.SaveChanges();

                return newVolunteer;
            }
        }

        public bool DeleteById(int volunteerId)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                var volunteerToBeDeleted = GetById(volunteerId);
                context.Remove(volunteerToBeDeleted);
                context.SaveChanges();

                if (GetById(volunteerId) == null)
                {
                    return true;
                }

                return false;
            }
        }

        public Volunteer GetById(int volunteerId)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                return context.Volunteers.Single(v => v.Id == volunteerId);
            }
        }

        public Volunteer Update(Volunteer updatedVolunteer)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                var existingVolunteer = GetById(updatedVolunteer.Id);
                context.Entry(existingVolunteer).CurrentValues.SetValues(updatedVolunteer);
                context.SaveChanges();

                return existingVolunteer;
            }
        }
    }
}
