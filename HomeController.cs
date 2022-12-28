using Microsoft.AspNetCore.Mvc;

namespace StateManagement
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
