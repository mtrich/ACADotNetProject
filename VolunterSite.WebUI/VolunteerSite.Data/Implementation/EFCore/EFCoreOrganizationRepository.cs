using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolunteerSite.Data.Context;
using VolunteerSite.Data.Interfaces;
using VolunteerSite.Domain.Models;

namespace VolunteerSite.Data.Implementation.EFCore
{
    public class EFCoreOrganizationRepository : IOrganizationRepository
    {
        public Organization Create(Organization newOrganization)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                context.Organizations.Add(newOrganization);
                context.SaveChanges();

                return newOrganization;
            }
        }

        public bool DeleteById(int organizationId)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                var organizationToBeDeleted = GetById(organizationId);
                context.Remove(organizationToBeDeleted);
                context.SaveChanges();

                if (GetById(organizationId) == null)
                {
                    return true;
                }

                return false;
            }
        }

        public Organization GetById(int organizationId)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                return context.Organizations.Single(o => o.Id == organizationId);
            }
        }

        public Organization GetByAdminId(string adminId)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                return context.Organizations.Single(o => o.OrganizationAdminId == adminId);
            }
        }

        public Organization Update(Organization updatedOrganization)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                var existingOrganization = GetById(updatedOrganization.Id);
                context.Entry(existingOrganization).CurrentValues.SetValues(updatedOrganization);
                context.SaveChanges();

                return existingOrganization;
            }
        }
    }
}
