using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolunteerSite.Data.Context;
using VolunteerSite.Data.Interfaces;
using VolunteerSite.Domain.Models;

namespace VolunteerSite.Data.Implementation.EFCore
{
    public class EFCoreJobListingRepository : IJobListingRepository
    {
        public JobListing Create(JobListing newJobListing)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                context.JobListings.Add(newJobListing);
                context.SaveChanges();

                return newJobListing;
            }
        }

        public bool DeleteById(int jobListingId)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                var jobListingToBeDeleted = GetById(jobListingId);
                context.Remove(jobListingToBeDeleted);
                context.SaveChanges();

                if (GetById(jobListingId) == null)
                {
                    return true;
                }

                return false;
            }
        }


        public JobListing GetById(int jobListingId)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                return context.JobListings.Single(j => j.Id == jobListingId);
            }
        }

        public ICollection<JobListing> GetAll()
        {
            using (var context = new VolunteerSiteDbContext())
            {
                return context.JobListings.AsEnumerable().ToList();
            }
        }

        public ICollection<JobListing> GetByOrganizationId(int organizationId)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                return context.JobListings.Where(j => j.OrganizationId == organizationId).ToList();
            }
        }

        public ICollection<JobListing> GetByTypeOfJob(string typeOfJob)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                return context.JobListings.Where(m => m.TypeOfJob == typeOfJob).ToList();
            }
        }

        public JobListing Update(JobListing updatedJobListing)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                var existingJobListing = GetById(updatedJobListing.Id);
                context.Entry(existingJobListing).CurrentValues.SetValues(updatedJobListing);
                context.SaveChanges();

                return existingJobListing;
            }
        }
    }
}
