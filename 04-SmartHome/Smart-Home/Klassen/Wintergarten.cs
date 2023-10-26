namespace Smart_Home.Klassen
{
	class Wintergarten : Raum, IJalousiesteuerung, IMarkisensteuerung
	{
		public Wintergarten(int temperatur = 20, int personen = 0) : base(temperatur, personen)
		{
		}

		private bool _MarkiseAusgefahren { get; set; }
		bool IMarkisensteuerung.MarkiseAusgefahren { get { return _MarkiseAusgefahren; } }

		void IMarkisensteuerung.CheckMarkise(Wettersensor.Wetterdaten daten)
		{
			bool newStatus = daten.WindGesch <= 30 && daten.Temperatur > this.Temperatur;
			if (newStatus == _MarkiseAusgefahren)
				return;

			if (newStatus)
				Console.WriteLine($"Die Markise von Wintergarten(id={Id}) wird ausgefahren");
			else
				Console.WriteLine($"Die Markise von Wintergarten(id={Id}) wird eingefahren");
			_MarkiseAusgefahren = newStatus;
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
