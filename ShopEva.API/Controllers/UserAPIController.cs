using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopEva.Data.ViewModels;
using ShopEva.Services.IServices;
using ShopEva.Services.RequestMessage;

namespace ShopEva.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserAPIController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var user = await _userService.GetByID(id);

                var userMapper = _mapper.Map<UserViewModel>(user);

                return Ok(new RequestMessage
                {
                    Success = true,
                    Result = userMapper
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
