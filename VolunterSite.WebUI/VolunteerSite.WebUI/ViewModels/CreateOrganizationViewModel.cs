using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VolunteerSite.Domain.Models;

namespace VolunteerSite.WebUI.ViewModels
{
    public class CreateOrganizationViewModel
    {
        public Organization Organization { get; set; }
        public IFormFile Image { get; set; }
    }
}
