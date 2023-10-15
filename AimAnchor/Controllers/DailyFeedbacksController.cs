using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AimAnchor.Data;
using AimAnchor.Models;

namespace AimAnchor.Controllers
{
    public class DailyFeedbacksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DailyFeedbacksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DailyFeedbacks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DailyFeedbacks.Include(d => d.GoalSet);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DailyFeedbacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DailyFeedbacks == null)
            {
                return NotFound();
            }

            var dailyFeedback = await _context.DailyFeedbacks
                .Include(d => d.GoalSet)
                .FirstOrDefaultAsync(m => m.DailyFeedbackId == id);
            if (dailyFeedback == null)
            {
                return NotFound();
            }

            return View(dailyFeedback);
        }

        // GET: DailyFeedbacks/Create
        public IActionResult Create()
        {
            ViewData["GoalSetId"] = new SelectList(_context.GoalSets, "Id", "Title");
            return View();
        }

        // POST: DailyFeedbacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DailyFeedbackId,FeedbackDate,GoalAchievementRating,Note,Reflection,Improvements,GoalSetId")] DailyFeedback dailyFeedback)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dailyFeedback);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GoalSetId"] = new SelectList(_context.GoalSets, "Id", "Id", dailyFeedback.GoalSetId);
            return View(dailyFeedback);
        }

        // GET: DailyFeedbacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DailyFeedbacks == null)
            {
                return NotFound();
            }

            var dailyFeedback = await _context.DailyFeedbacks.FindAsync(id);
            if (dailyFeedback == null)
            {
                return NotFound();
            }
            ViewData["GoalSetId"] = new SelectList(_context.GoalSets, "Id", "Title", dailyFeedback.GoalSetId);
            return View(dailyFeedback);
        }

        // POST: DailyFeedbacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DailyFeedbackId,FeedbackDate,GoalAchievementRating,Note,Reflection,Improvements,GoalSetId")] DailyFeedback dailyFeedback)
        {
            if (id != dailyFeedback.DailyFeedbackId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dailyFeedback);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DailyFeedbackExists(dailyFeedback.DailyFeedbackId))
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
            ViewData["GoalSetId"] = new SelectList(_context.GoalSets, "Id", "Id", dailyFeedback.GoalSetId);
            return View(dailyFeedback);
        }

        // GET: DailyFeedbacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DailyFeedbacks == null)
            {
                return NotFound();
            }

            var dailyFeedback = await _context.DailyFeedbacks
                .Include(d => d.GoalSet)
                .FirstOrDefaultAsync(m => m.DailyFeedbackId == id);
            if (dailyFeedback == null)
            {
                return NotFound();
            }

            return View(dailyFeedback);
        }

        // POST: DailyFeedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DailyFeedbacks == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DailyFeedbacks'  is null.");
            }
            var dailyFeedback = await _context.DailyFeedbacks.FindAsync(id);
            if (dailyFeedback != null)
            {
                _context.DailyFeedbacks.Remove(dailyFeedback);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DailyFeedbackExists(int id)
        {
          return (_context.DailyFeedbacks?.Any(e => e.DailyFeedbackId == id)).GetValueOrDefault();
        }
    }
}
