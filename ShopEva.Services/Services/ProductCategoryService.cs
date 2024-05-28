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

        public async Task<ProductCategory> Add(ProductCategory pc)
        {
            if (pc.ParentID == null)
            {
                pc.CategIndex = 0;
            }
            else
            {
                int CategIndex = 1;
                ProductCategory? parent = await GetByIdAsync(pc.ParentID.Value);
                while (parent != null && parent.ParentID != null)
                {
                    CategIndex++;

                    parent = await GetByIdAsync(parent.ParentID.Value);

                }

                pc.CategIndex = CategIndex;
            }

            return _productCategoryRepository.Add(pc);
        }

        public ProductCategory Delete(Guid id)
        {
            return _productCategoryRepository.Delete(id);
        }

        public async Task<IEnumerable<ProductCategory>> GetAllAsync(int status, string? keyword, string? order_by, string? order_type, int index)
        {
            var product_category_list = await _productCategoryRepository.GetAllAsync();

            if (!string.IsNullOrEmpty(keyword))
            {
                product_category_list = product_category_list.Where(x => x.Name.Contains(keyword));
            }

            if ( index >= 0)
            {
                product_category_list = product_category_list.Where(x => x.CategIndex == index);
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
                    break;
                case "DESC":
                    switch (order_by)
                    {
                        case "name":
                            product_category_list = product_category_list.OrderByDescending(x => x.Name.ToLower());
                            break;
                    }
                    break;
                default:
                    switch (order_by)
                    {
                        case "name":
                            product_category_list = product_category_list.OrderBy(x => x.Name.ToLower());
                            break;
                    }

                    break;
            }
            #endregion

            return product_category_list;
        }

        public async Task<IEnumerable<ProductCategory>> GetAllByParentID(Guid? parentID, int index)
        {
            return await _productCategoryRepository.GetManyAsync(x => x.ParentID == parentID && x.CategIndex == index && x.Status == 1);
        }

        public async Task<ProductCategory> GetByIdAsync(Guid id)
        {
            return await _productCategoryRepository.GetSingleByIdAsync(id);
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
