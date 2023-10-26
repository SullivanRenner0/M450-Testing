namespace Smart_Home.Interfaces
{
	interface IJalousiesteuerung
	{
		bool JalousieUnten { get; }
		void CheckJalousie(Wettersensor.Wetterdaten daten);
	}
}
