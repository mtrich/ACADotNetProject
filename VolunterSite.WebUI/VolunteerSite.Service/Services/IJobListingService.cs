using System;
using System.Collections.Generic;
using System.Text;
using VolunteerSite.Domain.Models;
using VolunteerSite.Data.Interfaces;


namespace VolunteerSite.Service.Services
{
    public interface IJobListingService
    {
        JobListing GetById(int jobListingId);
        ICollection<JobListing> GetByOrganizationId(int organizationId);
        ICollection<JobListing> GetByTypeOfJob(string typeOfJob);
        ICollection<JobListing> GetAll();
        JobListing Create(JobListing newJobListing);
        JobListing Update(JobListing updatedJobListing);
        bool DeleteById(int jobListingId);
    }

    public class JobListingService : IJobListingService
    {
        private readonly IJobListingRepository _jobListingRepository;

        public JobListingService(IJobListingRepository jobListingRepository)
        {
            _jobListingRepository = jobListingRepository;
        }

        public JobListing Create(JobListing newJobListing)
        {
            return _jobListingRepository.Create(newJobListing);
        }

        public bool DeleteById(int jobListingId)
        {
            return _jobListingRepository.DeleteById(jobListingId);
        }

        public JobListing GetById(int jobListingId)
        {
            return _jobListingRepository.GetById(jobListingId);
        }

        public ICollection<JobListing> GetAll()
        {
            return _jobListingRepository.GetAll();
        }

        public ICollection<JobListing> GetByOrganizationId(int organizationId)
        {
            return _jobListingRepository.GetByOrganizationId(organizationId);
        }

        public ICollection<JobListing> GetByTypeOfJob(string typeOfJob)
        {
            return _jobListingRepository.GetByTypeOfJob(typeOfJob);
        }

        public JobListing Update(JobListing updatedJobListing)
        {
            return _jobListingRepository.Update(updatedJobListing);
        }
    }
}

