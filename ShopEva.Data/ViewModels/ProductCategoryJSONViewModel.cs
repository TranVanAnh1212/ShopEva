using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopEva.Data.ViewModels
{
    public class ProductCategoryJSONViewModel
    {
        [JsonPropertyName("ID")]
        public Guid ID { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
    }

    public class ProductCategoryJSONListRoot
    {
        [JsonPropertyName("MyArray")]
        public List<ProductCategoryJSONViewModel> ProductCategoryJSONList { get; set; }
    }
}
