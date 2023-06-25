using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitHelper.Data;
using FitHelper.Models;
using System.Security.Claims;

namespace FitHelper.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Profile
        public IActionResult Index()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = _context.ProfileDetails.Where(t => t.UserId == userId).ToList();
            return View(user);
        } 

        // GET: Profile/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Profile/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Age,Height,Weight,Image,calorie_goal,water_goal,step_goal")] ProfileDetails profileDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profileDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", profileDetails.UserId);
            return View(profileDetails);
        }

        // GET: Profile/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProfileDetails == null)
            {
                return NotFound();
            }

            var profileDetails = await _context.ProfileDetails.FindAsync(id);
            if (profileDetails == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", profileDetails.UserId);
            return View(profileDetails);
        }

        // POST: Profile/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Age,Height,Weight,Image,calorie_goal,water_goal,step_goal")] ProfileDetails profileDetails)
        {
            if (id != profileDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profileDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfileDetailsExists(profileDetails.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", profileDetails.UserId);
            return View(profileDetails);
        }

        // GET: Profile/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProfileDetails == null)
            {
                return NotFound();
            }

            var profileDetails = await _context.ProfileDetails
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profileDetails == null)
            {
                return NotFound();
            }

            return View(profileDetails);
        }

        // POST: Profile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProfileDetails == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProfileDetails'  is null.");
            }
            var profileDetails = await _context.ProfileDetails.FindAsync(id);
            if (profileDetails != null)
            {
                _context.ProfileDetails.Remove(profileDetails);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfileDetailsExists(int id)
        {
          return (_context.ProfileDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
