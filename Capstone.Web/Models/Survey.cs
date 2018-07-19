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
		//public static List<SelectListItem> Parks = new List<SelectListItem>()
		//{
		//	new SelectListItem() {Text = "Glacier National Park", Value = "GNP"},
		//}
    }
}
