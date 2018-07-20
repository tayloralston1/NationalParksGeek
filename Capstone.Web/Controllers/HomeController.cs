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

		/// <summary>
		/// gives us access to DAL for park information and weather information from database
		/// </summary>
		/// <param name="dal"></param>
		/// <param name="wdal"></param>
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
			switch (pref)
			{
				case null:
					pref = "f";
					HttpContext.Session.SetString(Session_Key, pref);
					break;
				case "c":
					HttpContext.Session.SetString(Session_Key, pref);
					break;
				case "f":
					HttpContext.Session.SetString(Session_Key, pref);
					break;
				default:
					break;
			}

			park.UserPreference = pref;
			return View(park);
		}

		/// <summary>
		/// takes preference from detail page based on unit selected via button
		/// </summary>
		/// <param name="parkCode"></param>
		/// <param name="userPreference"></param>
		/// <returns></returns>
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
