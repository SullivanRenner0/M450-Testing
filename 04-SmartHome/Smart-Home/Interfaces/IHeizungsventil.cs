namespace Smart_Home.Interfaces
{
	interface IHeizungsventil
	{
		bool Heizt { get; }
		public void CheckHeizung(Wettersensor.Wetterdaten daten);
	}
}
