using ShopEva.Data.Infrastructure;
using ShopEva.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEva.Services.IServices
{
    public interface IErrorService
    {
        Error Add(Error err);
        Task<IEnumerable<Error>> GetAll();
        void SaveChanged();
    }
}
