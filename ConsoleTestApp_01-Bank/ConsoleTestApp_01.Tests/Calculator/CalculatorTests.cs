using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleTestApp_01.Tests.Calculator;

[TestClass]
public class CalculatorTests
{
    private ConsoleTestApp_01.Calculator _sut;

    [TestInitialize]
    public void Setup()
    {
        _sut = new ConsoleTestApp_01.Calculator();
    }

    [TestMethod]
    public void AddTest()
    {
        var result1 = _sut.Add(1, 2);
        var result2 = _sut.Add(2, 3);
        var result3 = _sut.Add(3, 4);

        Assert.AreEqual(3, result1);
        Assert.AreEqual(5, result2);
        Assert.AreEqual(7, result3);
    }
    [TestMethod]
    public void SubtractTest()
    {
        var result1 = _sut.Subtract(1, 2);
        var result2 = _sut.Subtract(1, 3);
        var result3 = _sut.Subtract(0, 4);

        Assert.AreEqual(-1, result1);
        Assert.AreEqual(-2, result2);
        Assert.AreEqual(-4, result3);
    }
    [TestMethod]
    public void DivideTest_GanzZahl()
    {
        var result1 = _sut.Divide(4, 2);
        var result2 = _sut.Divide(6, 2);
        var result3 = _sut.Divide(25, 5);

        Assert.AreEqual(2, result1);
        Assert.AreEqual(3, result2);
        Assert.AreEqual(5, result3);
    }
    [TestMethod]
    public void DivideTest_Gleitzahl()
    {
        var result1 = _sut.Divide(12.4, 4);
        var result2 = _sut.Divide(5D, 2D);
        var result3 = _sut.Divide(7.5, 2.5);

        Assert.AreEqual(3.1, result1);
        Assert.AreEqual(2.5, result2);
        Assert.AreEqual(3, result3);
    }

    [TestMethod]
    public void DivideTest_DivideByZero()
    {
        Action action = () => _sut.Divide(1, 0);

        Assert.ThrowsException<DivideByZeroException>(action);
    }

    [TestMethod]
    public void MultiplyTest()
    {
        var result1 = _sut.Multiply(4, 2);
        var result2 = _sut.Multiply(6, 2);
        var result3 = _sut.Multiply(25, 5);

        Assert.AreEqual(8, result1);
        Assert.AreEqual(12, result2);
        Assert.AreEqual(125, result3);
    }
}