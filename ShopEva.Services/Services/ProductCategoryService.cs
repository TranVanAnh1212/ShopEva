using ShopEva.Data.Infrastructure;
using ShopEva.Data.IRepositories;
using ShopEva.Models.Model;
using ShopEva.Services.IServices;

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

        public IEnumerable<ProductCategory> GetAll(int status, string? keyword, string? order_by, string? order_type)
        {
            var product_category_list = _productCategoryRepository.GetAll();

            if (!string.IsNullOrEmpty(keyword))
            {
                product_category_list = product_category_list.Where(x => x.Name.Contains(keyword));
            }

            if (status >= 0)
            {
                product_category_list = product_category_list.Where(x => x.Status == status);
            }

            #region ====  Order  ====
            switch (order_type)
            {
                case "ASC":
                    switch (order_by)
                    {
                        case "name":
                            product_category_list = product_category_list.OrderBy(x => x.Name.ToLower());
                            break;
                    }

                    int index_asc = 1;
                    foreach (var item in product_category_list)
                    {
                        item.Index = index_asc;
                        index_asc++;
                    }
                    break;
                case "DESC":
                    switch (order_by)
                    {
                        case "name":
                            product_category_list = product_category_list.OrderByDescending(x => x.Name.ToLower());
                            break;
                    }

                    int index_desc = product_category_list.Count();
                    foreach (var item in product_category_list)
                    {
                        item.Index = index_desc;
                        index_desc--;
                    }

                    break;
                default:
                    switch (order_by)
                    {
                        case "name":
                            product_category_list = product_category_list.OrderBy(x => x.Name.ToLower());
                            break;
                    }

                    int index = 1;
                    foreach (var item in product_category_list)
                    {
                        item.Index = index;
                        index++;
                    }
                    break;
            }
            #endregion

            return product_category_list;
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

        public async Task<IEnumerable<ProductCategory>> GetParentAsync(Guid? id)
        {
            return await _productCategoryRepository.GetParentAsync(id);
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
