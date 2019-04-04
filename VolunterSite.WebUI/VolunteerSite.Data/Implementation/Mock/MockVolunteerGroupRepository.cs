using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolunteerSite.Data.Interfaces;
using VolunteerSite.Domain.Models;

namespace VolunteerSite.Data.Implementation.Mock
{
    public class MockVolunteerGroupRepository : IVolunteerGroupRepository
    {
        private List<VolunteerGroup> VolunteerGroups = new List<VolunteerGroup>()
        {
            
        };

        public VolunteerGroup Create(VolunteerGroup newVolunteerGroup)
        {
            newVolunteerGroup.Id = VolunteerGroups.OrderByDescending(v => v.Id).Single().Id + 1;
            VolunteerGroups.Add(newVolunteerGroup);

            return newVolunteerGroup;
        }

        public bool DeleteById(int volunteerGroupId)
        {
            var home = GetById(volunteerGroupId);
            VolunteerGroups.Remove(home);
            return true;
        }

        public VolunteerGroup GetById(int volunteerGroupId)
        {
            return VolunteerGroups.Single(v => v.Id == volunteerGroupId);
        }

        public VolunteerGroup Update(VolunteerGroup updatedVolunteerGroup)
        {
            DeleteById(updatedVolunteerGroup.Id);
            VolunteerGroups.Add(updatedVolunteerGroup);

            return updatedVolunteerGroup;
        }
    }
}
