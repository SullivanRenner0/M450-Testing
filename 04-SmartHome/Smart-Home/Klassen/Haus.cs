namespace Smart_Home.Klassen
{
	class Haus
	{
		private readonly List<Raum> Rooms;

		public readonly Wettersensor Sensor;
		public int Personen { get { return Rooms.Sum(r => r.Personen); } }

		public Haus(Wettersensor sensor, params Raum[] rooms)
		{
			Rooms = rooms.ToList();
			Sensor = sensor;
			Sensor.Changed += UpdateRooms;
		}

		public void UpdateRooms(object? sender, Wettersensor.Wetterdaten e)
		{
			Console.WriteLine("----------------------------------------");
			foreach (Raum raum in Rooms)
			{
				raum.Update(e);
			}
			Console.WriteLine("----------------------------------------");
		}

		/// <summary>
		/// <para>Erleichtert das Steuern des Wetters</para>
		/// <br>Pfeil nach oben: Temperatur + 1, Pfeil nach unten: Temperaut - 1 (min = 0)</br>
		/// <br>Pfeil nach rechts: WindGesch + 1, Pfeil nach links: WindGesch - 1 (min = 0)</br>
		/// <br>Plus(+): UpdateInterval + 1 Sek. (langsamer), Minus(-): UpdateInterval - 1 Sek. (schneller)</br>
		/// </summary>
		/// <returns></returns>
		public async Task WaitForExit()
		{
			await Sensor.ReadKeys();
		}
	}
}
