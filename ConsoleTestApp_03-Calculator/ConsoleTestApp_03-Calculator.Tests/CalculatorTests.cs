using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleTestApp_03_Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace ConsoleTestApp_03_Calculator.Tests
{
	[TestClass()]
	public class CalculatorTests
	{
		[TestMethod()]
		public void AddTest()
		{
			var sut = new Calculator(GetExchangeRateFeed(1), null, null);
			var expectedResult = 3.0;

			var actualResult = sut.Add(1, 2);

			Assert.AreEqual(expectedResult, actualResult);
		}

		[TestMethod()]
		public void DivideTest()
		{
			var sut = new Calculator(GetExchangeRateFeed(1), null, null);
			var expectedResult = 3.0;

			var actualResult = sut.Divide(6, 2);

			Assert.AreEqual(expectedResult, actualResult);
		}
		[TestMethod()]
		public void DivideTest_DivideByZero()
		{
			var sut = new Calculator(GetExchangeRateFeed(1), null, null);

			var action = new Action(() => sut.Divide(6, 0));

			Assert.ThrowsException<DivideByZeroException>(action);
		}

		[TestMethod()]
		public void MultipyTest()
		{
			var sut = new Calculator(GetExchangeRateFeed(1), null, null);
			var expectedResult = 6.0;

			var actualResult = sut.Multiply(2, 3);

			Assert.AreEqual(expectedResult, actualResult);
		}

		[TestMethod()]
		public void SubtractTest()
		{
			var sut = new Calculator(GetExchangeRateFeed(1), null, null);
			var expectedResult = 1.0;

			var actualResult = sut.Subtract(3, 2);

			Assert.AreEqual(expectedResult, actualResult);
		}




		[TestMethod()]
		public void ConvertUSDtoCHFRTest()
		{
			var sut = new Calculator(GetExchangeRateFeed(3), null, null);
			var expectedResult = 3.0;

			var actualResult = sut.ConvertUSDtoCHFR(1);


			Assert.AreEqual(expectedResult, actualResult);
		}

		[TestMethod()]
		public void SetPLZTest()
		{
			var sut = new Calculator(null, null, GetPostService());
			var expectedResult = true;
			var actualResult = sut.ValidatePLZ("1234");
			Assert.AreEqual(expectedResult, actualResult);
		}

		[TestMethod()]
		public void CollectDataTest()
		{
			var sut = new Calculator(null, null, null);
			var dataService = GetDataService();
			var expectedResult = 38.0;

			var actualResult = sut.CollectData(dataService);

			Assert.AreEqual(expectedResult, actualResult);
		}



		private IUSD_CLP_ExchangeRateFeed GetExchangeRateFeed(double exchangeRate, MockBehavior behavior = MockBehavior.Loose)
		{
			var mockFeed = new Mock<IUSD_CLP_ExchangeRateFeed>(behavior);
			mockFeed.Setup(m => m.GetActualUSDValue()).Returns(exchangeRate);
			return mockFeed.Object;
		}

		private IPrinterService GetPrinterService(MockBehavior behavior = MockBehavior.Loose)
		{
			var mockPrinter = new Mock<IPrinterService>(behavior);
			
			mockPrinter.Setup(m => m.Print(It.IsAny<string>()))
							.Callback(DoPrint);

			return mockPrinter.Object;
		}

		private void DoPrint(string message)
		{
			Console.WriteLine(message);
		}

		private IPostService GetPostService()
		{
			Mock<IPostService> mockPost = new Mock<IPostService>();
			mockPost.Setup(m => m.ValidatePLZ(It.IsRegex("^[0-9][0-9][0-9][0-9]$"))).Returns(true);
			return mockPost.Object;
		}


		private IDataService GetDataService()
		{
			Mock<IDataService> mockDataService = new Mock<IDataService>();
			mockDataService.Setup(m => m.Open(It.IsAny<string>())).Returns(true);
			mockDataService.Setup(m => m.Close());
			double i = 12;
			mockDataService.Setup(m => m.GetFirst(out i)).Returns(true);
			double j = 13;
			mockDataService.SetupSequence(m => m.GetNext(out j)).Returns(true)
																.Returns(true)
																.Returns(false);
			return mockDataService.Object;
		}

	}
}