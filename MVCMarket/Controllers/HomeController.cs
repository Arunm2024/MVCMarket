using Microsoft.AspNetCore.Mvc;

namespace MvcDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
