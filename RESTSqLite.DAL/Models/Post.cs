using System.ComponentModel.DataAnnotations;

namespace RESTSqLite.DAL.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Title { get; set; }

        [Required]
        public string SubTitle { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
