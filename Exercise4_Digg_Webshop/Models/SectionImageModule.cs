using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercise4_Digg_Webshop.Models
{
    public class SectionImageModule
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Style { get; set; }
        

        public ICollection<Image> Images { get; set; }

    }
}
