using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercise4_Digg_Webshop.Models
{
    public class BlogArticle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string? TitleImageUrl { get; set; }

        [Required]
        public int Style { get; set; }
        [Required]
        public ICollection<Section> Sections { get; set; }
    }
}
