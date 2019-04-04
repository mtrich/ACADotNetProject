using System;
using System.Collections.Generic;
using System.Text;
using VolunteerSite.Domain.Models;
using VolunteerSite.Data.Interfaces;

namespace VolunteerSite.Service.Services
{
    public interface IVolunteerService
    {
        Volunteer GetById(int volunteerId);
        Volunteer Create(Volunteer newVolunteer);
        Volunteer Update(Volunteer updatedVolunteer);
        bool DeleteById(int volunteerId);
    }
    public class VolunteerService : IVolunteerService
    {
        private readonly IVolunteerRepository _volunteerRepository;

        public VolunteerService(IVolunteerRepository volunteerRepository)
        {
            _volunteerRepository = volunteerRepository;
        }
        public Volunteer Create(Volunteer newVolunteer)
        {
            return _volunteerRepository.Create(newVolunteer);
        }

        public bool DeleteById(int volunteerId)
        {
            return _volunteerRepository.DeleteById(volunteerId);
        }

        public Volunteer GetById(int volunteerId)
        {
            return _volunteerRepository.GetById(volunteerId);
        }

        public Volunteer Update(Volunteer updatedVolunteer)
        {
            return _volunteerRepository.Update(updatedVolunteer);
        }
    }
}
