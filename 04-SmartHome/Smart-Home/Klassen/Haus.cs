namespace Smart_Home.Klassen
{
	class Haus
	{
		private readonly List<Raum> Rooms;

		public readonly IWetterSensor Sensor;
		public int Personen { get { return Rooms.Sum(r => r.Personen); } }

		public Haus(IWetterSensor sensor, params Raum[] rooms)
		{
			Rooms = rooms.ToList();
			Sensor = sensor;
			Sensor.Changed += UpdateRooms;
		}

		public void UpdateRooms(object? sender, Wettersensor.Wetterdaten e)
		{
			Console.WriteLine("----------------------------------------");
			foreach (Raum room in Rooms)
			{
				(room as IHeizungsventil)?.CheckHeizung(e);
				(room as IMarkisensteuerung)?.CheckMarkise(e);
				(room as IJalousiesteuerung)?.CheckJalousie(e);
			}
			Console.WriteLine("----------------------------------------");
		}
	}
}
