
namespace ShopEva.Data.ViewModels
{
    public class ProductDetailViewModel
    {
        public Guid ID { get; set; }
        public Guid ProductID { get; set; }
        public string? Colors { get; set; }
        public string? Sizes { get; set; }
        public int Rating { get; set; }
        public Guid? BrandID { get; set; }
        public string? Material { get; set; }
        public string? Other_Info { get; set; }
    }
}
