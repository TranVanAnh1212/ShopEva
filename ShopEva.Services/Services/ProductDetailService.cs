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

        public ProductDetail Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDetail>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDetail> GetByIDAsync()
        {
            throw new NotImplementedException();
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
