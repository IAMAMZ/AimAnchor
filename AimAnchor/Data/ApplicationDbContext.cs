using AimAnchor.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AimAnchor.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {



        }

        //create DbSet CRUD for each model

        public DbSet<GoalSet> GoalSets { get; set; }
        public DbSet<Goal> Goals { get; set; }

        public DbSet<DailyFeedback> DailyFeedbacks { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<FeedbackCartItem> FeedbackCartItems { get; set;}

    }

}