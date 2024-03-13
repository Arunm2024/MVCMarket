using Microsoft.AspNetCore.Mvc;

namespace MVCMarket.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
