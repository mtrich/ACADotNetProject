using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VolunteerSite.WebUI.Controllers
{
    [Authorize(Roles = "OrganizationAdmin")]
    public class OrganizationAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}