
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEva.Models.Model
{
    [Table("VisitorStatistic" )]
    public class VisitorStatistic
    {
        [Key]
        [Required]
        public Guid ID { get; set; }
        [Required]
        public DateTime VisitedDate { get; set; }
        [MaxLength(50)]
        public string? IPAddress { get; set; }
    }
}
