using System.ComponentModel.DataAnnotations;

namespace Exercise4_Digg_Webshop.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public string? ProductDescription { get; set; }
        [Required]
        public string? ProductCategory { get; set; }
        [Required]
        public string? ImageUrl { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Input Rating Value Between 1 and 5")]
        public int Rating { get; set; }
        [Required]
        public double BasePrice { get; set; }
        public double PromotionPrice { get; set; }
    }
}
