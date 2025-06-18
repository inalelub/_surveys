using Microsoft.AspNetCore.Mvc;

namespace _surveys.Controllers
{
	public class ResultsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
