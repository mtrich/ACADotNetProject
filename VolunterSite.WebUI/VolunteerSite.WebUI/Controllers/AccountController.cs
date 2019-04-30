using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VolunteerSite.Domain.Models;
using VolunteerSite.WebUI.ViewModels;

namespace VolunteerSite.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly List<IdentityRole> _roles;

        public AccountController(UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;

            //here we call this roll table once
            _roles = _roleManager.Roles.ToList();
        }

        [HttpGet]
        public IActionResult Register()
        {
            // populate the Roles before rendering the View
            var vm = new RegisterViewModel
            {
                Roles = new SelectList(_roles)
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                //register User
                var user = new AppUser
                {
                    Email = vm.Email,
                    UserName = vm.Email
                };

                var result = await _userManager.CreateAsync(user, vm.Password);

                if (result.Succeeded)
                {
                    // apply roles to user
                   await  _userManager.AddToRoleAsync(user, vm.Role);

                    await _signInManager.SignInAsync(user, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }
            }

            vm.Roles = new SelectList(_roles);

            return View(vm);
        }

        [HttpGet]
        public IActionResult SignIn() => View();

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(vm.Email, vm.Password, vm.RememberMe, false);

                if (result.Succeeded)
                {
                    // get user
                    var user = await _userManager.FindByEmailAsync(vm.Email);

                    // identify what role has
                    var isVolunteer = await _userManager.IsInRoleAsync(user, "Volunteer");

                    // redirect to the right controller (based on role)
                    if (isVolunteer)
                    {
                        return RedirectToAction("Index", "Volunteer");
                    }
                    else
                    {
                        return RedirectToAction("Index", "OrganizationAdmin");
                    }
                }
                else
                {
                    ModelState.AddModelError("SignIn", "Username or Password incorrect");
                }
            }

            return View(vm);
        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}