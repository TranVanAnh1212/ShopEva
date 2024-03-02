using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopEva.Data.Contexts;
using ShopEva.Data.ViewModels;
using ShopEva.Models.Model;
using ShopEva.Services.IServices;
using ShopEva.Services.RequestMessage;
using ShopEva.Services.Extention;
using ShopExample.Web.Infrastructure.Core;

namespace ShopEva.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public IActionResult Get(string? keyword, int status = 1, int page = 1, int page_size = 1)
        {
            try
            {
                var product_Category_List = _productCategoryService.GetAll(status, keyword);

                var res = _mapper.Map<List<ProductCategoryViewModel>>(product_Category_List);

                var res_paginated = PaginatedList<ProductCategoryViewModel>.Create(res, page, page_size);

                var res_paginatedSet = new PaginationSet<ProductCategoryViewModel>()
                {
                    Page = page,
                    TotalCount = res_paginated.Count(),
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
                pc.ID = Guid.NewGuid();
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


        [HttpDelete("delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var old =  _productCategoryService.Delete(id);
                _productCategoryService.SaveChanged();

                var res = _mapper.Map<ProductCategoryViewModel>(old);

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
    }
}
