using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Http;

namespace Capstone.Web.Controllers
{
	public class HomeController : Controller
	{
		/// <summary>
		/// Session Key
		/// </summary>
		private const string Session_Key = "userPreference";

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
			string pref = HttpContext.Session.GetString(Session_Key);
			if (pref == null)
			{
				pref = "f";
				HttpContext.Session.SetString(Session_Key, pref);
			}
			if (pref == "f")
			{
				pref = "f";
				HttpContext.Session.SetString(Session_Key, pref);
			}
			if (pref == "c")
			{
				pref = "c";
				HttpContext.Session.SetString(Session_Key, pref);
			}

			park.UserPreference = pref;
			return View(park);
		}

		public IActionResult TempUnit(string parkCode, string userPreference)
		{
			//set preference in session 
			
			HttpContext.Session.SetString(Session_Key, userPreference);

			return RedirectToAction("detail", "home",new {parkCode});

		}




		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
