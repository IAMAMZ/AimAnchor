using AimAnchor.Data;
using Microsoft.AspNetCore.Mvc;

namespace AimAnchor.Controllers
{
    public class FeedbackController : Controller
    {

        private readonly ApplicationDbContext _context;

        // constructor using db dependency
        public FeedbackController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            // fetch the goalsets and display them in index
            var goalSets = _context.GoalSets.OrderBy(c => c.Title).ToList();
            return View(goalSets);
        }

        //GET/Feedback/ByGaolSet/{title}
        public IActionResult ByGoalSet(string title)
        {
            if (title == null)
            {
                return RedirectToAction("Index");
            }
            ViewData["GoalSet"] = title;

            var goals = _context.Goals.Where(g=> g.GoalSet.Title == title).OrderBy(g => g.Title).ToList();

            return View(goals);
        }
    }
}
