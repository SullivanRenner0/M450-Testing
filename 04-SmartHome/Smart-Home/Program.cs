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

			var haus = new Haus(3, kueche, schlafzimmer, wc, wintergarten, wohnzimmer);
			await haus.WaitForExit();
		}
	}
}