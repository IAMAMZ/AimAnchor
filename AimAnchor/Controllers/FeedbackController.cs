using AimAnchor.Data;
using AimAnchor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AimAnchor.Controllers
{
    [Authorize]
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
            var goalSets = _context.GoalSets.OrderBy(c => c.Title).Where(c=>c.UserEmail==User.Identity.Name).ToList();
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToCart(int goalId, int feedbackRating,string reflection,string improvments,string notes)
        {
            // if goalId doesn't exist redirect to not found
            var goal = _context.Goals.Find(goalId);

            if (goal == null)
            {
                return NotFound();
            }

            // make a seassion id for the user
            var userId = GetUserId();

            //make a new feedback Cart item object

            var feedbackItem = new FeedbackCartItem
            {
                GoalId = goalId,
                userSessionId = userId,
                GoalAchievementRating = feedbackRating,
                Reflection = reflection,
                Improvements = improvments,
                Note = notes
            };

            _context.FeedbackCartItems.Add(feedbackItem);

            _context.SaveChanges();

            return RedirectToAction("Cart");

        }

        //GET: /cart

        public async Task<IActionResult> Cart()
        {
            var userId = GetUserId();

            return _context.FeedbackCartItems != null ?
                           View(await _context.FeedbackCartItems.Where(c=>c.userSessionId == userId).Include(c=>c.Goal).ToListAsync()) :
                           Problem("Entity set 'ApplicationDbContext.GoalSets'  is null.");
        }

        //GET: /Edit

        public  async Task<IActionResult> Edit( int? id)
        {
            if (id == null || _context.GoalSets == null)
            {
                return NotFound();
            }

            var cartItem = await _context.FeedbackCartItems.FindAsync(id);
            if (cartItem == null)
            {
                return NotFound();
            }
            ViewData["GoalId"] = new SelectList(_context.Goals, "GoalId", "Title", cartItem.GoalId);
          
            return View("EditCartItem",cartItem);
        }

        // POST: Feedback/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeedbackCartItemId,userSessionId,GoalAchievementRating,Note, Reflection,Improvements,GoalId")] FeedbackCartItem cartItem)
        {
            if (id != cartItem.FeedbackCartItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedbackCartItemExists(cartItem.FeedbackCartItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Cart");
            }
            ViewData["GoalId"] = new SelectList(_context.Goals, "GoalId", "Title", cartItem.Goal);
            return View("EditCartItem",cartItem);
        }

        public async Task<IActionResult> Remove(int? id)
        {

            var cartItem = _context.FeedbackCartItems.Find(id);
            if (!(cartItem == null))
            {
                _context.FeedbackCartItems.Remove(cartItem);
                _context.SaveChanges();
            }

            return RedirectToAction("Cart");
        }


        public IActionResult SaveReflections(DateTime date)
        {
            // get all the items associated with the logged in user

            var cartItems = _context.FeedbackCartItems.Where(i => i.userSessionId == HttpContext.Session.GetString("userId"));

            List<Feedback> myFeedbacks = new List<Feedback>();
            // change the feedback cart item to feedbacks

            foreach(var cartItem in cartItems)
            {
                Feedback feedback = new Feedback { 
                    GoalAchievementRating = cartItem.GoalAchievementRating,
                    Note=cartItem.Note,
                    Reflection=cartItem.Reflection,
                    Improvements=cartItem.Improvements,
                    GoalId=cartItem.GoalId,
                };
                myFeedbacks.Add(feedback);
                _context.Feedbacks.Add(feedback);


            }

           


            // create a daily feedback
            DailyFeedback myDailyFeedback = new DailyFeedback { userEmail=User.Identity.Name,FeedbackDate=date,Feedbacks=myFeedbacks};

            _context.DailyFeedbacks.Add(myDailyFeedback);
            _context.SaveChanges();


          /*  foreach (var feedback in myFeedbacks)
            {
                Feedback savefeedback = new Feedback
                {  dailyFeedback = myDailyFeedback,
                    GoalAchievementRating = feedback.GoalAchievementRating,
                    Note = feedback.Note,
                    Reflection = feedback.Reflection,
                    Improvements = feedback.Improvements,
                    GoalId = feedback.GoalId,
                };
                _context.Feedbacks.Add(savefeedback);

            }
            _context.SaveChanges();
         */

            return View("SavedDailyReflections",_context.DailyFeedbacks.Where(f=>f.userEmail==User.Identity.Name).ToList());

        }


        public string GetUserId()
        {
            if(HttpContext.Session.GetString("userId") == null)
            {
                HttpContext.Session.SetString("userId",Guid.NewGuid().ToString());
            }
            return HttpContext.Session.GetString("userId");
        }

        private bool FeedbackCartItemExists(int id)
        {
            return (_context.FeedbackCartItems?.Any(e => e.FeedbackCartItemId == id)).GetValueOrDefault();
        }
    }
}
