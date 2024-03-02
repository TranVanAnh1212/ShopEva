using Microsoft.AspNetCore.Mvc;

namespace ShopEva.Web.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
