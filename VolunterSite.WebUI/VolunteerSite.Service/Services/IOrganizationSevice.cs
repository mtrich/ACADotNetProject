using System;
using System.Collections.Generic;
using System.Text;
using VolunteerSite.Domain.Models;
using VolunteerSite.Data.Interfaces;

namespace VolunteerSite.Service.Services
{
    public interface IOrganizationService
    {
        Organization GetById(int organizationId);
        Organization Create(Organization newOrganization);
        Organization Update(Organization updatedOrganization);
        bool DeleteById(int organizationId);
    }

    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationService(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public Organization Create(Organization newOrganization)
        {
            return _organizationRepository.Create(newOrganization);
        }

        public bool DeleteById(int organizationId)
        {
            return _organizationRepository.DeleteById(organizationId);
        }

        public Organization GetById(int organizationId)
        {
            return _organizationRepository.GetById(organizationId);
        }

        public Organization Update(Organization updatedOrganization)
        {
            return _organizationRepository.Update(updatedOrganization);
        }
    }
}
