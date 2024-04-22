using ShopEva.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEva.Services.IServices
{
    public interface IProductCategoriesService
    {
        Task<IEnumerable<ProductProductCategory>> GetByProductIDAsync(Guid productID);
        ProductProductCategory Create(ProductProductCategory productProductCategory);
        ProductProductCategory Update(ProductProductCategory productProductCategory);
        void SaveChanged();
    }
}
