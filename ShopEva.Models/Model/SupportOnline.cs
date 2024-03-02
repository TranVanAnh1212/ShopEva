using ShopEva.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEva.Models.Model
{
    [Table("SupportOnlines" )]
    public class SupportOnline : Auditable
    {
        [Key]
        [Required]
        public Guid ID { get; set; }
        [MaxLength(255)]
        public string? Name { get; set; }
        [MaxLength(255)]
        public string? Department { get; set; }
        [MaxLength(255)]
        public string? Skype { get; set; }
        [MaxLength(20)]
        public string? Mobile { get; set; }
        [MaxLength(255)]
        public string? Email { get; set; }
        [MaxLength(255)]
        public string? Facebook { get; set; }
        [MaxLength(255)]
        public string? Twitter { get; set; }
        [MaxLength(255)]
        public string? Instagram { get; set; }
    }
}
