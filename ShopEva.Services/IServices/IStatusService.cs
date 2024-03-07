using ShopEva.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEva.Services.IServices
{
    public interface IStatusService
    {
        Task<IEnumerable<Sys_Status>> GetAllAsync();
        Task<IEnumerable<Sys_Status>> GetManyAsync(int status_of);
    }
}
