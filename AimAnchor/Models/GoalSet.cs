using System.ComponentModel.DataAnnotations;

namespace AimAnchor.Models
{
    public class GoalSet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserEmail {  get; set; }

        public string Title { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? Photo {  get; set; }

        public List<Goal>? Goals { get; set; }

        
    }
}
