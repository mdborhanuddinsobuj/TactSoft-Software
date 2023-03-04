using Microsoft.AspNetCore.Mvc;

namespace TactSoft___Software.Controllers
{
    public class PortfolioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
