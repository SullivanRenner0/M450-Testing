namespace Smart_Home.Klassen
{
	public abstract class Raum
	{
		public double OptimalTemperature;
		public int Personen;
		public readonly int Id;
		private static int nextId = 1;

		public Raum(double temperatur = 20, int personen = 0)
		{
			OptimalTemperature = temperatur;
			Personen = personen;
			Id = nextId++;
		}
	}
}
