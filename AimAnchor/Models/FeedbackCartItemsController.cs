using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AimAnchor.Data;

namespace AimAnchor.Models
{
    public class FeedbackCartItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FeedbackCartItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FeedbackCartItems
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FeedbackCartItems.Include(f => f.Goal);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FeedbackCartItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FeedbackCartItems == null)
            {
                return NotFound();
            }

            var feedbackCartItem = await _context.FeedbackCartItems
                .Include(f => f.Goal)
                .FirstOrDefaultAsync(m => m.FeedbackCartItemId == id);
            if (feedbackCartItem == null)
            {
                return NotFound();
            }

            return View(feedbackCartItem);
        }

        // GET: FeedbackCartItems/Create
        public IActionResult Create()
        {
            ViewData["GoalId"] = new SelectList(_context.Goals, "GoalId", "Title");
            return View();
        }

        // POST: FeedbackCartItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeedbackCartItemId,userSeassionId,GoalAchievementRating,Note,Reflection,Improvements,GoalId")] FeedbackCartItem feedbackCartItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feedbackCartItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GoalId"] = new SelectList(_context.Goals, "GoalId", "Title", feedbackCartItem.GoalId);
            return View(feedbackCartItem);
        }

        // GET: FeedbackCartItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FeedbackCartItems == null)
            {
                return NotFound();
            }

            var feedbackCartItem = await _context.FeedbackCartItems.FindAsync(id);
            if (feedbackCartItem == null)
            {
                return NotFound();
            }
            ViewData["GoalId"] = new SelectList(_context.Goals, "GoalId", "Title", feedbackCartItem.GoalId);
            return View(feedbackCartItem);
        }

        // POST: FeedbackCartItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeedbackCartItemId,userSeassionId,GoalAchievementRating,Note,Reflection,Improvements,GoalId")] FeedbackCartItem feedbackCartItem)
        {
            if (id != feedbackCartItem.FeedbackCartItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feedbackCartItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedbackCartItemExists(feedbackCartItem.FeedbackCartItemId))
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
            ViewData["GoalId"] = new SelectList(_context.Goals, "GoalId", "Title", feedbackCartItem.GoalId);
            return View(feedbackCartItem);
        }

        // GET: FeedbackCartItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FeedbackCartItems == null)
            {
                return NotFound();
            }

            var feedbackCartItem = await _context.FeedbackCartItems
                .Include(f => f.Goal)
                .FirstOrDefaultAsync(m => m.FeedbackCartItemId == id);
            if (feedbackCartItem == null)
            {
                return NotFound();
            }

            return View(feedbackCartItem);
        }

        // POST: FeedbackCartItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FeedbackCartItems == null)
            {
                return Problem("Entity set 'ApplicationDbContext.FeedbackCartItems'  is null.");
            }
            var feedbackCartItem = await _context.FeedbackCartItems.FindAsync(id);
            if (feedbackCartItem != null)
            {
                _context.FeedbackCartItems.Remove(feedbackCartItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeedbackCartItemExists(int id)
        {
          return (_context.FeedbackCartItems?.Any(e => e.FeedbackCartItemId == id)).GetValueOrDefault();
        }
    }
}
