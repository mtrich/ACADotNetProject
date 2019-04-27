using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VolunteerSite.Data.Context;
using VolunteerSite.Data.Interfaces;
using VolunteerSite.Domain.Models;

namespace VolunteerSite.Data.Implementation.EFCore
{
    public class EFCoreSavedJobListingRepository : ISavedJobListingRepository
    {
        public SavedJobListing Create(SavedJobListing newSavedJobListing)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                context.SavedJobListings.Add(newSavedJobListing);
                context.SaveChanges();

                return newSavedJobListing;
            }
        }

        public bool DeleteById(int SavedJobListingId)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                var SavedJobListingToBeDeleted = GetById(SavedJobListingId);
                context.Remove(SavedJobListingToBeDeleted);
                context.SaveChanges();

                return true;
            }
        }

        public IEnumerable<SavedJobListing> GetAllByVolunteerId(int volunteerId)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                return context.SavedJobListings.Where(j => j.VolunteerId == volunteerId).ToList();
            }
        }

        public SavedJobListing GetById(int SavedJobListingId)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                return context.SavedJobListings.Single(j => j.Id == SavedJobListingId);
            }
        }

        public ICollection<SavedJobListing> GetByJobListingId(int SavedJobListingId)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                return context.SavedJobListings.Where(j => j.JobListingId == SavedJobListingId).ToList();
            }
        }

        public SavedJobListing GetByVolunteerId(int volunteerId)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                if (context.SavedJobListings.Any(j => j.VolunteerId == volunteerId))
                {
                    var savedJobListing = context.SavedJobListings.Single(j => j.VolunteerId == volunteerId);
                    return savedJobListing;

                }
                else
                {
                    return null;
                }
            }
        }

        public SavedJobListing Update(SavedJobListing UpdatedSavedJobListing)
        {
            using (var context = new VolunteerSiteDbContext())
            {
                var existingSavedJobListing = GetById(UpdatedSavedJobListing.Id);
                existingSavedJobListing.JobListing = UpdatedSavedJobListing.JobListing;
                context.Update(existingSavedJobListing);
                context.SaveChanges();

                return existingSavedJobListing;
            }
        }
    }
}
