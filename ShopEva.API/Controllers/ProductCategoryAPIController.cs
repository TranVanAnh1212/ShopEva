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
using Microsoft.AspNetCore.Identity;
using ShopEva.Services.Services;

namespace ShopEva.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductCategoryAPIController : ControllerBase
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly IProductCategoryService _productCategoryService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductCategoryAPIController(IProductCategoryService productCategoryService, 
                                            IUserService userService,
                                            IMapper mapper,
                                            UserManager<ApplicationUser> userManager)
        {
            _productCategoryService = productCategoryService;
            _userService = userService;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet("getall")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(string? keyword, string? order_by, int status, int page = 1, string order_type = "ASC")
        {
            try
            {
                int page_size = 20;
                var product_Category_List = await _productCategoryService.GetAllAsync(status, keyword, order_by, order_type);

                var res = _mapper.Map<List<ProductCategoryViewModel>>(product_Category_List);

                foreach (var item in res)
                {
                    var creator = await _userService.GetByID(item.CreatedBy.ToString());
                    var modifior = await _userService.GetByID(item.ModifiedBy.ToString());

                    if (creator != null)
                        item.CreatorName = creator.UserName;

                    if (modifior != null)
                        item.ModifiorName = modifior.UserName;
                }

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

                foreach (var item in res)
                {
                    var creator = await _userService.GetByID(item.CreatedBy.ToString());
                    var modifior = await _userService.GetByID(item.ModifiedBy.ToString());

                    if (creator != null)
                        item.CreatorName = creator.UserName;

                    if (modifior != null)
                        item.ModifiorName = modifior.UserName;
                }

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
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var product_Category = await _productCategoryService.GetByIdAsync(id);

                var res = _mapper.Map<ProductCategoryViewModel>(product_Category);
                var creator = await _userService.GetByID(res.CreatedBy.ToString());
                var modifor = await _userService.GetByID(res.ModifiedBy.ToString());

                res.CreatorName = creator != null ? creator.UserName : "";
                res.ModifiorName = modifor != null ? modifor.UserName : "";

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
        public async Task<IActionResult> PostAsync(ProductCategoryViewModel viewModel)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                ProductCategory pc = new ProductCategory();
                pc.ProductCategoryMap(viewModel);
                pc.ID = Guid.NewGuid();
                pc.CreatedDate = DateTime.UtcNow;
                pc.CreatedBy = Guid.Parse(user.Id);

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
        public async Task<IActionResult> PutAsync(ProductCategoryViewModel viewModel)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                var pc = await _productCategoryService.GetByIdAsync(viewModel.ID);
                pc.ProductCategoryMap(viewModel);
                pc.ModifiedDate = DateTime.UtcNow;
                pc.ModifiedBy = Guid.Parse(user.Id);

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

                var myObject = System.Text.Json.JsonSerializer.Deserialize<List<ProductCategoryViewModel>>(productCategoryJSON);

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
