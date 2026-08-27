using FitCalorie.Models;
using FitCalorie.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FitCalorie.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveRegister(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View("Register", register);
            }


            ApplicationUser applicationUser = new ApplicationUser
            {
                UserName = register.Email,
                Email = register.Email,
                Age = register.Age,
                Height = register.Height,
                Weight = register.Weight
            };

            IdentityResult result = await userManager.CreateAsync(applicationUser, register.Password);

            if (result.Succeeded)
            {

                await signInManager.SignInAsync(applicationUser, isPersistent: false);
                return RedirectToAction("LogMeal", "DailyLogs");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View("Register", register);

        }




        [HttpGet]
        public IActionResult Login(string? Url = null)
        {
            ViewData["ReturnUrl"] = Url;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginView, string? returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View("Login");
            }


            var result = await signInManager.PasswordSignInAsync(
        userName: loginView.Email,
        password: loginView.Password,
        isPersistent: loginView.RememberMe,
        lockoutOnFailure: false);

            if (result.Succeeded)
            {

                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("LogMeal", "DailyLogs");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt. Please check your email or password.");
            return View(loginView);

        }
    }
}
