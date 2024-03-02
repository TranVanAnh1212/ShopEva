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
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IUnitOfWork unitOfWork)
        {
            _productCategoryRepository = productCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public ProductCategory Add(ProductCategory pc)
        {
            return _productCategoryRepository.Add(pc);
        }

        public ProductCategory Delete(Guid id)
        {
            return _productCategoryRepository.Delete(id);
        }

        public IEnumerable<ProductCategory> GetAll( int status, string? keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _productCategoryRepository.GetMulti(x => x.Name.Equals(keyword) && x.Status == status);
            }

            return _productCategoryRepository.GetMulti(x => x.Status == status); 
        }

        public async Task<IEnumerable<ProductCategory>> GetAllAsync(int status, string? keyword)
        {
            return await _productCategoryRepository.GetAllAsync();
        }

        public Task<IEnumerable<ProductCategory>> GetAllByParentId(Guid parentId)
        {
            throw new NotImplementedException();
        }

        public ProductCategory GetById(Guid id)
        {
            return _productCategoryRepository.GetSingleById(id);
        }

        public Task<IEnumerable<ProductCategory>> GetMany(int status)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductCategory>> GetManyAsync(int status)
        {
            throw new NotImplementedException();
        }

        public void SaveChanged()
        {
            _unitOfWork.Commit();
        }

        public void Update(ProductCategory pc)
        {
            _productCategoryRepository.Update(pc);
        }
    }
}
