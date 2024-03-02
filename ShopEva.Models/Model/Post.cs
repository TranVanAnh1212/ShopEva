using ShopEva.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEva.Models.Model
{
    [Table("Posts")]
    public class Post : Auditable
    {
        [Key]
        [Required]
        public Guid ID { get; set; }
        [Required]
        [MaxLength(501)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }        
        public string? Contents { get; set; }
        [MaxLength(500)]
        public string Alias { get; set; }
        public Guid? CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual PostCategory PostCategory { get; set; }
        public string? Image { get; set; }
        public bool HomeFlag { get; set; }
        public bool HotFlag { get; set; }
        public int ViewCount { get; set; }
        public virtual IEnumerable<PostTag> PostTags { get; set; }
    }
}
