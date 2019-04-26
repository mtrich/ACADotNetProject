using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolunteerSite.Domain.Models;

namespace VolunteerSite.WebUI.ViewModels
{
    public class CreateVolunteerViewModel
    {
        public Volunteer Volunteer { get; set; }

        public IFormFile Image { get; set; }
    }
}
