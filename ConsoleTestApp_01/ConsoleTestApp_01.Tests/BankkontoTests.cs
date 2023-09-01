using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleTestApp_01.Bank;

namespace ConsoleTestApp_01.Tests;

[TestClass()]
public class BankkontoTests
{
	[TestMethod()]
	public void BankkontoTest()
	{
        var _sut1 = new Bankkonto();
		var _sut2 = new Bankkonto();
		var _sut3 = new Bankkonto();

		Assert.IsNotNull(_sut1);
		Assert.IsNotNull(_sut2);
		Assert.IsNotNull(_sut3);

		Assert.AreNotEqual(_sut1.KontoNummer, _sut2.KontoNummer);
		Assert.AreNotEqual(_sut1.KontoNummer, _sut3.KontoNummer);
		Assert.AreNotEqual(_sut2.KontoNummer, _sut3.KontoNummer);
    }



	[TestMethod()]
	public void ZahleEin()
	{
		var _sut = new Bankkonto();
		_sut.ZahleEin(100);
		Assert.AreEqual(100, _sut.Guthaben);
	}

	[TestMethod()]
	public void Beziehe()
	{
		var _sut = new Bankkonto();
		_sut.ZahleEin(100);

		Assert.AreEqual(100, _sut.Guthaben);

		_sut.Beziehe(200);
		Assert.AreEqual(-100, _sut.Guthaben);
	}

	[TestMethod()]
	public void Transferiere()
	{
		var konto1 = new Bankkonto();
		konto1.ZahleEin(100);

		var konto2 = new Bankkonto();
		konto2.ZahleEin(200);

		konto1.Transferiere(300, konto2);

		Assert.AreEqual(-200, konto1.Guthaben);
		Assert.AreEqual(500, konto2.Guthaben);
	}

	[TestMethod()]
	public void SchreibeZinsGut_SchliesseKontoAb_Aktiv()
	{
		var sut = new Bankkonto();
		sut.ZahleEin(100);
		
		sut.SchreibeZinsGut(360);
		sut.SchliesseKontoAb();

		var expectedResult = 100 + 100 * sut.AktivZins;

		Assert.AreEqual(expectedResult, sut.Guthaben);
	}

	[TestMethod()]
	public void SchreibeZinsGut_SchliesseKontoAb_Passiv()
	{
        var sut = new Bankkonto();
        sut.ZahleEin(-100);

        sut.SchreibeZinsGut(360);
        sut.SchliesseKontoAb();

		var expectedResult = -100 + -100 * sut.PassivZins;

        Assert.AreEqual(expectedResult, sut.Guthaben);
    }

}
