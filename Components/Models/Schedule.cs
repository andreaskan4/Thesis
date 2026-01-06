using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thesis.Models
{
    public class Schedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public string DayOfWeek { get; set; } = "Monday";

        [Required]
        public TimeOnly StartTime { get; set; } = new TimeOnly(9, 0);

        [Required]
        public TimeOnly EndTime { get; set; } = new TimeOnly(10, 30);

        public string Room { get; set; } = "";

        [ForeignKey(nameof(CourseId))]
        public Course? Course { get; set; }
    }
}