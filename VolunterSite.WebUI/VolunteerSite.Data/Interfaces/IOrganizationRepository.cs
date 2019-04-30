using System;
using System.Collections.Generic;
using System.Text;
using VolunteerSite.Domain.Models;

namespace VolunteerSite.Data.Interfaces
{
    public interface IOrganizationRepository
    {
        //Read
        Organization GetById(int organizationId);

        // Create
        Organization Create(Organization newOrganization);

        //Update
        Organization Update(Organization updatedOrganization);

        //Delete
        bool DeleteById(int organizationId);
    }
}
