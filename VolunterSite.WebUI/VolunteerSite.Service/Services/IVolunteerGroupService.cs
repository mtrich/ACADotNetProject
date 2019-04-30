using System;
using System.Collections.Generic;
using System.Text;
using VolunteerSite.Domain.Models;
using VolunteerSite.Data.Interfaces;

namespace VolunteerSite.Service.Services
{
    public interface IVolunteerGroupService
    {
        VolunteerGroup GetById(int volunteerGroupId);
        VolunteerGroup Create(VolunteerGroup newVolunteerGroup);
        VolunteerGroup Update(VolunteerGroup updatedVolunteerGroup);
        bool DeleteById(int volunteerGroupId);
    }
    public class VolunteerGroupService : IVolunteerGroupService
    {
        private readonly IVolunteerGroupRepository _volunteerGroupRepository;

        public VolunteerGroupService(IVolunteerGroupRepository volunteerGroupRepository)
        {
            _volunteerGroupRepository = volunteerGroupRepository;
        }
        public VolunteerGroup Create(VolunteerGroup newVolunteerGroup)
        {
            return _volunteerGroupRepository.Create(newVolunteerGroup);
        }

        public bool DeleteById(int volunteerGroupId)
        {
            return _volunteerGroupRepository.DeleteById(volunteerGroupId);
        }

        public VolunteerGroup GetById(int volunteerGroupId)
        {
            return _volunteerGroupRepository.GetById(volunteerGroupId);
        }

        public VolunteerGroup Update(VolunteerGroup updatedVolunteerGroup)
        {
            return _volunteerGroupRepository.Update(updatedVolunteerGroup);
        }
    }
}
