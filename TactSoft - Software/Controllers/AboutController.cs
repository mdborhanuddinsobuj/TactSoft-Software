using Microsoft.AspNetCore.Mvc;

namespace TactSoft___Software.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
