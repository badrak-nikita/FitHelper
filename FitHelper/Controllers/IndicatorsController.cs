using FitHelper.Data;
using FitHelper.Models;
using FitHelper.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace FitHelper.Controllers
{
    public class IndicatorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IndicatorsController(ApplicationDbContext context)
        {
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

        public IActionResult AddCalorie()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCalorie(Calories calorie)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            DateTime DateOfNote = DateTime.Today;
            if (ModelState.IsValid)
            {
                _context.Add(new Calories
                {
                    Cal = calorie.Cal,
                    UserId = userId,
                    DateOfNote = DateOfNote,
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calorie);
        }

        public IActionResult AddWater()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddWater(Water water)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            DateTime DateOfNote = DateTime.Today;
            if (ModelState.IsValid)
            {
                _context.Add(new Water
                {
                    Liters = water.Liters,
                    UserId = userId,
                    DateOfNote = DateOfNote,
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(water);
        }

        public IActionResult AddStep()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStep(Steps steps)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            DateTime DateOfNote = DateTime.Today;
            if (ModelState.IsValid)
            {
                _context.Add(new Steps
                {
                    Step = steps.Step,
                    UserId = userId,
                    DateOfNote = DateOfNote,
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(steps);
        }
    }
}