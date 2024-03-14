using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopEva.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HomeAPIController : ControllerBase
    {
        [HttpGet("TestMethod")]
        public IActionResult TestMethod()
        {
            return Ok(@"Hello");
        }
    }
}
