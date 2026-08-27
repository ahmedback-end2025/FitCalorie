using FitCalorie.Models;
using FitCalorie.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FitCalorie.Controllers
{
    [Authorize]
    public class DailyLogsController : Controller
    {
        private readonly FoodContext context;
        private readonly UserManager<ApplicationUser> userManager;
        public DailyLogsController(FoodContext _context, UserManager<ApplicationUser> _userManager)
        {
            context = _context;
            userManager = _userManager;
        }


        [HttpGet]
        public async Task<IActionResult> TodayMeals()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null) return Challenge();

            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);

            var logs = await context.DailyLogs
                .Include(d => d.food)
                .Where(d => d.UserId == user.Id && d.CreatedDate >= today && d.CreatedDate < tomorrow)
                .ToListAsync();

            return View(logs);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null) return Challenge();

            var log = await context.DailyLogs
                .FirstOrDefaultAsync(d => d.Id == id && d.UserId == user.Id);

            if (log != null)
            {
                context.DailyLogs.Remove(log);
                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var today = DateTime.Today;

            var currentUser = await userManager.FindByIdAsync(userId);

            double weight = currentUser?.Weight > 0 ? currentUser.Weight : 70;
            double height = currentUser?.Height > 0 ? currentUser.Height : 170;
            int age = currentUser?.Age > 0 ? currentUser.Age : 25;
            string gender = currentUser?.Gender ?? "Male";
            string goal = currentUser?.FitnessGoal ?? "Cutting";

         
            double bmr = (10 * weight) + (6.25 * height) - (5 * age);
            if (gender == "Male")
            {
                bmr += 5;
            }
            else
            {
                bmr -= 161;
            }

            
            double tdee = bmr * 1.375;

            
            double targetCalories = tdee;
            if (goal == "Bulking")
            {
                targetCalories += 400; // فائض للتضخيم
            }
            else
            {
                targetCalories -= 500; // عجز للتنشيف
            }

            
            double targetProtein = weight * 2.2; 
            double targetFats = (targetCalories * 0.25) / 9; 
            double caloriesFromProAndFat = (targetProtein * 4) + (targetFats * 9);
            double targetCarbs = Math.Max(0, (targetCalories - caloriesFromProAndFat) / 4);

            var logs = await context.DailyLogs
                .Include(d => d.food)
                .Where(d => d.UserId == userId && d.CreatedDate.Date == today)
                .ToListAsync();

            var model = new DashboardViewModel();

            model.TargetCalories = Math.Round(targetCalories, 1);
            model.TargetProtein = Math.Round(targetProtein, 1);
            model.TargetCarbs = Math.Round(targetCarbs, 1);
            model.TargetFats = Math.Round(targetFats, 1);

            
            foreach (var item in logs)
            {
                if (item.food != null)
                {
                    var factor = item.AmountGrames / 100.0;
                    var cal = item.food.calorie * factor;
                    var pro = item.food.protein * factor;
                    var carb = item.food.carb * factor;
                    var fat = item.food.fat * factor;

                    model.TotalCalories += cal;
                    model.TotalProtein += pro;
                    model.TotalCarbs += carb;
                    model.TotalFats += fat;

                    model.LoggedMeals.Add(new DailyLogItemViewModel
                    {
                        LogId = item.Id,
                        FoodName = item.food.Name,
                        AmountGrams = item.AmountGrames,
                        Calories = Math.Round(cal, 1),
                        Protein = Math.Round(pro, 1),
                        Carbs = Math.Round(carb, 1),
                        Fats = Math.Round(fat, 1)
                    });
                }
            }

            model.TotalCalories = Math.Round(model.TotalCalories, 1);
            model.TotalProtein = Math.Round(model.TotalProtein, 1);
            model.TotalCarbs = Math.Round(model.TotalCarbs, 1);
            model.TotalFats = Math.Round(model.TotalFats, 1);

            return View(model);
        }

        [HttpGet]
        public IActionResult LogMeal()
        {
            DailyLogsViewModel dialyLogs = new DailyLogsViewModel
            {
                SelectedList = context.FoodItems.Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = $"{s.Name}"
                }
                    ).ToList()
            };

            return View(dialyLogs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveLog([FromBody] DailyLogsViewModel dialy)
        {
            if (!ModelState.IsValid || dialy == null)
            {
                return Json(new { success = false, message = "Please Check Your Inputs And Try Again " });
            }

            if (dialy.AmountGrames <= 0)
            {
                return Json(new { success = false, message = "Amount must be greater than zero." });
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Json(new { success = false, message = "User is not authenticated. Please log in." });
            }

            var food = await context.FoodItems.FindAsync(dialy.FoodId);
            if (food == null)
            {
                return Json(new { success = false, message = "Selected food item does not exist." });
            }

            DailyLog dialyLog = new DailyLog
            {
                UserId = userId,
                FoodId = dialy.FoodId,
                AmountGrames = dialy.AmountGrames
            };

            context.DailyLogs.Add(dialyLog);
            await context.SaveChangesAsync();

            var redirectUrl = Url.Action("Index", "DailyLogs");
            return Json(new { success = true, message = "Meal Logged Successfully", redirectUrl });

        }





    }
}