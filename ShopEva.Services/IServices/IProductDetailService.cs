using ShopEva.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEva.Services.IServices
{
    public interface IProductDetailService
    {
        Task<ProductDetail> GetByProductIDAsync(Guid id);
        ProductDetail Add(ProductDetail productDetail);
        ProductDetail Update(ProductDetail productDetail);
        void SaveChanged();
    }
}
