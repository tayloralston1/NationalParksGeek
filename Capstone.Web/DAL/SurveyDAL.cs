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

		public void AddSurvey(Survey survey)
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();

					string sql = "INSERT INTO survey_result VALUES (@parkCode, @emailAddress, @state, @activityLevel);";
					SqlCommand cmd = new SqlCommand(sql, conn);
					cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
					cmd.Parameters.AddWithValue("@emailAddress", survey.Email);
					cmd.Parameters.AddWithValue("@state", survey.State);
					cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);

					cmd.ExecuteNonQuery();
				}
			}
			catch(SqlException)
			{
				throw;
			}
			
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
						//survey.SurveyID = Convert.ToInt32(reader["surveyId"]);
						survey.ParkCode = Convert.ToString(reader["parkCode"]);
						//survey.State = Convert.ToString(reader["state"]);
						//survey.Email = Convert.ToString(reader["emailAddress"]);
						//survey.ActivityLevel = Convert.ToString(reader["activityLevel"]);
						survey.SurveyCount = Convert.ToInt32(reader["Favorites"]);

						topFiveParks.Add(survey);
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
