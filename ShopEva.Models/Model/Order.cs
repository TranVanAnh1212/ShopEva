using ShopEva.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEva.Models.Model
{
    [Table("Orders")]
    public class Order : Auditable
    {
        [Key]
        [Required]
        public Guid ID { get; set; }
        [Required]
        [MaxLength(501)]
        public string CustomerName { get; set; }
        [Required]
        [MaxLength(501)]
        public string CustomerAddress { get; set; }
        [Required]
        [MaxLength(20)]
        public string CustomerPhone { get; set; }
        [MaxLength(501)]
        public string? CustomerEmail { get; set; }
        [MaxLength(501)]
        public string? CustomerMessage { get; set; }
        [Required]
        [MaxLength(256)]
        public string PaymentMethod { get; set; }
        [MaxLength(256)]
        public string PaymentStatus { get; set; }


    }
}
