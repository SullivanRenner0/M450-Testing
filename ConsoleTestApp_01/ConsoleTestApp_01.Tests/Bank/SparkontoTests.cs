using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleTestApp_01.Bank;

namespace ConsoleTestApp_01.Tests.Bank;

[TestClass()]
public class SparkontoTests
{
    [TestMethod()]
    public void SparkontoTest()
    {
        var sut1 = new Sparkonto();
        var sut2 = new Sparkonto();
        var sut3 = new Sparkonto();

        Assert.IsNotNull(sut1);
        Assert.IsNotNull(sut2);
        Assert.IsNotNull(sut3);

        Assert.AreNotEqual(sut1.KontoNummer, sut2.KontoNummer);
        Assert.AreNotEqual(sut1.KontoNummer, sut3.KontoNummer);
        Assert.AreNotEqual(sut2.KontoNummer, sut3.KontoNummer);
    }



    [TestMethod()]
    public void ZahleEin()
    {
        var sut = new Sparkonto();
        sut.ZahleEin(100);
        Assert.AreEqual(100, sut.Guthaben);
    }

    [TestMethod()]
    public void Beziehe()
    {
        var sut = new Sparkonto();
        sut.ZahleEin(100);

        Action action = () => sut.Beziehe(200);

        Assert.ThrowsException<MaxUerbzugException>(action);
    }

    [TestMethod()]
    public void Transferiere()
    {
        var konto1 = new Sparkonto();
        konto1.ZahleEin(300);

        var konto2 = new Sparkonto();
        konto2.ZahleEin(200);

        konto1.Transferiere(300, konto2);

        Assert.AreEqual(0, konto1.Guthaben);
        Assert.AreEqual(500, konto2.Guthaben);
    }

    [TestMethod()]
    public void Transferiere_Exception()
    {
        var konto1 = new Sparkonto();
        konto1.ZahleEin(100);

        var konto2 = new Sparkonto();
        konto2.ZahleEin(200);

        Action action = () => konto1.Transferiere(300, konto2);

        Assert.ThrowsException<MaxUerbzugException>(action);
    }

    [TestMethod()]
    public void SchreibeZinsGut_SchliesseKontoAb_Aktiv()
    {
        var sut = new Sparkonto();
        sut.ZahleEin(100);

        sut.SchreibeZinsGut(360);
        sut.SchliesseKontoAb();

        var expectedResult = 100 + 100 * sut.AktivZins;

        Assert.AreEqual(expectedResult, sut.Guthaben);
    }

    [TestMethod()]
    public void SchreibeZinsGut_SchliesseKontoAb_Passiv()
    {
        var sut = new Sparkonto();
        sut.ZahleEin(-100);

        sut.SchreibeZinsGut(360);
        sut.SchliesseKontoAb();

        var expectedResult = -100 + -100 * sut.PassivZins;

        Assert.AreEqual(expectedResult, sut.Guthaben);
    }

}
