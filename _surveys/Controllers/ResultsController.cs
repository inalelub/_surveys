using Microsoft.AspNetCore.Mvc;

namespace _surveys.Controllers
{
	public class ResultsController : Controller
	{
        public ResultsController()
        {
            
        }

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
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
			TempData["AverageTV"] = AverageWatchTV();

			return View();
		}

		/* DATA ANALYSIS */

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public int TotalSurvey()
		{
			return 0;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public int AverageAge()
		{
			return 0;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string OldestPerson()
		{
			return string.Empty;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string YoungestPerson()
		{

			return string.Empty;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public decimal PercentagePeopleWhoLovePizza()
		{
			return 0;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public decimal PercentagePeopleWhoLovePasta()
		{
			return 0;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public decimal PercentagePeopleWhoLovePapWors()
		{
			return 0;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public decimal AverageWatchMovies()
		{
			return 0;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public decimal AverageListenRadio()
		{
			return 0;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public decimal AverageEatOut()
		{
			return 0;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public decimal AverageWatchTV()
		{
			return 0;
		}

	}
}
