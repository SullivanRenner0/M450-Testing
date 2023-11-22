namespace Smart_Home.Klassen
{
	public class Wintergarten : Raum, IJalousiesteuerung, IMarkisensteuerung
	{
		public Wintergarten(double temperatur = 20, int personen = 0) : base(temperatur, personen)
		{
		}

		private bool markiseAusgefahren { get; set; }
		public bool MarkiseAusgefahren { get { return markiseAusgefahren; } }

		public void CheckMarkise(Wettersensor.Wetterdaten daten)
		{
			bool newStatus = daten.WindGesch <= Constants.MarkiseMaxWindSpeed && daten.Temperatur > OptimalTemperature && (Constants.MarkiseCanBeUsedInRain ? true : !daten.Regen);
            if (newStatus == markiseAusgefahren)
				return;

			markiseAusgefahren = newStatus;
			if (markiseAusgefahren)
				Console.WriteLine($"Die Markise von {GetType().Name} (id={Id}) wird ausgefahren");
			else
				Console.WriteLine($"Die Markise von {GetType().Name} (id={Id}) wird eingefahren");
		}

		private bool jalousieUnten { get; set; }
		public bool JalousieUnten { get { return jalousieUnten; } }
		public void CheckJalousie(Wettersensor.Wetterdaten daten)
		{
			if (daten.Temperatur > OptimalTemperature && Personen == 0)
			{
				if (!jalousieUnten)
					Console.WriteLine($"Die Jalousie von diesem {GetType().Name} (id={Id}) wird heruntergefahren");
				jalousieUnten = true;
			}
			else if (jalousieUnten) // Hat zuvor geheizt, hört jetzt auf
			{
				if (jalousieUnten)
					Console.WriteLine($"Die Jalousie von diesem {GetType().Name} (id={Id}) wird hochgefahren");
				jalousieUnten = false;
			}
		}
	}
}
