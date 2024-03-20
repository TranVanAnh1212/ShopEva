
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ShopEva.Models.Model
{
    [Table("ProductDetails" )]
    public class ProductDetail
    {
        [Key]
        [Required]
        public Guid ID { get; set; }
        public Guid ProductID { get; set; }
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
        public string? Colors { get; set; }
        public string? Sizes { get; set; }
        public int Rating { get; set; }
        public Guid? BrandID { get; set; }
        [ForeignKey("BrandID")]
        public virtual Brand Brand { get; set; }
        public string? Material { get; set; }
        public string? Other_Info { get; set; }
    }
}
