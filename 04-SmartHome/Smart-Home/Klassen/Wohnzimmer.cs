namespace Smart_Home.Klassen
{
	class Wohnzimmer : Raum, IHeizungsventil, IJalousiesteuerung
	{
		public Wohnzimmer(int optimalTemp = 20, int personen = 0) : base(optimalTemp, personen)
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

		private bool jalousieUnten { get; set; }
		public bool JalousieUnten { get { return jalousieUnten; } }
		public void CheckJalousie(Wettersensor.Wetterdaten daten)
		{

			if (Personen != 0 && jalousieUnten)
			{
				Console.WriteLine($"Die Jalousie von diesem {GetType().Name} (id={Id}) wird hochgefahren");
				jalousieUnten = false;
				return;
			}

			if (Personen == 0)
				return;

			if (daten.Temperatur > OptimalTemperature)
			{
				if (!jalousieUnten)
				{
					Console.WriteLine($"Die Jalousie von diesem {GetType().Name} (id={Id}) wird heruntergefahren");
				}
				jalousieUnten = true;
			}
			else if (jalousieUnten) // Hat zuvor geheizt, hört jetzt auf
			{
				Console.WriteLine($"Die Jalousie von diesem {GetType().Name} (id={Id}) wird hochgefahren");
				jalousieUnten = false;
			}
		}
	}
}
