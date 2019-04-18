using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolunteerSite.Data.Interfaces;
using VolunteerSite.Domain.Models;

namespace VolunteerSite.Data.Implementation.Mock
{
    class MockJobListingRepository : IJobListingRepository
    {
        private readonly List<JobListing> JobListings = new List<JobListing>()
        {

        };

        public JobListing GetById(int jobListingId)
        {
            return JobListings.Single(j => j.Id == jobListingId);
        }

        public ICollection<JobListing> GetByOrganizationId(int organizationId)
        {
            return JobListings.FindAll(j => j.OrganizationId == organizationId);
        }

        public ICollection<JobListing> GetByTypeOfJob(string typeOfJob)
        {
            return JobListings.FindAll(j => j.TypeOfJob == typeOfJob);
        }

        public JobListing Create(JobListing newJobListing)
        {
            newJobListing.Id = JobListings.OrderByDescending(j => j.Id).Single().Id + 1;
            JobListings.Add(newJobListing);

            return newJobListing;
        }

        public JobListing Update(JobListing updatedJobListing)
        {
            DeleteById(updatedJobListing.Id); // delete the existing home
            JobListings.Add(updatedJobListing);

            return updatedJobListing;
        }

        public bool DeleteById(int jobListingId)
        {
            var JobListing = GetById(jobListingId);
            JobListings.Remove(JobListing);
            return true;
        }
    }
}
