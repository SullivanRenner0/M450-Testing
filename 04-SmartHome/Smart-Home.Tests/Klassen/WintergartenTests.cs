using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smart_Home.Klassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Home.Klassen.Tests
{
	[TestClass()]
	public class WintergartenTests
	{

		[TestMethod]
		[DataRow(0, 0, 0)]
		[DataRow(1, 0, 0)]
		[DataRow(1, 0, 1)]
		[DataRow(1, 1, 1)]
		[DataRow(0, 1, 1)]
		[DataRow(0, 0, 1)]
		[DataRow(1, 1, 1)]
		public void TestJalousie(double roomTemperatur, int personsInRoom, double temperatur)
		{
			var sut = new Wintergarten(roomTemperatur, personsInRoom);
			var data = new Wettersensor.Wetterdaten(temperatur, 0, false);

			sut.CheckJalousie(data);

			var expected = data.Temperatur > sut.OptimalTemperature && sut.Personen == 0;
			Assert.AreEqual(expected, sut.JalousieUnten);
		}

		[TestMethod]
		[DataRow(20, 19, 0, false)]
		[DataRow(20, 19, 0, true)]
		[DataRow(20, 20, 0, false)]
		[DataRow(20, 20, 0, true)]
		[DataRow(20, 21, 0, false)]
		[DataRow(20, 21, 0, true)]
		[DataRow(20, 19, 31, false)]
		[DataRow(20, 19, 31, true)]
		[DataRow(20, 20, 31, false)]
		[DataRow(20, 20, 31, true)]
		[DataRow(20, 21, 31, false)]
		[DataRow(20, 21, 31, true)]
		public void TestMarkise(double roomTemperatur, double temperatur, double windSpeed, bool rain)
		{
			var sut = new Wintergarten(roomTemperatur, 0);
			var data = new Wettersensor.Wetterdaten(temperatur, windSpeed, rain);

			sut.CheckMarkise(data);

			var expected = data.Temperatur > sut.OptimalTemperature && (Constants.MarkiseCanBeUsedInRain ? true : !data.Regen) && data.WindGesch <= Constants.MarkiseMaxWindSpeed;
			Assert.AreEqual(expected, sut.MarkiseAusgefahren);
		}
	}
}