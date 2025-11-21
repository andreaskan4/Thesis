using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thesis.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int ProfessorId { get; set; }

        [Required]
        public string CommentText { get; set; } = string.Empty;

        // EF Core will handle DateTime to SQLite TEXT conversion
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsApproved { get; set; } = true;

        // Navigation properties
        [ForeignKey(nameof(StudentId))]
        public User? Student { get; set; }

        [ForeignKey(nameof(ProfessorId))]
        public User? Professor { get; set; }
    }
}