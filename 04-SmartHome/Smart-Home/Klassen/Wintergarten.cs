namespace Smart_Home.Klassen
{
	class Wintergarten : Raum, IJalousiesteuerung, IMarkisensteuerung
	{
		public Wintergarten(int temperatur = 20, int personen = 0) : base(temperatur, personen)
		{
		}
		private bool markiseAusgefahren { get; set; }
		public bool MarkiseAusgefahren { get { return markiseAusgefahren; } }

		void IMarkisensteuerung.CheckMarkise(Wettersensor.Wetterdaten daten)
		{
			bool newStatus = daten.WindGesch <= 30 && daten.Temperatur > OptimalTemperature;
			if (newStatus == markiseAusgefahren)
				return;

			if (newStatus)
				Console.WriteLine($"Die Markise von Wintergarten(id={Id}) wird ausgefahren");
			else
				Console.WriteLine($"Die Markise von Wintergarten(id={Id}) wird eingefahren");
			markiseAusgefahren = newStatus;
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
