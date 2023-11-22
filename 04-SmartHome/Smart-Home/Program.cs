global using Smart_Home.Interfaces;
global using Smart_Home.Klassen;

namespace Smart_Home
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			var kueche = new Kueche();
			var schlafzimmer = new Schlafzimmer();
			var wc = new WC();
			var wintergarten = new Wintergarten();
			var wohnzimmer = new Wohnzimmer();

			var sensor = new Wettersensor(1);

			var haus = new Haus(sensor, kueche, schlafzimmer, wc, wintergarten, wohnzimmer);

			await Task.Delay(TimeSpan.FromMinutes(3));
		}
	}
}