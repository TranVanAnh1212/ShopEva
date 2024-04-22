using ShopEva.Models.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEva.Data.ViewModels
{
    public class ProductViewModel
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string Alias { get; set; }
        public string? Description { get; set; }
        public string? Contents { get; set; }
        public string? Image { get; set; }
        public string? Image2 { get; set; }
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
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public string? MetaKeyWord { get; set; }
        public string? MetaDescription { get; set; }
        public int Status { get; set; }
    }
}
