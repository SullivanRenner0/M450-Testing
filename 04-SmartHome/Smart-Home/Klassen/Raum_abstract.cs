namespace Smart_Home.Klassen
{
	abstract class Raum
	{
		public double OptimalTemperature;
		public int Personen;
		public readonly int Id;
		private static int nextId = 1;

		public Raum(double tempearur = 20, int personen = 0)
		{
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
