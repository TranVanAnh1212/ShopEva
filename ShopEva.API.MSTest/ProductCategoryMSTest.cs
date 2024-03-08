using ShopEva.Services.IServices;
using ShopEva.Services.Services;
using NUnit.Framework;
using Moq; // Ensure you have Moq installed via NuGet or other package manager
using System.Collections.Generic;
using ShopEva.Data.IRepositories;
using ShopEva.Data.Infrastructure;
using ShopEva.Models.Model;

namespace ShopEva.API.MSTest
{
    [TestClass]
    public class ProductCategoryMSTest
    {
        private IProductCategoryService _productCategoryService;
        private Mock<IProductCategoryRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private List<ProductCategory> _listProductCategory;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IProductCategoryRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _productCategoryService = new ProductCategoryService(_mockRepository.Object, _mockUnitOfWork.Object);
            _listProductCategory = new List<ProductCategory>()
            {
                new ProductCategory(){ID = Guid.NewGuid(), Name = "Test 1", Status = 1 },
                new ProductCategory(){ID = Guid.NewGuid(), Name = "Test 2", Status = 1 },
                new ProductCategory(){ID = Guid.NewGuid(), Name = "Test 3", Status = 1 },
                new ProductCategory(){ID = Guid.NewGuid(), Name = "Test 4", Status = 1 },
                new ProductCategory(){ID = Guid.NewGuid(), Name = "Test 5", Status = 1 } };
        }


        [TestMethod]
        public void GetAll_ProductCategory()
        {
            int status = 1; // Sample status
            string keyword = ""; // Sample keyword
            string orderBy = "name"; // Sample order_by
            string orderType = "ASC"; // Sample order_type

            _mockRepository.Setup(m => m.GetAll(null)).Returns(_listProductCategory);


            var result = _productCategoryService.GetAll(status, keyword, orderBy, orderType);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result, "Returned list should not be null.");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(5, result.Count(), $"Expected count: {5}. Actual count: {result.Count()}");
        }
    }
}
