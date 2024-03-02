using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEva.Services.RequestMessage
{
    public class RequestMessage
    {
        public bool Success { get; set; }
        public ErrorInfor Error { get; set; }
        public object Result { get; set; }
    }
}
