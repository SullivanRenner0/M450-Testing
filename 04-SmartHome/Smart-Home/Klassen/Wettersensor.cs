namespace Smart_Home.Klassen
{
	public class Wettersensor : IWetterSensor
	{
		public double Temperatur { get; private set; } = 20;
		public double WinGesch { get; private set; } = 29;
		public bool Regen { get; private set; } = false;
		public TimeSpan UpdateInterval { get; private set; } = TimeSpan.FromSeconds(1);
		public bool AutoTick { get; set; } = false;

		private readonly Random rnd = Random.Shared;
		public event EventHandler<Wetterdaten>? Changed;


		public Wettersensor()
		{
			AutoTick = false;
		}

		public Wettersensor(TimeSpan updateInterval)
		{
			UpdateInterval = updateInterval;
			AutoTick = true;
			Start();
		}
		public Wettersensor(int updateInterval = 1) : this(TimeSpan.FromSeconds(updateInterval))
		{
		}

		public async void Start()
		{
			while (AutoTick)
			{
				await Task.Delay(UpdateInterval);
				Tick();
			}
		}

		public Wetterdaten GetData()
		{
			return new Wetterdaten(Temperatur, WinGesch, Regen);
		}
		public void Tick()
		{
			int interval = 1;
			if (AutoTick)
				interval = UpdateInterval.Seconds;
			// 0.1 Schwankung pro Sekunde möglich
			Temperatur += rnd.Next(-1 * interval, 1 * interval + 1) / 10d;

			// 0.2 Schwankung pro Sekunde möglich
			WinGesch += rnd.Next(-2 * interval, 2 * interval + 1) / 10d;

			Regen = rnd.Next(2) == 0;

			// Korrekt runden
			Temperatur = Math.Round(Temperatur, 1);
			WinGesch = Math.Round(WinGesch, 1);

			Console.WriteLine();
			Console.WriteLine("Temperatur: " + Temperatur.ToString() + " °C");
			Console.WriteLine("Windgeschwindigkeit: " + WinGesch.ToString() + " km/h");
			Console.WriteLine("Regen: " + (Regen ? "Ja" : "Nein"));
			Changed?.Invoke(this, GetData());
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
							if (UpdateInterval.Seconds >= 1)
								UpdateInterval = TimeSpan.FromSeconds(UpdateInterval.Seconds + 1);
							break;
						case ConsoleKey.D1:
							if (key.Modifiers == ConsoleModifiers.Shift)
								UpdateInterval = TimeSpan.FromSeconds(UpdateInterval.Seconds + 1);
							break;
						case ConsoleKey.Subtract:
						case ConsoleKey.OemMinus:
							if (UpdateInterval.Seconds >= 1)
								UpdateInterval = TimeSpan.FromSeconds(UpdateInterval.Seconds - 1);
							break;

						default:
							return;
					}
				}
			});
		}

		public class Wetterdaten
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

			public override bool Equals(object? obj)
			{
				if (obj is null || obj is not Wetterdaten data) return false;
				return Temperatur == data.Temperatur && WindGesch == data.WindGesch && Regen == data.Regen;
			}

			public override int GetHashCode()
			{
				return HashCode.Combine(Temperatur, WindGesch, Regen);
			}
		}
	}
}
