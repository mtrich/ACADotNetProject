using System;
using System.Collections.Generic;
using System.Text;
using VolunteerSite.Domain.Models;

namespace VolunteerSite.Data.Interfaces
{
    public interface IVolunteerRepository
    {
        //Read
        Volunteer GetById(int volunteerId);

        // Create
        Volunteer Create(Volunteer newVolunteer);

        //Update
        Volunteer Update(Volunteer updatedVolunteer);

        //Delete
        bool DeleteById(int volunteerId);
    }
}
