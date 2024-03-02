using ShopEva.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEva.Models.Model
{
    [Table("ProductCategories" )]
    public class ProductCategory : Auditable
    {
        [Key]
        [Required]
        public Guid ID { get; set; }
        [Required]
        [MaxLength(501)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [MaxLength(500)]
        public string? Alias { get; set; }
        public Guid? ParentID { get; set; }
        public string? Image { get; set; }
        public int? DisplayOrder { get; set; }
        public bool HomeFlag { get; set; }
    }
}
