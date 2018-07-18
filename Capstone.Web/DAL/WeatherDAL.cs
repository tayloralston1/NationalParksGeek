using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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


		public IList<Weather> FiveDayForecast(string parkCode)
		{
			IList<Weather> weathers = new List<Weather>();
			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();

					string sql = "SELECT * FROM weather WHERE parkCode = @parkCode;";

					SqlCommand cmd = new SqlCommand(sql, conn);

					cmd.Parameters.AddWithValue("@parkCode", parkCode);

					SqlDataReader reader = cmd.ExecuteReader();

					while (reader.Read())
					{
						Weather weather = new Weather();
						weather.ParkCode = Convert.ToString(reader["parkCode"]);
						weather.FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]);
						weather.Low = Convert.ToInt32(reader["low"]);
						weather.High = Convert.ToInt32(reader["high"]);
						weather.Forecast = Convert.ToString(reader["forecast"]);

						weathers.Add(weather);
					}
				}
			}
			catch (SqlException)
			{
				throw;
			}
			return weathers;

		}
	}
}
