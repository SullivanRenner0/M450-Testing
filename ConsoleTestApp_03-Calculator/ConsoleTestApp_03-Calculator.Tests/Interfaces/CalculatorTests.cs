using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleTestApp_03_Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestApp_03_Calculator.Interfaces.Tests
{
	[TestClass()]
	public class CalculatorTests
	{
		private Calculator _sut;

		[TestInitialize]
		public void Setup()
		{
			_sut = new Calculator();
		}

		[TestMethod()]
		public void AddTest()
		{
			Assert.Fail();
		}
	}
}