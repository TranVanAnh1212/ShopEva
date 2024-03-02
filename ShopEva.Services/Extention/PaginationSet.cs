using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopExample.Web.Infrastructure.Core
{
    public class PaginationSet<T>
    {
        public int Page { get; set; }
        public int Count { get => (Data != null) ? Data.Count() : 0; }
        public int TotalPage { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}