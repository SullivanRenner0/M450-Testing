namespace Smart_Home.Klassen
{
	class Schlafzimmer : Raum, IHeizungsventil, IJalousiesteuerung
	{
		public Schlafzimmer(int optimalTemp = 20, int personen = 0) : base(optimalTemp, personen)
		{
		}

		private bool heizt { get; set; }
		bool IHeizungsventil.Heizt { get { return heizt; } }
		void IHeizungsventil.CheckHeizung(Wettersensor.Wetterdaten daten)
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
		bool IJalousiesteuerung.JalousieUnten { get { return jalousieUnten; } }
		void IJalousiesteuerung.CheckJalousie(Wettersensor.Wetterdaten daten)
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
