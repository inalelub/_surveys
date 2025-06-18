using _surveys.Models;
using Microsoft.AspNetCore.Mvc;

namespace _surveys.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Survey model)
        {
            return View();
        }

    }
}
