using ShopEva.Data.Infrastructure;
using ShopEva.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEva.Data.IRepositories
{
    public interface IProductDetailRepository : IRepository<ProductDetail>
    {
        Task<ProductDetail> GetByProductID(Guid id);
    }
}
