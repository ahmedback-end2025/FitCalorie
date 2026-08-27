using FitCalorie.Models;
using FitCalorie.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
                FullName = register.Name,
                Gender = register.Gender,
                Age = register.Age,
                Height = register.Height,
                Weight = register.Weight,
                FitnessGoal = register.FitnessGoal
            };

            IdentityResult result = await userManager.CreateAsync(applicationUser, register.Password);

            if (result.Succeeded)
            {

                await signInManager.SignInAsync(applicationUser, isPersistent: false);
                return RedirectToAction("Index", "DailyLogs");
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
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginView, string? returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", loginView);
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
                return RedirectToAction("Index", "DailyLogs");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt. Please check your email or password.");
            return View(loginView);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null) return Challenge();

            var model = new ProfileViewModel
            {
                Weight = user.Weight,
                Height = user.Height,
                FitnessGoal = string.IsNullOrEmpty(user.FitnessGoal) ? "Cutting" : user.FitnessGoal
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(ProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.GetUserAsync(User);
            if (user == null) return Challenge();


            user.Weight = model.Weight;
            user.Height = model.Height;
            user.FitnessGoal = model.FitnessGoal;

            var result = await userManager.UpdateAsync(user);

            if (result.Succeeded)
            {

                return RedirectToAction("Index", "DailyLogs");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }
    }
}