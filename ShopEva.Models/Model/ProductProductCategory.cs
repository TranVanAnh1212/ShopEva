using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEva.Models.Model
{
    [Table("ProductProductCategory")]
    public class ProductProductCategory
    {
        [Key] 
        [Column(Order = 0)]
        public Guid ProductID { get; set; }
        [ForeignKey("ProductID")]
        public virtual Product MyProperty { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
