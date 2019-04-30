using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolunteerSite.Data.Interfaces;
using VolunteerSite.Domain.Models;

namespace VolunteerSite.Data.Implementation.Mock
{
    class MockVolunteerRepository : IVolunteerRepository
    {
        private List<Volunteer> Volunteers = new List<Volunteer>()
        {

        };

        public Volunteer Create(Volunteer newVolunteer)
        {
            newVolunteer.Id = Volunteers.OrderByDescending(h => h.Id).Single().Id + 1;
            Volunteers.Add(newVolunteer);

            return newVolunteer;
        }

        public bool DeleteById(int volunteerId)
        {
            var home = GetById(volunteerId);
            Volunteers.Remove(home);
            return true;
        }

        public Volunteer GetById(int volunteerId)
        {
            return Volunteers.Single(h => h.Id == volunteerId);
        }

        public Volunteer Update(Volunteer updatedVolunteer)
        {
            DeleteById(updatedVolunteer.Id);
            Volunteers.Add(updatedVolunteer);

            return updatedVolunteer;
        }
    }
}
