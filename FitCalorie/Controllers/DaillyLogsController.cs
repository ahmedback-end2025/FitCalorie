using FitCalorie.Models;
using FitCalorie.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FitCalorie.Controllers
{
    public class DailyLogsController : Controller
    {
        private readonly FoodContext context;

        public DailyLogsController(FoodContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LogMeal()
        {
            DialyLogsViewModel dialyLogs = new DialyLogsViewModel
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
        public async Task<IActionResult> SaveLog(DialyLogsViewModel dialy)
        {
            if (!ModelState.IsValid || dialy == null)
            {
                return Json(new { success = false, message = "Please Check Your Inputs And Try Again " });
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Json(new { success = false, message = "User is not authenticated. Please log in." });
            }

            var foodId = await context.FoodItems.FindAsync(dialy.FoodId);

            DialyLog dialyLog = new DialyLog
            {
                UserId = userId,
                FoodId = dialy.FoodId,
                AmountGrames = dialy.AmountGrames
            };

            context.DailyLogs.Add(dialyLog);
           await context.SaveChangesAsync();

            var redirectUrl = Url.Action("Index", "DailyLogs");
            return Json(new { success = true, message = "Meal Logged Successfully" });

        }


    }
}
