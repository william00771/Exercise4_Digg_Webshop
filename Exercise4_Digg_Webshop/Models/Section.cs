using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercise4_Digg_Webshop.Models
{
    public class Section
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        [Required]
        public int Style { get; set; }
        public BlogArticle BlogArticle { get; set; }

        public int? SectionImageModuleId { get; set; }
        public SectionImageModule SectionImageModule { get; set; }
    }
}
