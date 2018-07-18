using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
	public class SurveyDAL : ISurveyDAL
	{
		private readonly string connectionString;
		public SurveyDAL(string connectionString)
		{
			this.connectionString = connectionString;
		}
		public Survey AddSurvey()
		{
			throw new NotImplementedException();
		}

		public IList<Survey> GetSurveys()
		{
			throw new NotImplementedException();
		}
	}
}
