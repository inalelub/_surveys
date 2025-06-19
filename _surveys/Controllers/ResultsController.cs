using _surveys.Data;
using Microsoft.AspNetCore.Mvc;

namespace _surveys.Controllers
{
    public class ResultsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ResultsController(ApplicationDbContext context)
        {
            _db = context;
        }

        /// <summary>
        /// The initial view of the results page
        /// </summary>
        /// <returns>The view</returns>
        public IActionResult Index()
        {
            // Data to represent in the survey result page
            TempData["TotalSurvey"] = TotalSurvey();
            TempData["AverageAge"] = AverageAge();
            TempData["OldestPerson"] = OldestPerson();
            TempData["YoungestPerson"] = YoungestPerson();

            TempData["LovePizza"] = PercentagePeopleWhoLovePizza();
            TempData["LovePasta"] = PercentagePeopleWhoLovePasta();
            TempData["LovePapWors"] = PercentagePeopleWhoLovePapWors();

            TempData["AverageMovies"] = AverageWatchMovies();
            TempData["AverageRadio"] = AverageListenRadio();
            TempData["AverageEatOut"] = AverageEatOut();
            TempData["AverageTv"] = AverageWatchTv();

            return View(_db.Surveys.ToList());
        }

        /* DATA ANALYSIS */

        /// <summary>
        /// Total number of surveys completed
        /// </summary>
        /// <returns>The total</returns>
        public int TotalSurvey()
        {
            return _db.Surveys.Count();
        }

        /// <summary>
        /// Average age of the people that participated in the survey
        /// </summary>
        /// <returns>Average age</returns>
        public string AverageAge()
        {
            var birthDates = _db.Surveys.Select(s => s.DOB).ToList();

            if (birthDates.Count == 0)
            {
                return "N/A (No surveys completed)";
            }

            var today = DateOnly.FromDateTime(DateTime.Today);

            var ages = new List<int>();

            foreach (var dob in birthDates)
            {
                var age = today.Year - dob.Year;

                // Adjust age if the birthday hasn't occurred yet this year
                if (dob.Month > today.Month || (dob.Month == today.Month && dob.Day > today.Day))
                {
                    age--;
                }

                ages.Add(age);
            }

            var averageAge = ages.Average();

            return averageAge.ToString("F2");
        }

