using Microsoft.AspNetCore.Mvc;

namespace MVP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var path = System.IO.Path.Combine("/index.html");

            return File(path, "text/html");
        }
    }
}
