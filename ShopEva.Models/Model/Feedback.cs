
using ShopEva.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEva.Models.Model
{
    [Table("Feedbacks")]
    public class Feedback : Auditable
    {
        [Key]
        [Required]
        public Guid ID { get; set; }
        public Guid ParentID { get; set; }
        [Required]
        public Guid ProductID { get; set; }
        [Required]
        public string UserID { get; set; }
        public string Subject { get; set; } = "Đánh giá sản phẩm";
        [Required]
        public string? Message { get; set; }
        [Required]
        public int Rating { get; set; }
        public int Likes { get; set; } = 0;
        public string? Images { get; set; }
        public string? Videos { get; set; }

    }
}