        /// <summary>
        /// Oldest person that participated in the survey
        /// </summary>
        /// <returns>Oldest person</returns>
        public string OldestPerson()
        {
            // Find the survey entry with the earliest DateOfBirth
            var oldestSurvey = _db.Surveys.OrderBy(s => s.DOB).FirstOrDefault();

            if (oldestSurvey == null)
            {
                return "No surveys completed yet.";
            }

            // Calculate the age of the oldest person
            var today = DateOnly.FromDateTime(DateTime.Today);
            var age = today.Year - oldestSurvey.DOB.Year;

            if (oldestSurvey.DOB.Month > today.Month ||
                (oldestSurvey.DOB.Month == today.Month && oldestSurvey.DOB.Day > today.Day))
            {
                age--;
            }

            return $"{age}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string YoungestPerson()
        {
            // Find the survey entry with the latest DateOfBirth
            var youngestSurvey = _db.Surveys.OrderByDescending(s => s.DOB).FirstOrDefault();

            if (youngestSurvey == null)
            {
                return "No surveys completed yet.";
            }

            var today = DateOnly.FromDateTime(DateTime.Today);
            var age = today.Year - youngestSurvey.DOB.Year;

            if (youngestSurvey.DOB.Month > today.Month ||
                (youngestSurvey.DOB.Month == today.Month && youngestSurvey.DOB.Day > today.Day))
            {
                age--;
            }

            return $"{age}";
        }

        /// <summary>
        /// Percentage of people who like pizza
        /// </summary>
        /// <returns>The percentage</returns>
        public string PercentagePeopleWhoLovePizza()
        {
            var totalSurveys = _db.Surveys.Count();

            if (totalSurveys == 0)
            {
                return 0.ToString("F1");
            }

            var surveysWithFood = _db.Surveys.Select(s => s.FavouriteFood).ToList();
            
            int pizzaLoversCount = surveysWithFood
                .Count(foodList => foodList.Any(food => food.Equals("Pizza", StringComparison.OrdinalIgnoreCase)));

            // Calculate the percentage
            var percentage = (double)pizzaLoversCount / totalSurveys * 100;

            // Store the result, formatted to 1 decimal place
            return percentage.ToString("F1");
        }

        /// <summary>
        /// Percentage of people who like pizza 
        /// </summary>
        /// <returns>The percentage</returns>
        public string PercentagePeopleWhoLovePasta()
        {
            var totalSurveys = _db.Surveys.Count();

            if (totalSurveys == 0)
            {
                return 0.ToString("F1");
            }

            var surveysWithFood = _db.Surveys.Select(s => s.FavouriteFood).ToList();
            
            int pastaLoversCount = surveysWithFood
                .Count(foodList => foodList.Any(food => food.Equals("Pasta", StringComparison.OrdinalIgnoreCase)));

            var percentage = (double)pastaLoversCount / totalSurveys * 100;

            return percentage.ToString("F1");
        }

        /// <summary>
        /// Percentage of people who like pap and wors 
        /// </summary>
        /// <returns>The percentage</returns>
        public string PercentagePeopleWhoLovePapWors()
        {
            var totalSurveys = _db.Surveys.Count();

            if (totalSurveys == 0)
            {
                return 0.ToString("F1");
            }

            var surveysWithFood = _db.Surveys.Select(s => s.FavouriteFood).ToList();
            
            int papWorsLoversCount = surveysWithFood
                .Count(foodList => foodList.Any(food => food.Equals("Pasta", StringComparison.OrdinalIgnoreCase)));

            var percentage = (double)papWorsLoversCount / totalSurveys * 100;

            return percentage.ToString("F1");
        }

        /// <summary>
        ///	Average of people who like to watch movies, but we are calculating the average
        /// </summary>
        /// <returns>The average</returns>
        public string AverageWatchMovies()
        {
            var movieRatings = _db.Surveys.Select(s => s.ScaleMovie).ToList()
                .Where(rating => int.TryParse(rating, out _)).Select(rating => int.Parse(rating));

            if (!movieRatings.Any())
            {
                return 0.ToString("F1");
            }

            var averageRating = movieRatings.Average();
            return averageRating.ToString("F1"); // Format to 1 decimal place
        }

        /// <summary>
        ///	Average of people who like to listen to radio, but we are calculating the average
        /// </summary>
        /// <returns>The average</returns>
        public string AverageListenRadio()
        {
            var radioRatings = _db.Surveys.Select(s => s.ScaleTV).ToList().Where(rating => int.TryParse(rating, out _))
                .Select(rating => int.Parse(rating));

            if (!radioRatings.Any())
            {
                return 0.ToString("F1");
            }

            var averageRating = radioRatings.Average();
            return averageRating.ToString("F1"); // Format to 1 decimal place
        }

        /// <summary>
        ///	Average of people who like to eat out, but we are calculating the average
        /// </summary>
        /// <returns>The average</returns>
        public string AverageEatOut()
        {
            var eatOutRatings = _db.Surveys.Select(s => s.ScaleEatOut).ToList()
                .Where(rating => int.TryParse(rating, out _)).Select(rating => int.Parse(rating));

            if (!eatOutRatings.Any())
            {
                return "N/A (No valid ratings)";
            }

            var averageRating = eatOutRatings.Average();
            return averageRating.ToString("F1"); // Format to 1 decimal place
        }

        /// <summary>
        ///	Average of people who like to watch TV, but we are calculating the average
        /// </summary>
        /// <returns>The average</returns>
        public string AverageWatchTv()
        {
            var tvRatings = _db.Surveys.Select(s => s.ScaleTV).ToList().Where(rating => int.TryParse(rating, out _))
                .Select(rating => int.Parse(rating));

            if (!tvRatings.Any())
            {
                return 0.ToString("F1");
            }

            var averageRating = tvRatings.Average();
            return averageRating.ToString("F1"); // Format to 1 decimal place
        }
    }
}