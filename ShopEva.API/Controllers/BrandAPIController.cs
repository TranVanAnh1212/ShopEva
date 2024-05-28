using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopEva.Data.ViewModels;
using ShopEva.Services.Extention;
using ShopEva.Services.IServices;
using ShopEva.Services.RequestMessage;
using ShopEva.Services.Services;
using ShopExample.Web.Infrastructure.Core;

namespace ShopEva.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandAPIController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly ILogger<BrandAPIController> _logger;
        private readonly IMapper _mapper;

        public BrandAPIController(IBrandService brandService, ILogger<BrandAPIController> logger, IMapper mapper)
        {
            _brandService = brandService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("get_all")]
        public async Task<IActionResult> Get(string? keyword, string? order_by, int status = -1,string order_type = "ASC",  int page = 1, int page_size = 20)
        {
            try
            {
                var list = await _brandService.GetAllAsync(status, keyword, order_by, order_type);

                var list_map = _mapper.Map<List<BrandViewModel>>(list);

                var pagination_list = PaginatedList<BrandViewModel>.Create(list_map, page, page_size);

                var paginated_set = new PaginationSet<BrandViewModel>()
                {
                    Page = page,
                    TotalCount = pagination_list.TotalCount,
                    TotalPage = pagination_list.TotalPages,
                    Data = pagination_list
                };

                return Ok(new RequestMessage
                {
                    Success = true,
                    Result = paginated_set
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
