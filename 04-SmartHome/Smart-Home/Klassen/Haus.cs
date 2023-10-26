namespace Smart_Home.Klassen
{
	class Haus
	{
		public Raum[] Raume;
		public Wettersensor Sensor;
		public int Personen { get { return Raume.Sum(r => r.Personen); } }

		public Haus(int updateInterval, params Raum[] rooms)
		{
			Raume = rooms;
			Sensor = new Wettersensor(updateInterval);
			Sensor.Changed += UpdateRooms;
		}

		public void UpdateRooms(object? sender, Wettersensor.Wetterdaten e)
		{
			Console.WriteLine("----------------------------------------");
			foreach (Raum raum in Raume)
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
