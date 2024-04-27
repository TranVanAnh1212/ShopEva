using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShopEva.Data.ViewModels;
using ShopEva.Services.RequestMessage;
using ShopEva.Web.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace ShopEva.Web.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {
        private readonly ILogger<AdminLoginController> _logger;
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdminLoginController(ILogger<AdminLoginController> logger, 
                                    HttpClient httpClient,
                                    IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Login (LoginUserViewModel user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                // Chuyển object thành JSON
                var json = JsonSerializer.Serialize(user);
                // Tạo nội dung HTTP
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                // Gửi request POST với dữ liệu đã chuyển đổi thành JSON
                HttpResponseMessage response = await _httpClient.PostAsync("https://localhost:7075/api/AuthAPI/Login", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadFromJsonAsync<RequestMessage>();

                    if (responseBody != null && responseBody.Success == true)
                    {
                        var encodedJson = Uri.EscapeDataString(JsonSerializer.Serialize(responseBody.Result));
                        _httpContextAccessor.HttpContext.Response.Cookies.Append("ck.token", encodedJson);
                    }

                    // Trả về dữ liệu phản hồi
                    return RedirectToAction("Index");
                }
                else
                {
                    // Trả về lỗi nếu request không thành công
                    return View("Index", "Failed to login.");
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Error connecting to API: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
