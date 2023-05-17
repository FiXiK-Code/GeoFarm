using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
