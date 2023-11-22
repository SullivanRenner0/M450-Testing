namespace Smart_Home.Klassen
{
	public class WC : Raum, IHeizungsventil
	{
		public WC(double temperatur = 20, int personen = 0) : base(temperatur, personen)
		{
		}
		private bool _heizt { get; set; }
		public bool Heizt { get { return _heizt; } }
		public void CheckHeizung(Wettersensor.Wetterdaten daten)
		{
			if (daten.Temperatur < OptimalTemperature)
			{
				if (!_heizt)
					Console.WriteLine($"{GetType().Name} (id={Id}) wird jetzt geheizt");
				_heizt = true;
			}
			else
			{
				if (_heizt)
					Console.WriteLine($"{GetType().Name} (id={Id}) wird jetzt nicht mehr geheizt");
				_heizt = false;
			}
		}
	}
}
