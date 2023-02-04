using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercise4_Digg_Webshop.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ImageName { get; set; }
        [Required]
        public int Style { get; set; }

        
        public ICollection<SectionImageModule> SectionImageModules { get; set; }
    }
}
