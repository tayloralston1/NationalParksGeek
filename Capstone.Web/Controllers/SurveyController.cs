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
		[HttpGet]
		public IActionResult Index()
		{
			var parkCodes = dal.GetParks();
			var options = parkCodes.Select(parkCode => new SelectListItem() { Text = parkCode.ParkName, Value = parkCode.ParkCode });
			ViewBag.ParkCode = options;
			return View();
			
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Index(Survey newSurvey)
		{
			sdal.AddSurvey(newSurvey);
			return RedirectToAction("surveyresults","survey");


		}

		public IActionResult SurveyResults()
		{
			var results = new SurveyResults();
			var surveys = sdal.GetSurveys();
			
			return View(surveys);
		}
		//[HttpGet]
		//public IActionResult New()

		//{
		//	//var parkCodes = dal.GetParks();
		//	//var options = parkCodes.Select(parkCode => new SelectListItem() { Text = parkCode.ParkName, Value = parkCode.ParkCode });
		//	//ViewBag.ParkCode = options;
		//	return View();
		//}



	}
}
public class ParkCode
{
	public string Name { get; set; }
	public string Code { get; set; }
}