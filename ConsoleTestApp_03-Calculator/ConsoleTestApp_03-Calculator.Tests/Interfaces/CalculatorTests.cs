using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleTestApp_03_Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace ConsoleTestApp_03_Calculator.Interfaces.Tests
{
	[TestClass()]
	public class CalculatorTests
	{
		[TestMethod()]
		public void AddTest()
		{
			var sut = new Calculator(null);
			var expectedResult = 3.0;

			var actualResult = sut.Add(1, 2);

			Assert.AreEqual(expectedResult, actualResult);
		}

		[TestMethod()]
		public void DivideTest()
		{
			var sut = new Calculator(null);
			var expectedResult = 3.0;

			var actualResult = sut.Divide(6, 2);

			Assert.AreEqual(expectedResult, actualResult);
		}
		[TestMethod()]
		public void DivideTest_DivideByZero()
		{
			var sut = new Calculator(null);

			var action = new Action(() => sut.Divide(6, 0));

			Assert.ThrowsException<DivideByZeroException>(action);
		}

		[TestMethod()]
		public void MultipyTest()
		{
			var sut = new Calculator(null);
			var expectedResult = 6.0;

			var actualResult = sut.Multiply(2, 3);

			Assert.AreEqual(expectedResult, actualResult);
		}

		[TestMethod()]
		public void SubtractTest()
		{
			var sut = new Calculator(null);
			var expectedResult = 1.0;

			var actualResult = sut.Subtract(3, 2);

			Assert.AreEqual(expectedResult, actualResult);
		}




		[TestMethod()]
		public void ConvertUSDtoCHFRTest()
		{
			var feedMock = new Mock<IUSD_CLP_ExchangeRateFeed>();
			feedMock.Setup(m => m.GetActualUSDValue()).Returns(3.0);

			var sut = new Calculator(feedMock.Object);
			var expectedResult = 3.0;

			var actualResult = sut.ConvertUSDtoCHFR(1);


			Assert.AreEqual(expectedResult, actualResult);
		}
	}
}