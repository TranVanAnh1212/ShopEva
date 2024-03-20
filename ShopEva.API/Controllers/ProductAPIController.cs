using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ShopEva.Data.ViewModels;
using ShopEva.Models.Model;
using ShopEva.Services.IServices;
using ShopEva.Services.RequestMessage;
using ShopEva.Services.Services;
using ShopEva.Services.Extention;
using AutoMapper;
using ShopExample.Web.Infrastructure.Core;

namespace ShopEva.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IProductDetailService _productDetailService;
        private readonly IProductProductCategoryService _product2CategoryService;
        private readonly IMapper _mapper;
        private readonly ILogger<Product> _logger;

        public ProductAPIController(IProductService productService,
                                    IProductDetailService productDetailService,
                                    IProductProductCategoryService product2CategoryService,
                                    IMapper mapper,
                                    ILogger<Product> logger)
        {
            _productService = productService;
            _productDetailService = productDetailService;
            _product2CategoryService = product2CategoryService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("get_all")]
        public async Task<IActionResult> Get(int status, string? keyword, string? order_by, string? order_type, int page = 1)
        {
            try
            {
                int page_size = 20;

                var product_list = await _productService.GetAllAsync(status, keyword, order_by, order_type);

                var res = _mapper.Map<List<ProductViewModel>>(product_list);

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

        [HttpGet("get_by_id/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var result = _productService.GetById(id);

                return Ok(new RequestMessage()
                {
                    Success = true,
                    Result = result
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
        public IActionResult Post(Dataset_Product data)
        {
            try
            {
                var product = new Product();
                product.ProductMap(data.ProductViewModel);
                product.ID = Guid.NewGuid();
                product.CreatedDate = DateTime.UtcNow;
                product.CreatedBy = HttpContext.User.Identity.Name;

                var res = _productService.Add(product);
                _productService.SaveChanged();

                List<ProductProductCategory> prod2Categ_List = new List<ProductProductCategory>();

                foreach (var item in data.Product2CategoryViewModel)
                {
                    var product2Category = new ProductProductCategory();
                    product2Category.ProductProductCategoryMap(item);
                    product2Category.ProductID = res.ID;

                    var res_2 = _product2CategoryService.Create(product2Category);
                    _product2CategoryService.SaveChanged();

                    prod2Categ_List.Add(res_2);
                }

                var product_map = _mapper.Map<ProductViewModel>(res);
                var product2Category_map = _mapper.Map<List<ProductProductCategoryViewModel>>(prod2Categ_List);

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
        public IActionResult Put(ProductViewModel vm)
        {
            try
            {
                var product = new Product();
                product.ProductMap(vm);
                product.ModifiedDate = DateTime.UtcNow;
                product.ModifiedBy = HttpContext.User.Identity.Name;

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
