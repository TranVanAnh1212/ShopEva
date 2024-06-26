﻿using ShopEva.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEva.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        ShopEvaDbContext Init();
    }
}
