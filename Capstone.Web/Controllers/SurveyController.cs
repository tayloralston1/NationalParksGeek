using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.Controllers
{
	public class SurveyController : Controller
	{
		private readonly IParkDAL dal;
		private readonly ISurveyDAL sdal;

		public SurveyController(IParkDAL dal, ISurveyDAL sdal)
		{
			this.dal = dal;
			this.sdal = sdal;
		}

		/// <summary>
		/// displaying form for survey, takes in park code via database
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Index()
		{
			Survey newSurvey = new Survey();
			var parkCodes = dal.GetParks();
			var options = parkCodes.Select(parkCode => new SelectListItem() { Text = parkCode.ParkName, Value = parkCode.ParkCode });
			ViewBag.ParkCode = options;

			return View();
		}

		/// <summary>
		/// adds user provided survey information to database
		/// </summary>
		/// <param name="newSurvey"></param>
		/// <returns></returns>
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Index(Survey newSurvey)
		{
			if (ModelState.IsValid)
			{
			sdal.AddSurvey(newSurvey);
			TempData["Show_Message"] = true;
			return RedirectToAction("surveyresults","survey");
			}
			var parkCodes = dal.GetParks();
			var options = parkCodes.Select(parkCode => new SelectListItem() { Text = parkCode.ParkName, Value = parkCode.ParkCode });
			ViewBag.ParkCode = options;

			return View();
		}

		/// <summary>
		/// retrieves top 5 parks based on number of surveys from DB
		/// </summary>
		/// <returns></returns>
		public IActionResult SurveyResults()
		{
			IList<SurveyResults> results = new List<SurveyResults>();

			results = sdal.GetSurveys();
			
			return View(results);
		}




	}
}
public class ParkCode
{
	public string Name { get; set; }
	public string Code { get; set; }
}