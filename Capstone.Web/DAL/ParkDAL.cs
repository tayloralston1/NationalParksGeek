using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
	public class ParkDAL : IParkDAL
	{
		/// <summary>
		/// 
		/// </summary>
		private readonly string connectionString;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="connectionString"></param>
		public ParkDAL(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public Park GetPark(string parkCode)
		{ 
			return GetParks().FirstOrDefault(p => p.ParkCode == parkCode);
		}

		/// <summary>
		/// Builds list of Parks via connection to DB
		/// </summary>
		/// <returns>List of Parks</returns>
		public IList<Park> GetParks()
		{
			List<Park> parks = new List<Park>();
			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();

					string sql = "SELECT * FROM park";

					SqlCommand cmd = new SqlCommand(sql, conn);

					SqlDataReader reader = cmd.ExecuteReader();

					while (reader.Read())
					{
						Park park = new Park();
						park.ParkCode = Convert.ToString(reader["parkCode"]);
						park.ParkName = Convert.ToString(reader["parkName"]);
						park.State = Convert.ToString(reader["state"]);
						park.Acreage = Convert.ToInt32(reader["acreage"]);
						park.ElevationInFt = Convert.ToInt32(reader["elevationInFeet"]);
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

						parks.Add(park);
					}
				}
			}
			catch(SqlException)
			{
				throw;
			}
			return parks;
		}
	}
}
