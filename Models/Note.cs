using System.ComponentModel.DataAnnotations;

namespace StickyNote.Models
{
    public class Note
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
