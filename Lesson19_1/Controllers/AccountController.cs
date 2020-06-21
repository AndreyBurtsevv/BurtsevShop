using Lesson19_1.DataModels;
using Lesson19_1.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson19_1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<UserData> _userManager;
        private readonly SignInManager<UserData> _signInManager;

        public AccountController(UserManager<UserData> userManager, SignInManager<UserData> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegisterView resitrator)
        {
            if (ModelState.IsValid)
            {
                UserData user = new UserData { Email = resitrator.Email, UserName = resitrator.Email };
                var response = await _userManager.CreateAsync(user, resitrator.Password);
                if (response.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return Redirect("~/Home/Index");
                }
                else
                {
                    foreach (var item in response.Errors)
                    {
                        ModelState.AddModelError(string.Empty, item.Description);
                    }
                }
            }
            return View(resitrator);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                UserData user = new UserData { Email = login.Email, UserName = login.Email };
                var response = await _signInManager.PasswordSignInAsync(user.Email, login.Password, true, false);
                if (response.Succeeded)
                {
                    return Redirect("~/Home/Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Incorrect login or password");
                }
            }
            return View(login);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/Home/Index");
        }
    }
}
