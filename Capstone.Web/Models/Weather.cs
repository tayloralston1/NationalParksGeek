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
		public int FahLow { get; set; }
		public int FahHigh { get; set; }
		public int CelHigh
		{
			get
			{
				int celHigh = (FahHigh-32) * (5 / 9);
				return celHigh;
			}
		}
		public int CelLow
		{
			get
			{
				int celLow = (FahLow - 32) * (5 / 9);
				return celLow;
			}
		}
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

		public string TempAdvisory(int FahHigh, int FahLow)
		{
			string advisory = "";
			if (FahHigh > 75)
			{
				advisory = "Bring an extra gallon of H2O";
			}
			else if (FahHigh - FahLow > 20)
			{
				advisory = "Wear breathable layers.";
			}
			else if (FahLow < 20)
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
