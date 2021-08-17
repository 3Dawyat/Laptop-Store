using Book.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
namespace Book.Controllers
{
    public class UsersController : Controller
    {
        UserManager<AplicationUser> userManager;
        SignInManager<AplicationUser> signmanager;
        public UsersController(UserManager<AplicationUser> manager, SignInManager<AplicationUser> signInManager)
        {
            userManager = manager;
            signmanager = signInManager;
        }
        public IActionResult Login(string ReturnUrl)
        {
            return View(new UsersModel()
            {
                ReturnUrl = ReturnUrl
            }); ;
        }
        public async Task<IActionResult> LogOut()
        {
            await signmanager.SignOutAsync();
            return Redirect("~/");
        }
        [HttpPost]
        public async Task<IActionResult> Loging(UsersModel model)
        {
            var result = await signmanager.PasswordSignInAsync(model.Email, model.Password, true, false);
            if (string.IsNullOrEmpty(model.ReturnUrl))
                model.ReturnUrl = "~/";
            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl);
            }
            else
            {
                return View("Login", model);
            }
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UsersModel model)
        {
            var user = new AplicationUser()
            {
                Email = model.Email,
                FullName = model.FullName,
                UserName = model.Email,
                Pass = model.Password
            };
            if (string.IsNullOrEmpty(model.ReturnUrl))
                model.ReturnUrl = "~/";
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl);
            }
            else
            {
                return View("Login", model);
            }

        }
    }
}
