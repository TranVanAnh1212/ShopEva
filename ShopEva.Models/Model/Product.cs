﻿using ShopEva.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopEva.Models.Model
{
    [Table("Products" )]
    public class Product : Auditable
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
        public string? Alias { get; set; }
        public string? Image { get; set; }
        public string? Image2 { get; set; }
        [Column(TypeName = "xml")]
        public string? MoreImage { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public int? ViewCount { get; set; }
        public int? BuyCount { get; set; }
        public int? Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal? PromotionPrice { get; set; }
        public int? ReviewCount { get; set; }
        public string? Tags { get; set; }
        public IEnumerable<ProductTag> ProductTags { get; set; }
        public IEnumerable<ProductProductCategory> ProductProductCategories { get; set; }
    }
}
