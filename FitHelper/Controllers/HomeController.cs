using FitHelper.Data;
using FitHelper.Models;
using FitHelper.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace FitHelper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            DateTime DateOfNote = DateTime.Today;
            var calories = _context.Calories.Where(t => t.UserId == userId && t.DateOfNote == DateOfNote).ToList();
            var water = _context.Waters.Where(x => x.UserId == userId && x.DateOfNote == DateOfNote).ToList();
            var step = _context.Steps.Where(y => y.UserId == userId && y.DateOfNote == DateOfNote).ToList();
            var totalCalories = calories.Sum(f => f.Cal);
            var totalWater = water.Sum(g => g.Liters);
            var totalStep = step.Sum(h => h.Step);
            var viewModel = new IndicatorViewModel
            {
                Calories = calories,
                TotalCalories = totalCalories,
                Water = water,
                TotalLiters = totalWater,
                Steps = step,
                TotalSteps = totalStep
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}