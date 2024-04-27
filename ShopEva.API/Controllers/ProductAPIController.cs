using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ShopEva.Data.ViewModels;
using ShopEva.Models.Model;
using ShopEva.Services.IServices;
using ShopEva.Services.RequestMessage;
using ShopEva.Services.Extention;
using AutoMapper;
using ShopExample.Web.Infrastructure.Core;
using Microsoft.AspNetCore.Identity;
using ShopEva.Data.IRepositories;
using ShopEva.Data.Repositories;
using ShopEva.Services.Services;

namespace ShopEva.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly IProductDetailService _productDetailService;
        private readonly IProductCategoriesService _productCategoryService;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductAPIController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductAPIController(IProductService productService,
                                    IUserService userService,
                                    IProductDetailService productDetailService,
                                    IProductCategoriesService productCategoryService,
                                    IMapper mapper,
                                    UserManager<ApplicationUser> userManager,
                                    ILogger<ProductAPIController> logger)
        {
            _productService = productService;
            _userService = userService;
            _productDetailService = productDetailService;
            _productCategoryService = productCategoryService;
            _mapper = mapper;
            _logger = logger;
            _userManager = userManager;
        }

        [HttpGet("get_all")]
        public async Task<IActionResult> Get(int status, string? keyword, string? order_by, string? order_type = "ASC", int page = 1)
        {
            try
            {
                int page_size = 20;
                var product_list = await _productService.GetAllAsync(status, keyword, order_by, order_type);
                var res = _mapper.Map<List<ProductViewModel>>(product_list);

                foreach (var item in res)
                {
                    var creator = await _userService.GetByID(item.CreatedBy.ToString());
                    var modifior = await _userService.GetByID(item.ModifiedBy.ToString());

                    if (modifior != null) 
                        item.Modifior = modifior.UserName;

                    if (creator != null)
                        item.Creator = creator.UserName;
                }

                var res_paginated = PaginatedList<ProductViewModel>.Create(res, page, page_size);

                var product_list_page = new PaginationSet<ProductViewModel>()
                {
                    Page = page,
                    TotalPage = res_paginated.TotalPages,
                    TotalCount = res_paginated.TotalCount,
                    Data = res_paginated,
                };

                return Ok(new RequestMessage()
                {
                    Success = true,
                    Result = product_list_page
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new RequestMessage()
                {
                    Success = false,
                    Error = new ErrorInfor
                    {
                        Code = ex.GetHashCode(),
                        Message = ex.Message
                    }
                });
            }
        }

        [HttpGet("get_by_id")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var product = _productService.GetById(id);
                var product_mapper = _mapper.Map<ProductViewModel>(product);
                var creator = await _userService.GetByID(product_mapper.CreatedBy.ToString());
                var modifior = await _userService.GetByID(product_mapper.ModifiedBy.ToString());

                if (modifior != null)
                    product_mapper.Modifior = modifior.UserName;

                if (creator != null)
                    product_mapper.Creator = creator.UserName;

                var product_categories = await _productCategoryService.GetByProductIDAsync(product.ID);
                var product_categories_mapper = _mapper.Map<List<ProductCategoriesViewModel>>(product_categories);

                var product_detail = await _productDetailService.GetByProductIDAsync(product.ID);
                var product_detail_mapper = _mapper.Map<ProductDetailViewModel>(product_detail);

                return Ok(new RequestMessage()
                {
                    Success = true,
                    Result = new
                    {
                        product = product_mapper,
                        product_categories = product_categories_mapper,
                        product_detail = product_detail_mapper
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new RequestMessage()
                {
                    Success = false,
                    Error = new ErrorInfor
                    {
                        Code = ex.GetHashCode(),
                        Message = ex.Message
                    }
                });
            }
        }

        [HttpPost("create_new")]
        public async Task<IActionResult> PostAsync(Dataset_Product data)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                var product = new Product();
                product.ProductMap(data.ProductViewModel);
                product.ID = Guid.NewGuid();
                product.CreatedDate = DateTime.UtcNow;
                product.CreatedBy = Guid.Parse(user.Id);

                var res = _productService.Add(product);
                _productService.SaveChanged();

                List<ProductProductCategory> prod2Categ_List = new List<ProductProductCategory>();

                foreach (var item in data.Product2CategoryViewModel)
                {
                    var product2Category = new ProductProductCategory();
                    product2Category.ProductProductCategoryMap(item);
                    product2Category.ProductID = res.ID;

                    var res_2 = _productCategoryService.Create(product2Category);
                    _productCategoryService.SaveChanged();

                    prod2Categ_List.Add(res_2);
                }

                var product_map = _mapper.Map<ProductViewModel>(res);
                var product2Category_map = _mapper.Map<List<ProductCategoriesViewModel>>(prod2Categ_List);

                return Ok(new RequestMessage
                {
                    Success = true,
                    Result = new Dataset_Product
                    {
                        ProductViewModel = product_map,
                        Product2CategoryViewModel = product2Category_map
                    }

                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new RequestMessage()
                {
                    Success = false,
                    Error = new ErrorInfor
                    {
                        Code = ex.GetHashCode(),
                        Message = ex.Message
                    }
                });
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> PutAsync(ProductViewModel vm)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                var product = new Product();
                product.ProductMap(vm);
                product.ModifiedDate = DateTime.UtcNow;
                product.ModifiedBy = Guid.Parse(user.Id);

                _productService.Update(product);
                _productService.SaveChanged();

                return Ok(new RequestMessage
                {
                    Success = true
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new RequestMessage()
                {
                    Success = false,
                    Error = new ErrorInfor
                    {
                        Code = ex.GetHashCode(),
                        Message = ex.Message
                    }
                });
            }
        }

        [HttpDelete("delete")]
        public IActionResult Delete(string productListIdJson)
        {
            try
            {
                var list_ID = System.Text.Json.JsonSerializer.Deserialize<List<Product>>(productListIdJson);

                foreach (var item in list_ID)
                {
                    _productService.Delete(item.ID);
                }

                _productService.SaveChanged();

                return Ok(new RequestMessage
                {
                    Success = true,
                    Result = list_ID.Count
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(new RequestMessage()
                {
                    Success = false,
                    Error = new ErrorInfor
                    {
                        Code = ex.GetHashCode(),
                        Message = ex.Message
                    }
                });
            }
        }
    }
}
