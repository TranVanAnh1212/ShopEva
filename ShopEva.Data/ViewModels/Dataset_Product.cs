using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEva.Data.ViewModels
{
    public class Dataset_Product
    {
        public ProductViewModel ProductViewModel { get; set; }
        public List<ProductCategoriesViewModel>? Product2CategoryViewModel { get; set; }
    }
}
