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
    public class ProductDetailService : IProductDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductDetailRepository _productDetailRepository;

        public ProductDetailService(IUnitOfWork unitOfWork, IProductDetailRepository productDetailRepository)
        {
            _unitOfWork = unitOfWork;
            _productDetailRepository = productDetailRepository;
        }

        public ProductDetail Add(ProductDetail productDetail)
        {
            return _productDetailRepository.Add(productDetail);            
        }

        public async Task<ProductDetail> GetByProductIDAsync(Guid id)
        {
            return await _productDetailRepository.GetByProductID(id);
        }

        public void SaveChanged()
        {
            _unitOfWork.Commit();
        }

        public ProductDetail Update(ProductDetail productDetail)
        {
            return _productDetailRepository.Update(productDetail);
        }
    }
}
