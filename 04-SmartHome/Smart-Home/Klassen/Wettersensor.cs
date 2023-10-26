namespace Smart_Home.Klassen
{
	internal class Wettersensor
	{
		public double Temperatur { get; /*private*/ set; } = 20;
		public double WinGesch { get; /*private*/ set; } = 29;
		public bool Regen { get; /*private*/ set; } = false;
		public int UpdateInterval { get; /*private*/ set; } = 0;
		private Random rnd = new Random();
		private Haus Haus;
		public event EventHandler<Wetterdaten>? Changed;

		public Wettersensor(int updateInterval = 5)
		{
			UpdateInterval = updateInterval;
			Start();
		}


		private async void Start()
		{
			while (true)
			{
				await Task.Delay(TimeSpan.FromSeconds(UpdateInterval));
				Tick();
			}
		}

		public void Tick()
		{
			// 0.1 Schwankung pro Sekunde möglich
			Temperatur += rnd.Next(-1 * UpdateInterval, 1 * UpdateInterval + 1) / 10d;

			// 0.2 Schwankung pro Sekunde möglich
			WinGesch += rnd.Next(-2 * UpdateInterval, 2 * UpdateInterval + 1) / 10d;

			Regen = rnd.Next(2) == 0;

			// Korrekt runden
			Temperatur = Math.Round(Temperatur, 1);
			WinGesch = Math.Round(WinGesch, 1);

			Console.WriteLine();
			Console.WriteLine("Temperatur: " + Temperatur.ToString() + " °C");
			Console.WriteLine("Windgeschwindigkeit: " + WinGesch.ToString() + " km/h");
			Console.WriteLine("Regen: " + (Regen ? "Ja" : "Nein"));
			Changed?.Invoke(this, new Wetterdaten(Temperatur, WinGesch, Regen));
			//Haus.UpdateRooms();
		}

		/// <summary>
		/// <para>Erleichtert das Steuern des Wetters</para>
		/// <br>Pfeil nach oben: Temperatur + 1, Pfeil nach unten: Temperaut - 1 (min = 0)</br>
		/// <br>Pfeil nach rechts: WindGesch + 1, Pfeil nach links: WindGesch - 1 (min = 0)</br>
		/// <br>Plus(+): UpdateInterval + 1 Sek. (langsamer), Minus(-): UpdateInterval - 1 Sek. (schneller)</br>
		/// </summary>
		/// <returns></returns>
		public async Task ReadKeys()
		{
			await Task.Run(() =>
			{
				while (true)
				{
					var key = Console.ReadKey(true);
					switch (key.Key)
					{
						case ConsoleKey.UpArrow:
							Temperatur++;
							break;
						case ConsoleKey.DownArrow:
							Temperatur--;
							break;

						case ConsoleKey.RightArrow:
							WinGesch++;
							break;
						case ConsoleKey.LeftArrow:
							if (WinGesch >= 1)
								WinGesch--;
							break;

						case ConsoleKey.Spacebar:
							Regen = key.Modifiers != ConsoleModifiers.Shift;
							break;


						case ConsoleKey.Add:
						case ConsoleKey.OemPlus:
							UpdateInterval++;
							break;
						case ConsoleKey.D1:
							if (key.Modifiers == ConsoleModifiers.Shift)
								UpdateInterval++;
							break;
						case ConsoleKey.Subtract:
						case ConsoleKey.OemMinus:
							if (UpdateInterval >= 1)
								UpdateInterval--;
							break;

						default:
							return;
					}
				}
			});
		}

		internal class Wetterdaten
		{
			public readonly double Temperatur;
			public readonly double WindGesch;
			public readonly bool Regen;
			public Wetterdaten(double temperatur, double windGesch, bool regen)
			{
				Temperatur = temperatur;
				WindGesch = windGesch;
				Regen = regen;
			}
		}
	}
}
