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
    public class ProductProductCategoryRepository : RepositoryBase<ProductProductCategory>, IProductProductCategoryRepository
    {
        public ProductProductCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
            
        }
    }
}
