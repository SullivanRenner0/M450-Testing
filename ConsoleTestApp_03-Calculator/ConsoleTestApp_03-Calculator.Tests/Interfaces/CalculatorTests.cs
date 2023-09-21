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
			Assert.Fail();
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

		[TestMethod()]
		public void DivideTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void MultipyTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void SubtractTest()
		{
			Assert.Fail();
		}
	}
}