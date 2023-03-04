using Microsoft.AspNetCore.Mvc;

namespace TactSoft___Software.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
