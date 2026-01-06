using System.ComponentModel.DataAnnotations;

namespace Thesis.Models
{
    public class MessageReply
    {
        public int Id { get; set; }

        public int MessageId { get; set; }

        [Required]
        public string SenderName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string SenderEmail { get; set; } = string.Empty;

        [Required]
        public string SenderRole { get; set; } = string.Empty;

        [Required]
        public string ReplyContent { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Message? ParentMessage { get; set; }
    }
}