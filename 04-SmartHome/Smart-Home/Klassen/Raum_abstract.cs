namespace Smart_Home.Klassen
{
	abstract class Raum
	{
		public readonly double Temperatur = 0;
		public int Personen;
		public readonly int Id;
		private static int nextId = 1;

		public Raum(double temperatur, int personen = 0)
		{
			Temperatur = temperatur;
			Personen = personen;
			Id = nextId++;
		}

		public void Update(Wettersensor.Wetterdaten daten)
		{
			(this as IHeizungsventil)?.CheckHeizung(daten);
			(this as IMarkisensteuerung)?.CheckMarkise(daten);
			(this as IJalousiesteuerung)?.CheckJalousie(daten);
		}
	}
}
