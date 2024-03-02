using ShopEva.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ShopEva.Models.Model
{
    [Table("Brands")]
    public class Brand : Auditable
    {
        [Key]
        [Required]
        public Guid ID { get; set; }
        [Column(TypeName = "character varying")]
        public string Name { get; set; }
        [Column(TypeName = "character varying")]
        public string? Logo { get; set; }
    }
}
