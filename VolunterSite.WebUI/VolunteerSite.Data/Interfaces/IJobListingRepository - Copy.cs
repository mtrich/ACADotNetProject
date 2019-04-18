using System;
using System.Collections.Generic;
using System.Text;
using VolunteerSite.Domain.Models;

namespace VolunteerSite.Data.Interfaces
{
    public interface IJobListingRepository
    {
        //Read
        JobListing GetById(int jobListingId);
        ICollection<JobListing> GetByOrganizationId(int organizationId);
        ICollection<JobListing> GetByTypeOfJob(string typeOfJob);

        // Create
        JobListing Create(JobListing newJobListing);

        //Update
        JobListing Update(JobListing updatedJobListing);

        //Delete
        bool DeleteById(int jobListingId);
    }
}
