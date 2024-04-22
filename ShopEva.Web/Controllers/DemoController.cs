using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShopEva.Web.Controllers
{
    public class DemoController : Controller
    {
        private readonly ILogger<DemoController> _logger;
        private readonly HttpClient _httpClient;

        public DemoController(ILogger<DemoController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("https://localhost:7075/api/ProductAPI/get_all?page=1");

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var content = await httpResponseMessage.Content.ReadAsStringAsync();

                return View("Index", content);
            }
            else
            {
                // Xử lý lỗi (nếu có)
                return StatusCode((int)httpResponseMessage.StatusCode, "Failed to fetch data from the API");
            }
        }
    }
}
