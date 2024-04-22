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
    public class ProductCategoriesService : IProductCategoriesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductCategoriesRepository _productProductCategoryRepository;

        public ProductCategoriesService(IUnitOfWork unitOfWork, IProductCategoriesRepository productProductCategoryRepository)
        {
            _unitOfWork = unitOfWork;
            _productProductCategoryRepository = productProductCategoryRepository;
        }

        public ProductProductCategory Create(ProductProductCategory productProductCategory)
        {
            return _productProductCategoryRepository.Add(productProductCategory);
        }

        public async Task<IEnumerable<ProductProductCategory>> GetByProductIDAsync(Guid productID)
        {
            return await _productProductCategoryRepository.GetManyAsync(x => x.ProductID == productID);
        }

        public void SaveChanged()
        {
            _unitOfWork.Commit();
        }

        public ProductProductCategory Update(ProductProductCategory productProductCategory)
        {
            return _productProductCategoryRepository.Update(productProductCategory);
        }
    }
}
