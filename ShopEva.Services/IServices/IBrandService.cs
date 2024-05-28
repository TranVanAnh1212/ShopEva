using ShopEva.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEva.Services.IServices
{
    public interface IBrandService
    {
        Brand Add(Brand brand);
        Brand Delete(Guid id);
        void Update(Guid id, Brand brand);
        Task<IEnumerable<Brand>> GetAllAsync(int status, string? keyword, string? order_by, string? order_type);
        Task<Brand> GetByIdAsync(Guid id);
        void SaveChanged();
    }
}
