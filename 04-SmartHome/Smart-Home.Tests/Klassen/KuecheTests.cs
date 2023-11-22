using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smart_Home.Klassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Home.Klassen.Tests
{
	[TestClass]
	public class KuecheTests
	{
		[DataRow(0, 0)]
		[DataRow(1, 0)]
		[DataRow(0, 1)]
		[DataRow(1, 1)]
		[DataRow(null, 0)]
		[DataRow(0, null)]
		[DataRow(null, 1)]
		[DataRow(1, null)]
		[TestMethod]
		public void TestHeizung(double roomtemperatur, double temperatur)
		{
			var sut = new Kueche(roomtemperatur);
			var data = new Wettersensor.Wetterdaten(temperatur, 0, false);

			sut.CheckHeizung(data);

			var expected = data.Temperatur < sut.OptimalTemperature;
			Assert.AreEqual(expected, sut.Heizt);
		}

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
			var sut = new Kueche(roomTemperatur, personsInRoom);
			var data = new Wettersensor.Wetterdaten(temperatur, 0, false);

			sut.CheckJalousie(data);

			var expected = data.Temperatur > sut.OptimalTemperature && sut.Personen == 0;
			Assert.AreEqual(expected, sut.JalousieUnten);
		}
	}
}