using Microsoft.AspNetCore.Mvc;

namespace TactSoft___Software.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
