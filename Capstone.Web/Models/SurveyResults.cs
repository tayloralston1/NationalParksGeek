﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class SurveyResults
    {
		public string ParkCode { get; set;}
		public string ParkName { get; set; }
		public int SurveyCount { get; set; }
		public Park Park { get; set; }

	}
}
