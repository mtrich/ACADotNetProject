using System;
using System.Collections.Generic;
using System.Text;
using VolunteerSite.Domain.Models;
using VolunteerSite.Data.Interfaces;

namespace VolunteerSite.Service.Services
{
    public interface ISavedJobListingService
    {
        SavedJobListing GetById(int SavedJobListingId);
        SavedJobListing GetByVolunteerId(int volunteerId);
        ICollection<SavedJobListing> GetByJobListingId(int SavedJobListingId);
        IEnumerable<SavedJobListing> GetAllByVolunteerId(int volunteerId);
        SavedJobListing Create(SavedJobListing newSavedJobListing);
        SavedJobListing Update(SavedJobListing UpdatedSavedJobListing);
        bool DeleteById(int SavedJobListingId);
    }
    public class SavedJobListingService : ISavedJobListingService
    {
        private readonly ISavedJobListingRepository _savedJobListingRepository;

        public SavedJobListingService(ISavedJobListingRepository savedJobListingRepository)
        {
            _savedJobListingRepository = savedJobListingRepository;
        }

        public SavedJobListing Create(SavedJobListing newSavedJobListing)
        {
            return _savedJobListingRepository.Create(newSavedJobListing);
        }

        public bool DeleteById(int SavedJobListingId)
        {
            return _savedJobListingRepository.DeleteById(SavedJobListingId);
        }

        public IEnumerable<SavedJobListing> GetAllByVolunteerId(int volunteerId)
        {
            return _savedJobListingRepository.GetAllByVolunteerId(volunteerId);
        }

        public ICollection<SavedJobListing> GetByJobListingId(int SavedJobListingId)
        {
            return _savedJobListingRepository.GetByJobListingId(SavedJobListingId);
        }

        public SavedJobListing GetById(int SavedJobListingId)
        {
            return _savedJobListingRepository.GetById(SavedJobListingId);
        }

        public SavedJobListing GetByVolunteerId(int volunteerId)
        {
            return _savedJobListingRepository.GetByVolunteerId(volunteerId);
        }

        public SavedJobListing Update(SavedJobListing UpdatedSavedJobListing)
        {
            return _savedJobListingRepository.Update(UpdatedSavedJobListing);
        }
    }
}
