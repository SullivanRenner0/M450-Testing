namespace Smart_Home.Klassen
{
	public class WC : Raum, IHeizungsventil
	{
		public WC(double temperatur = 20, int personen = 0) : base(temperatur, personen)
		{
		}
		private bool heizt { get; set; }
		public bool Heizt { get { return heizt; } }
		public void CheckHeizung(Wettersensor.Wetterdaten daten)
		{
			if (daten.Temperatur < OptimalTemperature)
			{
				if (!heizt)
					Console.WriteLine($"{GetType().Name} (id={Id}) wird jetzt geheizt");
				heizt = true;
			}
			else
			{
				if (heizt)
					Console.WriteLine($"{GetType().Name} (id={Id}) wird jetzt nicht mehr geheizt");
				heizt = false;
			}
		}
	}
}
