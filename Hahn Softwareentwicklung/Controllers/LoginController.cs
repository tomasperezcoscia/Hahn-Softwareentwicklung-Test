using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hahn_Softwareentwicklung.Entities;
using Microsoft.AspNetCore.Identity;
using Hahn_Softwareentwicklung.Models;

namespace Hahn_Softwareentwicklung.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<Worker> _userManager;
        private readonly SignInManager<Worker> _signInManager;

        public LoginController(UserManager<Worker> userManager, SignInManager<Worker> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var worker = await _userManager.FindByEmailAsync(model.Email);

            if (worker != null)
            {
                var result = await _signInManager.PasswordSignInAsync(worker, model.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Wrong Login Attempt");
                    return View(model);
                }
            }

            ModelState.AddModelError("", "Wrong Login Attempt");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}