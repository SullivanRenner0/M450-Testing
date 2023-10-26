namespace Smart_Home.Interfaces
{
	interface IMarkisensteuerung
	{
		public bool MarkiseAusgefahren { get; }
		public void CheckMarkise(Wettersensor.Wetterdaten daten);
	}
}
