using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AimAnchor.Data;
using AimAnchor.Models;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.AspNetCore.Authorization;

namespace AimAnchor.Controllers
{
    [Authorize]
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
                          View(await _context.GoalSets.Where(g=>g.UserEmail==User.Identity.Name).ToListAsync()) :
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

            if (goalSet == null || goalSet.UserEmail != User.Identity.Name)
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
        public async Task<IActionResult> Create(GoalSet goalSet,IFormFile? Photo)
        {
           
            if (ModelState.IsValid)
            {
                if(Photo != null)
                {
                    var fileName = UploadPhoto(Photo);

                    goalSet.Photo = fileName;
                }
                
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
            if (goalSet == null || goalSet.UserEmail != User.Identity.Name)
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserEmail, Title,StartDate,EndDate,Photo")] GoalSet goalSet,IFormFile? Photo,String? CurrentPhoto)
        {
            if (id != goalSet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {

                    if (Photo != null)
                    {
                        var fileName = UploadPhoto(Photo);

                        goalSet.Photo = fileName;
                    }
                    else
                    {
                        if (CurrentPhoto != null)
                        {
                            goalSet.Photo = CurrentPhoto;

                        }
                    }
                    goalSet.UserEmail = User.Identity.Name;
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
        private string UploadPhoto(IFormFile Photo)
        {
            // get the temp location of uplaod photo
            var filepath = Path.GetTempPath();

            // create a unique name to prevent overwritng using GUID class
            var fileName = Guid.NewGuid() + "-" + Photo.FileName;

            var uploadPath = System.IO.Directory.GetCurrentDirectory() + "\\wwwroot\\img\\goalSet-uploads\\" + fileName;

            using (var stream = new FileStream(uploadPath,FileMode.Create))
            {
                Photo.CopyTo(stream);
            }
            return fileName;
        }
    }
}
