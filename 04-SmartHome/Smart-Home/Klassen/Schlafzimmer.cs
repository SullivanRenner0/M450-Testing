namespace Smart_Home.Klassen
{
	class Schlafzimmer : Raum, IHeizungsventil, IJalousiesteuerung
	{
		public Schlafzimmer(int optimalTemp = 20, int personen = 0) : base(optimalTemp, personen)
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

		private bool _JalousieUnten { get; set; }
		bool IJalousiesteuerung.JalousieUnten { get { return _JalousieUnten; } }
		public void CheckJalousie(Wettersensor.Wetterdaten daten)
		{
			if (Personen != 0 && _JalousieUnten)
			{
				Console.WriteLine($"Die Jalousie von diesem Raum(id={Id}) wird hochgefahren");
				_JalousieUnten = false;
				return;
			}
			if (Personen != 0)
				return;

			if (daten.Temperatur > OptimalTemperature)
			{
				if (!_JalousieUnten)
				{
					Console.WriteLine($"Die Jalousie von diesem Raum(id={Id}) wird heruntergefahren");
					_JalousieUnten = true;
				}
			}
			else
			{
				if (_JalousieUnten)//Hat zuvor geheizt, hört jetzt auf
				{
					Console.WriteLine($"Die Jalousie von diesem Raum(id={Id}) wird hochgefahren");
					_JalousieUnten = false;
				}
			}
		}
	}
}
