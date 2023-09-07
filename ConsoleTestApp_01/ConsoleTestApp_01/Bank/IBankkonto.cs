using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestApp_01.Bank
{
  internal interface IBankkonto
  {
	public int KontoNummer { get; }
	public double Guthaben { get; }



    public double AktivZins { get; }

    public double PassivZins { get; }

	public void ZahleEin(double betrag);
	public void Beziehe(double betrag);
	public void Transferiere(double betrag, IBankkonto zielKonto);

	public void SchreibeZinsGut(int anzTage);

	public void SchliesseKontoAb();
  }
}
