using AimAnchor.Controllers;
using AimAnchor.Data;
using AimAnchor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace TestingAimAnchor
{
    [TestClass]
    public class GoalSetControllerTests
    {
        ApplicationDbContext _context;
        GoalSetsController controller;


        [TestInitialize]
        public void testInitialize()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _context = new ApplicationDbContext(options);

            var goalset = new GoalSet {Id=01,Title="GoalSet 1",UserEmail="admin@gc.ca", StartDate=DateTime.UtcNow ,EndDate = new DateTime(2023,12,9,14,30,0) };

            _context.GoalSets.Add(goalset);

            goalset = new GoalSet
            {
                Id = 2,
                UserEmail = "user2@example.com",
                Title = "Learning Goals",
                StartDate = new DateTime(2023, 2, 1),
                EndDate = new DateTime(2023, 7, 1),
                Photo = "photo2.jpg"
            };

            _context.GoalSets.Add(goalset);

            goalset = new GoalSet
            {
                Id = 3,
                UserEmail = "user3@example.com",
                Title = "Travel Goals",
                StartDate = new DateTime(2023, 3, 1),
                EndDate = new DateTime(2023, 8, 1),
                Photo = "photo3.jpg"
            };
            _context.GoalSets.Add(goalset);

            _context.SaveChanges();

            controller = new GoalSetsController(_context);

            // this code snipped it used to mock the User.Identity.Name Attribute 
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "admin@gc.ca"),
                // other required claims
            }, "mock"));

            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };



        }


        [TestMethod]
        public void IndexReturnsView()
        {

            var result = (ViewResult) controller.Index().Result;

            Assert.AreEqual("Index", result.ViewName);
        }

        #region "Edit"

        [TestMethod]
        public void Edit_GET_ReturnsView()
        {
            var result = (ViewResult)controller.Edit(1).Result;

            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]

        public void Edit_GET_ReturnsGoalSet()
        {
            var result = (ViewResult)controller.Edit(1).Result;

            var model = result.Model;

            Assert.AreEqual(_context.GoalSets.Find(1), model);
        }

        [TestMethod]
        public void Edit_GET_InvalidId()
        {
            var result = (ViewResult)controller.Edit(100).Result;

            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void Edit_POST_RedirectsToIndex()
        {
            GoalSet goalset = _context.GoalSets.Find(1);

            goalset.Title = "Edited Title";

            var result = controller.Edit(1,goalset,null,null).Result;

            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));

            var redirect = (RedirectToActionResult)result;

            Assert.AreEqual("Index", redirect.ActionName);
        }

        [TestMethod]

        public void Edit_POST_EditsData()
        {
            GoalSet goalSet = _context.GoalSets.Find(1);
            goalSet.Title = "Title edited";
            goalSet.EndDate = DateTime.Now;

            controller.Edit(3, goalSet, null,null) ;

            Assert.AreEqual(_context.GoalSets.Find(1).Title, "Title edited");

        }
        #endregion

        #region "Delete"
        [TestMethod]
        public void Delete_GET_returnsView()
        {
            var result = (ViewResult)controller.Delete(1).Result;

            Assert.AreEqual("Delete", result.ViewName);
        }

        [TestMethod]
        public void DeleteConfirmedRemovesGoalset()
        {
            controller.DeleteConfirmed(1);
            
            Assert.IsNull(_context.GoalSets.Find(1));

        }

        [TestMethod]
        public void DeleteConfirmedRedirectsToIndex()
        {
            // to be implement
           
        }

        [TestMethod]
        public void DeleteConfirmedInvalidIdReturnsProblem()
        {
            // to be implemented
        }
        
        #endregion



    }
}