using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
	public class WeatherDAL : IWeatherDAL
	{
		private readonly string connectionString;
		public WeatherDAL(string connectionString)
		{
			this.connectionString = connectionString;
		}
		public IList<Weather> FiveDayForecast()
		{
			throw new NotImplementedException();
		}
	}
}
