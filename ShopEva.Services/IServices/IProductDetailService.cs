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
        Task<IEnumerable<ProductDetail>> GetAllAsync();
        Task<ProductDetail> GetByIDAsync();
        ProductDetail Add(ProductDetail productDetail);
        ProductDetail Update(ProductDetail productDetail);
        ProductDetail Delete(int id);
        void SaveChanged();
    }
}
