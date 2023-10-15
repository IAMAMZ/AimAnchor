﻿using System;
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
    public class GoalSetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GoalSetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GoalSets
        public async Task<IActionResult> Index()
        {
              return _context.GoalSets != null ? 
                          View(await _context.GoalSets.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.GoalSets'  is null.");
        }

        // GET: GoalSets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GoalSets == null)
            {
                return NotFound();
            }

            var goalSet = await _context.GoalSets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goalSet == null)
            {
                return NotFound();
            }

            return View(goalSet);
        }

        // GET: GoalSets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GoalSets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,StartDate,EndDate,Photo")] GoalSet goalSet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goalSet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(goalSet);
        }

        // GET: GoalSets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GoalSets == null)
            {
                return NotFound();
            }

            var goalSet = await _context.GoalSets.FindAsync(id);
            if (goalSet == null)
            {
                return NotFound();
            }
            return View(goalSet);
        }

        // POST: GoalSets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,StartDate,EndDate,Photo")] GoalSet goalSet)
        {
            if (id != goalSet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goalSet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoalSetExists(goalSet.Id))
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
            return View(goalSet);
        }

        // GET: GoalSets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GoalSets == null)
            {
                return NotFound();
            }

            var goalSet = await _context.GoalSets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goalSet == null)
            {
                return NotFound();
            }

            return View(goalSet);
        }

        // POST: GoalSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GoalSets == null)
            {
                return Problem("Entity set 'ApplicationDbContext.GoalSets'  is null.");
            }
            var goalSet = await _context.GoalSets.FindAsync(id);
            if (goalSet != null)
            {
                _context.GoalSets.Remove(goalSet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoalSetExists(int id)
        {
          return (_context.GoalSets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
