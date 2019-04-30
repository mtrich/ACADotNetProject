using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VolunteerSite.WebUI.ViewModels
{
    public class RegisterViewModel
    {
        [EmailAddress, Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [DataType(DataType.Password), Required]
        public string Password { get; set; }
        [DataType(DataType.Password), Compare("Password", ErrorMessage = "Password does not match!"), Required]
        public string ConfirmedPassword { get; set; }
        [Required, Display(Name = "Select a Role")]
        public string Role { get; set; }
        public SelectList Roles { get; set; }
    }
}
