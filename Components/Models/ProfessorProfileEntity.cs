using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thesis.Models
{
    public class ProfessorProfileEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public string? ProfilePicture { get; set; }
        public string? Bio { get; set; }
        public string? Department { get; set; }
        public string? OfficeLocation { get; set; }
        public string? OfficeHours { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Website { get; set; }
        public string? LinkedIn { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation property
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }
    }
}