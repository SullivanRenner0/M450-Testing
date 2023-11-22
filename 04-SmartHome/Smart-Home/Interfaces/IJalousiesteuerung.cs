namespace Smart_Home.Interfaces
{
	public interface IJalousiesteuerung
	{
		bool JalousieUnten { get; }
		void CheckJalousie(Wettersensor.Wetterdaten daten);
	}
}
