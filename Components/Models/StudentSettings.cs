using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Thesis.Models
{
    public class StudentSettings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }

        public string? ProfilePicture { get; set; }
        public string? Bio { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string TimeZone { get; set; } = "UTC";

        public int MaxFileSizeMB { get; set; } = 10;
        public string AllowedFileTypes { get; set; } = "jpg,jpeg,png,gif";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [ForeignKey(nameof(StudentId))]
        public User? Student { get; set; }
    }
}