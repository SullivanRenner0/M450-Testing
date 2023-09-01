using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestApp_01.Bank
{
	internal class Bankkonto : IBankkonto
	{
		private static int _newKontoNr = 0;
		public int KontoNummer { get; }

		public double Guthaben { get; private set; } = 0;
		private double ZinsGuthaben = 0;

		public double AktivZins { get; set; } = 0.01;
		public double PassivZins { get; set; } = 0.02;

		public Bankkonto()
		{
			KontoNummer = ++_newKontoNr;
		}

		public void ZahleEin(double betrag)
		{
			Guthaben += betrag;
		}
		public void Beziehe(double betrag)
		{
			Guthaben -= betrag;
		}

		public void Transferiere(double betrag, IBankkonto zielKonto)
		{
			this.Beziehe(betrag);
			zielKonto.ZahleEin(betrag);
		}

		public void SchliesseKontoAb()
		{
			ZahleEin(ZinsGuthaben);
			ZinsGuthaben = 0;
		}

		public void SchreibeZinsGut(int anzTage)
		{
            double zins;
            if (Guthaben >= 0)
				zins = Guthaben * AktivZins / 360 * anzTage;
			else
				zins = Guthaben * PassivZins / 360 * anzTage;

			ZinsGuthaben += zins;
		}
	}
}
