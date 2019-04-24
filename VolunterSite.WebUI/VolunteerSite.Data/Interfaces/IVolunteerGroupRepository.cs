using System;
using System.Collections.Generic;
using System.Text;
using VolunteerSite.Domain.Models;

namespace VolunteerSite.Data.Interfaces
{
    public interface IVolunteerGroupRepository
    {
        //Read
        VolunteerGroup GetById(int volunteerGroupId);

        IEnumerable<VolunteerGroup> GetByAdminId(string adminId);

        ICollection<VolunteerGroup> GetAll();

        // Create
        VolunteerGroup Create(VolunteerGroup newVolunteerGroup);

        //Update
        VolunteerGroup Update(VolunteerGroup updatedVolunteerGroup);

        //Delete
        bool DeleteById(int volunteerGroupId);
    }
}
