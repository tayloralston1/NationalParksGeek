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

		public bool AddSurvey(Survey survey)
		{
			int rowsAffected = 0;
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

					rowsAffected = cmd.ExecuteNonQuery();
				}
			}
			catch(SqlException)
			{
				throw;
			}
			if (rowsAffected == 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public IList<SurveyResults> GetSurveys()
		{
			List<SurveyResults> topFiveParks = new List<SurveyResults>();
			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();

					string sql = "SELECT TOP 5 survey_result.parkCode , COUNT(*) as 'Favorites', park.parkName FROM survey_result Inner JOIN park ON park.parkCode = survey_result.parkCode GROUP BY survey_result.parkCode, parkName ORDER BY park.parkName ;";

					SqlCommand cmd = new SqlCommand(sql, conn);

					SqlDataReader reader = cmd.ExecuteReader();

					while (reader.Read())
					{
						SurveyResults survey = new SurveyResults();
						survey.ParkCode = Convert.ToString(reader["parkCode"]);
						survey.SurveyCount = Convert.ToInt32(reader["Favorites"]);
						survey.ParkName = Convert.ToString(reader["parkName"]);

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
