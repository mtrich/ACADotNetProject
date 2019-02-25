using System;
using System.Collections.Generic;
using System.Text;
using VolunteerSite.Domain.Models;

namespace VolunteerSite.Data.Interfaces
{
    interface IVolunteerGroupRepository
    {
        //Read
        VolunteerGroup GetById(int volunteerGroupId);

        // Create
        VolunteerGroup Create(VolunteerGroup newVolunteerGroup);

        //Update
        VolunteerGroup Update(VolunteerGroup updatedVolunteerGroup);

        //Delete
        bool DeleteById(int volunteerGroupId);
    }
}
