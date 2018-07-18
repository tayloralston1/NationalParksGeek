using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
	public class Weather
	{
		public string ParkCode { get; set; }
		public int FiveDayForecastValue { get; set; }
		public int Low { get; set; }
		public int High { get; set; }
		public string Forecast { get; set; }

		//suggested gear based on temp
		public string GetTheGear(string forecast)
		{
			string gear = "";
			switch (forecast)
			{

				case "snow":
					gear = "Pack snowshoes";
					break;
				case "rain":
					gear = "Pack rain gear and two galosh";
					break;
				case "thunderstorms":
					gear = "Seek shelter and avoid hiking on exposed ridges";
					break;
				case "sunny":
					gear = "Sky's out Thighs out! Wear Sunblock!!";
					break;
				default:
					gear = "Come as you are!";
					break;
			}
			return gear;
		}

		public string TempAdvisory(int high, int low)
		{
			string advisory = "";
			if (high > 75)
			{
				advisory = "Bring an extra gallon of H2O";
			}
			else if (high - low > 20)
			{
				advisory = "Wear breathable layers.";
			}
			else if (low < 20)
			{
				advisory = "WARNING! YOU WILL FREEZE TO DEATH!!!!";
			}
			else
			{
				advisory = "none";
			}
			return advisory;

		}


		//convert temp from F to C

	}
}
