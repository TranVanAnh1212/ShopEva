﻿using Microsoft.EntityFrameworkCore;
using ShopEva.Data.Infrastructure;
using ShopEva.Data.IRepositories;
using ShopEva.Data.ViewModels;
using ShopEva.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEva.Data.Repositories
{
    public class ProductDetailRepository : RepositoryBase<ProductDetail>, IProductDetailRepository
    {
        public ProductDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
            
        }

        public async Task<ProductDetail> GetByProductID(Guid id)
        {
            return await this.DbContext.ProductsDetail.SingleOrDefaultAsync(x => x.ProductID == id);
        }
    }
}
