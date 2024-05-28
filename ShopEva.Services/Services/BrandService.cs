using ShopEva.Data.Infrastructure;
using ShopEva.Data.IRepositories;
using ShopEva.Data.Repositories;
using ShopEva.Models.Model;
using ShopEva.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEva.Services.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BrandService(IBrandRepository brandRepository, IUnitOfWork unitOfWork)
        {
            _brandRepository = brandRepository;
            _unitOfWork = unitOfWork;
        }

        public Brand Add(Brand brand)
        {
            throw new NotImplementedException();
        }

        public Brand Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Brand>> GetAllAsync(int status, string? keyword, string? order_by, string? order_type)
        {
            var brands = await _brandRepository.GetAllAsync();

            if (!string.IsNullOrEmpty(keyword))
            {
                brands = brands.Where(x => x.Name.Contains(keyword));
            }

            if (status >= 0)
            {
                brands = brands.Where(x => x.Status == status);
            }

            return brands;
        }

        public Task<Brand> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanged()
        {
            _unitOfWork.Commit();
        }

        public void Update(Guid id, Brand brand)
        {
            throw new NotImplementedException();
        }
    }
}
