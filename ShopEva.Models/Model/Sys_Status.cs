using ShopEva.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEva.Models.Model
{
    [Table("Sys_Status")]
    public class Sys_Status : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string? Name { get; set; }
        public int Status_Of { get; set; }

    }
}
