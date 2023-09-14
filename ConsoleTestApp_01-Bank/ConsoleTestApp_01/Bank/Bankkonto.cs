namespace ConsoleTestApp_01.Bank;

internal abstract class Bankkonto : IBankkonto
{
    private static int _newKontoNr = 0;
    public int KontoNummer { get; }

    public double Guthaben { get; protected set; } = 0;
    protected double ZinsGuthaben = 0;

    public virtual double AktivZins => 0.03;
    public virtual double PassivZins => 0.05;

    public abstract double MaxUeberzug { get; }

    private const double StdBezugsLimite = 10_000; // nach Absprache mit Vogel
    public double BezugsLimite { get; private set; } = StdBezugsLimite;

    public bool IsVIP;


    public Bankkonto()
    {
        KontoNummer = ++_newKontoNr;
    }

    public virtual void ZahleEin(double betrag)
    {
        Guthaben += betrag;
    }
    public virtual void Beziehe(double betrag)
    {
        if (betrag > BezugsLimite)
            throw new MaxBezugException("Maximaler Bezug überschritten");
        if (Guthaben - betrag < -MaxUeberzug)
            throw new MaxUerbzugException("Maximale Überziehung überschritten");
        Guthaben -= betrag;
    }

    public virtual void Transferiere(double betrag, IBankkonto zielKonto)
    {
        this.Beziehe(betrag);
        zielKonto.ZahleEin(betrag);
    }

    public virtual void SchliesseKontoAb()
    {
        ZahleEin(ZinsGuthaben);
        ZinsGuthaben = 0;
    }
    

    public virtual void SchreibeZinsGut(int anzTage)
    {
        double zinsSatz = GetZinsSatz();
        double zins = Guthaben * zinsSatz / 360 * anzTage;

        ZinsGuthaben += zins;
    }

    private double GetZinsSatz()
    {
        if (Guthaben == 0)
            return 0;
        else if (Guthaben < 0)
            return PassivZins;
        else
        {
            if (Guthaben < 10_000)
                return AktivZins;
            else if (Guthaben < 50_000)
                return AktivZins - 0.005;
            else // Guthaben >= 50_000
            {
                if (IsVIP)
                    return AktivZins - 0.0075;
                else
                    return AktivZins - 0.001;
            } 
        }
    }

    public bool SetBezugsLimite(double newMaxBezug)
    {
        if (newMaxBezug > StdBezugsLimite)
            return false;
        if (newMaxBezug < 1)
            return false;

        BezugsLimite = newMaxBezug;
        return true;
    }
}
