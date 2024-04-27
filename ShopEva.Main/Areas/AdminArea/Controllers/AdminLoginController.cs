using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopEva.Data.ViewModels;
using ShopEva.Services.RequestMessage;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace ShopEva.Main.Areas.AdminArea.Controllers
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

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel login)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                var json = JsonSerializer.Serialize(login);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync("https://localhost:7075/api/AuthAPI/Login", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadFromJsonAsync<RequestMessage>();

                    if (responseBody != null && responseBody.Success == true)
                    {
                        var encodedJson = Uri.EscapeDataString(JsonSerializer.Serialize(responseBody.Result));
                        _httpContextAccessor.HttpContext.Response.Cookies.Append("ck.token", encodedJson);
                    }

                    return RedirectToAction("Index", "AdminHome");
                }
                else
                {
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
