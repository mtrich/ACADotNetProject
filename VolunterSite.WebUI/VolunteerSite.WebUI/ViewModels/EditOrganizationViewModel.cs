using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VolunteerSite.WebUI.ViewModels
{
    public class EditOrganizationViewModel
    {
        [DataType(DataType.Text)]
        public string CompanyName { get; set; }
        [DataType(DataType.Text)]
        public string Address { get; set; }
        [DataType(DataType.Text)]
        public string City { get; set; }
        [DataType(DataType.Text)]
        public string State { get; set; }
        [DataType(DataType.Text)]
        public string Email { get; set; }
        [DataType(DataType.Text)]
        public string PhoneNumber { get; set; }

        public IFormFile Image { get; set; }
    }
}
