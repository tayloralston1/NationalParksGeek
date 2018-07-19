using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.Models
{
	public class Survey
	{
		public int SurveyID { get; set; }
		[Display(Name = "Park")]
		public string ParkCode { get; set; }
		public string Email { get; set; }
		public string State { get; set; }
		public string ActivityLevel { get; set; }
		public int SurveyCount { get; set; }
		


		public static List<SelectListItem> actives = new List<SelectListItem>()
		{
			new SelectListItem() {Text = "inactive", Value = "inactive"},
			new SelectListItem() {Text = "sedentary", Value = "sedentary"},
			new SelectListItem() {Text = "active", Value = "active"},
			new SelectListItem() {Text = "extremely active", Value = "extremely active"}
		};

	}
}
