using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;

namespace Capstone.Web.Controllers
{
	public class HomeController : Controller
	{
		private const string Session_Key = "User_ForC";
		private readonly IParkDAL dal;
		private readonly IWeatherDAL wdal;

		public HomeController(IParkDAL dal, IWeatherDAL wdal)
		{
			this.dal = dal;
			this.wdal = wdal;
		}

		public IActionResult Index()
		{
			var parks = dal.GetParks();

			return View(parks);
		}

		public IActionResult Detail(string parkCode)
		{
			var park = dal.GetPark(parkCode);
			park.Forecast = wdal.FiveDayForecast(parkCode);
			return View(park);
		}




		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
