using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolunteerSite.Data.Interfaces;
using VolunteerSite.Domain.Models;

namespace VolunteerSite.Data.Implementation.Mock
{
    class MockOrganizationRepository : IOrganizationRepository
    {
        private List<Organization> Organizations = new List<Organization>()
        {
            
        };

        public Organization Create(Organization newOrganization)
        {
            newOrganization.Id = Organizations.OrderByDescending(h => h.Id).Single().Id + 1;
            Organizations.Add(newOrganization);

            return newOrganization;
        }

        public bool DeleteById(int organizationId)
        {
            var organization = GetById(organizationId);
            Organizations.Remove(organization);
            return true;
        }

        public Organization GetById(int organizationId)
        {
            return Organizations.Single(h => h.Id == organizationId);
        }

        public Organization GetByAdminId(string adminId)
        {
            return Organizations.Single(o => o.OrganizationAdminId == adminId);
        }

        public Organization Update(Organization updatedOrganization)
        {
            DeleteById(updatedOrganization.Id);
            Organizations.Add(updatedOrganization);

            return updatedOrganization;
        }
    }
}
