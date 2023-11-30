using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AimAnchor.Models
{
    public class DailyFeedback
    {

       
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int DailyFeedbackId { get; set; }


            public string userEmail;

            [Required]
            [DataType(DataType.Date)]
            public DateTime FeedbackDate { get; set; }


       
        public List<Feedback>? Feedbacks { get; set; }


    }
}
