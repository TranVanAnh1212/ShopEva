﻿

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEva.Models.Model
{
    [Table("MenuGroup")]
    public class MenuGroup
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        [MaxLength(550)]
        public string Name { get; set; }
        public virtual IEnumerable<Menu> Menu { get; set; }
    }
}
