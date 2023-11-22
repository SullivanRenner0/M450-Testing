namespace Smart_Home.Interfaces
{
	public interface IHeizungsventil
	{
		bool Heizt { get; }
		public void CheckHeizung(Wettersensor.Wetterdaten daten);
	}
}
