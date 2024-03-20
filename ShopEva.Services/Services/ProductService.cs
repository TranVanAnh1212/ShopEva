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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public Product Add(Product p)
        {
            return _productRepository.Add(p);
        }

        public Product Delete(Guid id)
        {
            return (_productRepository.Delete(id));
        }

        public async Task<IEnumerable<Product>> GetAllAsync(int status, string? keyword, string? order_by, string? order_type)
        {
            var product_list = await _productRepository.GetAllAsync();

            if (!string.IsNullOrEmpty(keyword))
            {
                product_list = product_list.Where(x => x.Name.Contains(keyword));
            }

            if (status >= 0)
            {
                product_list = product_list.Where(x => x.Status == status);
            }

            switch (order_type)
            {
                case "ASC":
                    switch (order_by)
                    {
                        case "Name":
                            product_list = product_list.OrderBy(x => x.Name);
                            break;
                    }
                    break;
                case "DESC":
                    switch (order_by)
                    {
                        case "Name":
                            product_list = product_list.OrderByDescending(x => x.Name);
                            break;
                    }
                    break;
                default:
                    switch (order_by)
                    {
                        case "Name":
                            product_list = product_list.OrderBy(x => x.Name);
                            break;
                    }
                    break;
            }

            return product_list;
        }

        public Product GetById(Guid id)
        {
            return _productRepository.GetSingleById(id);
        }

        public Task<IEnumerable<Product>> GetMany(int status)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetManyAsync(int status)
        {
            throw new NotImplementedException();
        }

        public void SaveChanged()
        {
            _unitOfWork.Commit();   
        }

        public void Update(Product p)
        {
            _productRepository.Update(p);
        }
    }
}
