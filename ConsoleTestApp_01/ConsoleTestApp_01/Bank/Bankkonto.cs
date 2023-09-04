namespace ConsoleTestApp_01.Bank;

internal abstract class Bankkonto : IBankkonto
{
    private static int _newKontoNr = 0;
    public int KontoNummer { get; }

    public double Guthaben { get; protected set; } = 0;
    protected double ZinsGuthaben = 0;

    public virtual double AktivZins { get; set; } = 0.01;
    public virtual double PassivZins { get; set; } = 0.02;

    public abstract double MaxUeberzug { get; }

    public virtual double MaxBezug => double.MaxValue;


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
        if (betrag > MaxBezug)
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
        double zins;
        if (Guthaben >= 0)
            zins = Guthaben * AktivZins / 360 * anzTage;
        else
            zins = Guthaben * PassivZins / 360 * anzTage;

        ZinsGuthaben += zins;
    }
}
