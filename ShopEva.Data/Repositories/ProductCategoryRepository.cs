using Microsoft.EntityFrameworkCore;
using ShopEva.Data.Infrastructure;
using ShopEva.Data.IRepositories;
using ShopEva.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEva.Data.Repositories
{
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
            
        }

        public async Task<IEnumerable<ProductCategory>> GetParentAsync(Guid? id)
        {
            if (id != null)
            {
                return await this.DbContext.ProductCategories.Where(x => x.ID != id && x.Status == 1).ToListAsync();
            }

            return await this.DbContext.ProductCategories.Where(x => x.Status == 1).ToListAsync();
        }
    }
}
