namespace ConsoleTestApp_01.Bank;

internal class Sparkonto : Bankkonto
{
    public override double MaxUeberzug => 0;

    public Sparkonto() : base()
    { }


}
