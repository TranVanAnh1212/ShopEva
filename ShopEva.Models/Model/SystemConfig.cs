
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEva.Models.Model
{
    [Table("SystemConfigs" )]
    public class SystemConfig
    {
        [Key]
        [Required]
        public Guid ID { get; set; }
        [Required]
        public int Code { get; set; }
        [MaxLength(500)]
        public string? ValueStr { get; set; }
        public int ValueInt { get; set; }
    }
}
