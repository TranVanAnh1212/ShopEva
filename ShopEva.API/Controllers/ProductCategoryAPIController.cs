using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopEva.Data.ViewModels;
using ShopEva.Models.Model;
using ShopEva.Services.IServices;
using ShopEva.Services.RequestMessage;
using ShopEva.Services.Extention;
using ShopExample.Web.Infrastructure.Core;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authorization;

namespace ShopEva.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductCategoryAPIController : ControllerBase
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly IProductCategoryService _productCategoryService;
        private readonly IMapper _mapper;

        public ProductCategoryAPIController(IProductCategoryService productCategoryService, IMapper mapper)
        {
            _productCategoryService = productCategoryService;
            _mapper = mapper;
        }

        [HttpGet("getall")]
        [AllowAnonymous]
        public IActionResult Get(string? keyword, string? order_by, int status, int page = 1, string order_type = "ASC")
        {
            try
            {
                int page_size = 20;

                var product_Category_List = _productCategoryService.GetAll(status, keyword, order_by, order_type);

                var res = _mapper.Map<List<ProductCategoryViewModel>>(product_Category_List);

                var res_paginated = PaginatedList<ProductCategoryViewModel>.Create(res, page, page_size);

                var res_paginatedSet = new PaginationSet<ProductCategoryViewModel>()
                {
                    Page = page,
                    TotalCount = res_paginated.TotalCount,
                    TotalPage = res_paginated.TotalPages,
                    Data = res_paginated
                };

                return Ok(new RequestMessage
                {
                    Success = true,
                    Result = res_paginatedSet
                });
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return BadRequest(new RequestMessage
                {
                    Success = false,
                    Error = new ErrorInfor
                    {
                        Code = 400,
                        Message = ex.Message
                    }
                });
            }
        }

        [AllowAnonymous]
        [HttpGet("get_parent")]
        public async Task<IActionResult> Get(Guid? id)
        {
            try
            {
                var product_Category_List = await _productCategoryService.GetParentAsync(id);

                var res = _mapper.Map<List<ProductCategoryViewModel>>(product_Category_List);

                return Ok(new RequestMessage
                {
                    Success = true,
                    Result = res
                });
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return BadRequest(new RequestMessage
                {
                    Success = false,
                    Error = new ErrorInfor
                    {
                        Code = 400,
                        Message = ex.Message
                    }
                });
            }
        }

        [AllowAnonymous]
        [HttpGet("getbyid")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var product_Category = _productCategoryService.GetById(id);

                var res = _mapper.Map<ProductCategoryViewModel>(product_Category);

                return Ok(new RequestMessage
                {
                    Success = true,
                    Result = res
                });
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return BadRequest(new RequestMessage
                {
                    Success = false,
                    Error = new ErrorInfor
                    {
                        Code = 400,
                        Message = ex.Message
                    }
                });
            }
        }

        [HttpPost("addnew")]
        public IActionResult Post(ProductCategoryViewModel viewModel)
        {
            try
            {
                ProductCategory pc = new ProductCategory();
                pc.ProductCategoryMap(viewModel);
                pc.ID = Guid.NewGuid();
                pc.CreatedDate = DateTime.UtcNow;
                pc.CreatedBy = "TranVanAnh";

                _productCategoryService.Add(pc);
                _productCategoryService.SaveChanged();

                var res = _mapper.Map<ProductCategoryViewModel>(pc);

                return Ok(new RequestMessage
                {
                    Success = true,
                    Result = res
                });
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return BadRequest(new RequestMessage
                {
                    Success = false,
                    Error = new ErrorInfor
                    {
                        Code = 400,
                        Message = ex.Message
                    }
                });
            }
        }

        [HttpPut("update")]
        public IActionResult Put(ProductCategoryViewModel viewModel)
        {
            try
            {
                var pc = _productCategoryService.GetById(viewModel.ID);
                pc.ProductCategoryMap(viewModel);
                pc.ModifiedDate = DateTime.UtcNow;
                pc.ModifiedBy = "TranVanAnh";

                _productCategoryService.Update(pc);
                _productCategoryService.SaveChanged();

                var res = _mapper.Map<ProductCategoryViewModel>(pc);

                return Ok(new RequestMessage
                {
                    Success = true,
                    Result = res
                });
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return BadRequest(new RequestMessage
                {
                    Success = false,
                    Error = new ErrorInfor
                    {
                        Code = 400,
                        Message = ex.Message
                    }
                });
            }
        }


        [HttpDelete("delete")]
        public IActionResult Delete(string productCategoryJSON)
        {
            try
            {
                // [{"ID":"e1c1ad80-c373-4707-b13e-e1966f3e7748","Name":"Demo post 1"},{"ID":"e1c1ad80-d373-4907-b13e-e1966f3e7748","Name":"Demo post 2"}]

                var myObject = System.Text.Json.JsonSerializer.Deserialize<List<ProductCategoryJSONViewModel>>(productCategoryJSON);

                foreach (var i in myObject)
                    _productCategoryService.Delete(i.ID);

                _productCategoryService.SaveChanged();

                return Ok(new RequestMessage
                {
                    Success = true,
                    Result = myObject.Count
                });
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return BadRequest(new RequestMessage
                {
                    Success = false,
                    Error = new ErrorInfor
                    {
                        Code = 400,
                        Message = ex.Message
                    }
                });
            }
        }
    }
}
