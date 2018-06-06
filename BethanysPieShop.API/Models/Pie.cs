using System.ComponentModel.DataAnnotations;

namespace BethanysPieShop.API.Models
{
    public class Pie
    {
        [Key]
        public int PieId { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(500)]
        public string ShortDescription { get; set; }

        [StringLength(2000)]
        public string LongDescription { get; set; }

        [StringLength(500)]
        public string AllergyInformation { get; set; }

        [Required]
        public decimal Price { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string ImageThumbnailUrl { get; set; }
        public bool IsPieOfTheWeek { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
