using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VolunteerSite.Domain.Models;

namespace VolunteerSite.WebUI.ViewModels
{
    public class JobEditViewModel
    {
        public JobListing JobListing { get; set; }

        [DataType(DataType.Text)]
        public string Address { get; set; }
        [DataType(DataType.Text)]
        public string City { get; set; }
        [DataType(DataType.Text)]
        public string State { get; set; }
        public int PositionsAvailable { get; set; }
        [DataType(DataType.Text)]
        public string Description { get; set; }
        [DataType(DataType.Text)]
        public string TypeOfJob { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
    }
}
