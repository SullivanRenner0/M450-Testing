namespace Smart_Home.Klassen
{
	class Wohnzimmer : Raum, IHeizungsventil, IJalousiesteuerung
	{
		public Wohnzimmer(int temperatur = 20, int personen = 0) : base(temperatur, personen)
		{
		}
		private bool _Heizt { get; set; }
		bool IHeizungsventil.Heizt { get { return _Heizt; } }
		public void CheckHeizung(Wettersensor.Wetterdaten daten)
		{
			if (daten.Temperatur < Temperatur)
			{
				if (!_Heizt)
				{
					Console.WriteLine($"Dieser Raum(id={Id}) wird geheizt");
					_Heizt = true;
				}
			}
			else
			{
				if (_Heizt)//Hat zuvor geheizt, hört jetzt auf
				{
					Console.WriteLine($"Dieser Raum(id={Id}) wird nicht mehr geheizt");
					_Heizt = false;
				}
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

			if (daten.Temperatur > Temperatur)
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
