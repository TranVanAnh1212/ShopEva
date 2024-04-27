using Microsoft.AspNetCore.Mvc;

namespace ShopEva.Main.Areas.AdminArea.Controllers
{
    public class AdminProductCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
