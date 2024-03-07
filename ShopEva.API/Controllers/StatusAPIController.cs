using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopEva.Data.ViewModels;
using ShopEva.Services.IServices;
using ShopEva.Services.RequestMessage;
using ShopEva.Services.Services;

namespace ShopEva.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusAPIController : ControllerBase
    {
        private readonly IStatusService _statusService;
        private readonly IMapper _mapper;

        public StatusAPIController(IStatusService statusService, IMapper mapper)
        {
            _statusService = statusService;
            _mapper = mapper;
        }

        [HttpGet("get_status")]
        public async Task<IActionResult> Get(int status_of)
        {
            try
            {
                var status_list = await _statusService.GetManyAsync(status_of);

                var status_list_mapped = _mapper.Map<List<StatusViewModel>>(status_list);

                return Ok(new RequestMessage
                {
                    Success = false,
                    Result = status_list_mapped
                });
            }
            catch (Exception ex)
            {
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
