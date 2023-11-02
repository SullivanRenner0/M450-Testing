using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Smart_Home.Klassen.Wettersensor;

namespace Smart_Home.Interfaces
{
	internal interface IWetterSensor
	{
		public event EventHandler<Wetterdaten>? Changed;
		public void Tick();
	}
}
