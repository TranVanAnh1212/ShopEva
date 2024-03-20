using ShopEva.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEva.Services.IServices
{
    public interface IProductService
    {
        Product Add(Product pc);
        Product Delete(Guid id);
        void Update(Product pc);
        Task<IEnumerable<Product>> GetAllAsync(int status, string? keyword, string? order_by, string? order_type);
        Task<IEnumerable<Product>> GetMany(int status);
        Task<IEnumerable<Product>> GetManyAsync(int status);
        Product GetById(Guid id);
        void SaveChanged();
    }
}
