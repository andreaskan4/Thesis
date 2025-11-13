using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Thesis.Models
{
    public enum GradingMethod
    {
        Exam,
        Exercise,
        Both
    }

    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        // Professor teaching this course
        [Required]
        public int ProfessorId { get; set; }

        [ForeignKey(nameof(ProfessorId))]
        public User? Professor { get; set; }

        // Store average grades per semester as JSON
        public string? AverageGradesJson { get; set; }

        [NotMapped]
        public Dictionary<string, double> AverageGrades
        {
            get => string.IsNullOrEmpty(AverageGradesJson)
                ? new Dictionary<string, double>()
                : JsonSerializer.Deserialize<Dictionary<string, double>>(AverageGradesJson) ?? new();
            set => AverageGradesJson = JsonSerializer.Serialize(value);
        }

        // Average difficulty rating (1–5 stars)
        [Range(1, 5)]
        public double DifficultyRating { get; set; } = 3.0;

        // CHANGED: Grading method is now nullable - professors will set this later
        public GradingMethod? GradingMethod { get; set; }  // Removed [Required] and made nullable

        // Update these properties to handle null values
        [NotMapped]
        public string Method => GradingMethod?.ToString() ?? "Not set";

        [NotMapped]
        public string DisplayName => GradingMethod.HasValue ? $"{Name} ({GradingMethod})" : Name;
    }
}