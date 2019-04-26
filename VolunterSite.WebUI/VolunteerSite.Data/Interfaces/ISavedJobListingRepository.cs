using System;
using System.Collections.Generic;
using System.Text;
using VolunteerSite.Domain.Models;

namespace VolunteerSite.Data.Interfaces
{
    public interface ISavedJobListingRepository
    {
        //read
        SavedJobListing GetById(int SavedJobListingId);
        SavedJobListing GetByVolunteerId(int volunteerId);
        ICollection<SavedJobListing> GetByJobListingId(int SavedJobListingId);
        IEnumerable<SavedJobListing> GetAllByVolunteerId(int volunteerId);


        //create
        SavedJobListing Create(SavedJobListing newSavedJobListing);

        //Update
        SavedJobListing Update(SavedJobListing UpdatedSavedJobListing);

        //Delete
        bool DeleteById(int SavedJobListingId);
    }
}
