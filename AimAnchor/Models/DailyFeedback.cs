using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AimAnchor.Models
{
    public class DailyFeedback
    {

       
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int DailyFeedbackId { get; set; }

            [Required]
            [DataType(DataType.Date)]
            public DateTime FeedbackDate { get; set; }

            [Required]
            [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10.")]
            public int GoalAchievementRating { get; set; }

            [StringLength(500, ErrorMessage = "Note cannot be longer than 500 characters.")]
            public string Note { get; set; }

            [Required]
            [StringLength(500, ErrorMessage = "Reflection cannot be longer than 500 characters.")]
            public string Reflection { get; set; }

            [StringLength(500, ErrorMessage = "Improvements cannot be longer than 500 characters.")]
            public string Improvements { get; set; }

        // Foreign Key for GoalSet
        public int GoalSetId { get; set; }

        public GoalSet? GoalSet { get; set; }


    }
}
