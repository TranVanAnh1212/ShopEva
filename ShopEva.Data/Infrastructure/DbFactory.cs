using ShopEva.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEva.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private ShopEvaDbContext dbContext;

        public ShopEvaDbContext Init()
        {
            return dbContext ?? (dbContext = new ShopEvaDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
