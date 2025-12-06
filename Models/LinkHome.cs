using System.ComponentModel.DataAnnotations;

namespace linkHomeApp.Models
{

    public class Category
    {
        public int Id { get; set; }
        
        [Required]
        public string? Title { get; set; }

        public List<Link>? Links { get; set; }
    }

    public class Link
    {
        public int Id { get; set; }

        [Required]
        public string? Label { get; set; }

        [Required]
        [Url]
        public string? Url { get; set; }

        public bool Pinned { get; set; }

        // FK to category
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }


}
