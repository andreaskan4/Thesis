using System.ComponentModel.DataAnnotations;

namespace Thesis.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = "";

    [Required]
    public string LastName { get; set; } = "";

    [Required]
    public string Email { get; set; } = "";

    [Required]
    public string AcademicId { get; set; } = "";

    [Required]
    public string Password { get; set; } = "";

    [Required]
    public string Role { get; set; } = "";

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}