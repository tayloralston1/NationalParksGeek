using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
			List<Survey> topFiveParks = new List<Survey>();
			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();

					string sql = "SELECT TOP 5 parkCode , COUNT(*) as'Favorites' FROM survey_result GROUP BY parkCode ORDER BY Favorites DESC; ";

					SqlCommand cmd = new SqlCommand(sql, conn);

					SqlDataReader reader = cmd.ExecuteReader();

					while (reader.Read())
					{
						Survey survey = new Survey();
						survey.SurveyID = Convert.ToString(reader["parkCode"]);
						survey.ParkName = Convert.ToString(reader["parkName"]);
						survey.State = Convert.ToString(reader["state"]);
						survey.Acreage = Convert.ToInt32(reader["acreage"]);
						survey.ElevationInFt = Convert.ToInt32(reader["elevationInFeet"]);
						park.MilesOfTrail = Convert.ToDouble(reader["milesOfTrail"]);
						park.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
						park.Climate = Convert.ToString(reader["climate"]);
						park.YearFounded = Convert.ToInt32(reader["yearFounded"]);
						park.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
						park.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
						park.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
						park.ParkDescription = Convert.ToString(reader["parkDescription"]);
						park.EntryFee = Convert.ToInt32(reader["entryFee"]);
						park.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);

						topFiveParks.Add(park);
					}
				}
			}
			catch (SqlException)
			{
				throw;
			}
			return topFiveParks;
		}
	}
	}
}
