using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopEva.Web.Models;
using System.Diagnostics;

namespace ShopEva.Web.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Kiểm tra phiên làm việc của người dùng ở đây
            //if (!User.Identity.IsAuthenticated)
            //{
            //    // Nếu không được xác thực, chuyển hướng đến trang đăng nhập
            //    return RedirectToAction("Index", "LoginPage_Admin");
            //}
            //else
            //{
            //    // Kiểm tra thời gian hết hạn của phiên làm việc và đăng xuất nếu cần
            //    var expiryTime = _httpContextAccessor.HttpContext.User.Claims
            //        .FirstOrDefault(c => c.Type == "exp")?.Value;

            //    if (expiryTime != null && DateTimeOffset.FromUnixTimeSeconds(long.Parse(expiryTime)) <= DateTimeOffset.UtcNow)
            //    {
            //        // Đăng xuất người dùng và chuyển hướng đến trang đăng nhập
            //        // Code xử lý đăng xuất ở đây
            //        return RedirectToAction("Index", "LoginPage_Admin");
            //    }
            //    else
            //    {
            //        // Nếu phiên làm việc còn hiệu lực, hiển thị trang Index
            //        return View();
            //    }
            //}

            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
