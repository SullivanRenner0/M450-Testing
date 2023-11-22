using static Smart_Home.Klassen.Wettersensor;

namespace Smart_Home.Interfaces
{
	internal interface IWetterSensor
	{
		public event EventHandler<Wetterdaten>? Changed;
		public void Tick();
	}
}
