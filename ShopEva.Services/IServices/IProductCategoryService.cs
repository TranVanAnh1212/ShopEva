using ShopEva.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEva.Services.IServices
{
    public interface IProductCategoryService 
    {
        ProductCategory Add(ProductCategory pc);
        ProductCategory Delete(Guid id);
        void Update(ProductCategory pc);
        Task<IEnumerable<ProductCategory>> GetParentAsync(Guid? id);
        Task<IEnumerable<ProductCategory>> GetAllAsync(int status, string? keyword, string? order_by, string? order_type);
        Task<IEnumerable<ProductCategory>> GetMany(int status);
        Task<IEnumerable<ProductCategory>> GetManyAsync(int status);
        Task<IEnumerable<ProductCategory>> GetAllByParentId(Guid parentId);
        Task<ProductCategory> GetByIdAsync(Guid id);
        void SaveChanged();
    }
}
