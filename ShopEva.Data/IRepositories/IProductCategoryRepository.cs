using ShopEva.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopEva.Data.Infrastructure;

namespace ShopEva.Data.IRepositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        /// <summary>
        /// Lấy ra các product category có thể làm cha
        /// </summary>
        /// <param name="id">category hiện tại</param>
        /// <returns></returns>
        Task<IEnumerable<ProductCategory>> GetParentAsync(Guid? id);
    }
}
