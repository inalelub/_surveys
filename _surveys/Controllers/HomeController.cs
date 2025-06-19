using _surveys.Data;
using _surveys.Models;
using Microsoft.AspNetCore.Mvc;

namespace _surveys.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _db = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(Survey model, string fullname, string email, string radiostation, string contactno, string eatout, string movie, string tv)
        {
            var srv = new Survey
            {
                FullNames = fullname,
                ContactNumber = contactno,
                DOB = model.DOB,
                EmailAddress = email,
                FavouriteFood = model.FavouriteFood,
                ScaleEatOut = eatout,
                ScaleRadio = radiostation,
                ScaleMovie = movie,
                ScaleTV = tv
            };
            
            _db.Surveys.Add(srv);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
