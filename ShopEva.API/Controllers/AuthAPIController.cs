using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopEva.Data.IRepositories;
using ShopEva.Data.Repositories;
using ShopEva.Data.ViewModels;
using ShopEva.Services.RequestMessage;
using ShopEva.Services.Services;

namespace ShopEva.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        private IAuthRepository _authRepository;

        public AuthAPIController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("Register")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Register(RegisterUserViewModel user)
        {
            try
            {
                var res  = await _authRepository.RegisterAsync(user);

                if (res.Succeeded)
                {
                    return Ok(new RequestMessage
                    {
                        Success = true,
                        Result = "Đăng ký tài khoản thành công."
                    });
                }

                return BadRequest(new RequestMessage
                {
                    Success = false,
                    Error = new ErrorInfor
                    {
                        Code = 400,
                        Message= "Có lỗi xảy ra, đăng ký tài khoản thất bại"
                    },
                    Result = res.Errors
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserViewModel user)
        {
            try
            {
                var res = await _authRepository.LoginAsync(user);

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("check_user_demo")]
        public IActionResult SomeAction()
        {
            // Kiểm tra xem người dùng đã đăng nhập hay không
            if (User.Identity.IsAuthenticated)
            {
                // Truy cập thông tin của người dùng
                string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                string userName = User.Identity.Name;
                // Các thông tin khác có thể truy cập thông qua Claims của User

                return Content($"User {userName} with ID {userId} is authenticated.");
            }
            else
            {
                return Content("User is not authenticated.");
            }
        }

        [HttpPost("logout")]
        [Authorize]
        public IActionResult LogOut()
        {
            var res = _authRepository.LogOutAsync();

            return Ok();
        } 
    }
}
