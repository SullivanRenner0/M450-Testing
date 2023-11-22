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
	public class WettersensorTests
	{
		[TestMethod()]
		public void TickTest()
		{
			var sut = new Wettersensor();

			var tickResults = new List<Wettersensor.Wetterdaten>();

			for (int i = 0; i <= 1000; i++)
			{
				sut.Tick();
				tickResults.Add(sut.GetData());
			}

			Assert.IsFalse(tickResults.All(d => d.Equals(tickResults[0])));

			bool noBigDif = tickResults.Any((cur) =>
			{
				var pos = tickResults.IndexOf(cur);
				var next = tickResults.ElementAtOrDefault(pos);
				if (next is null)
					return false;

				var tempToBigDif = Math.Abs(cur.Temperatur - next.Temperatur) > 1;
				var windToBigDif = Math.Abs(cur.WindGesch - next.WindGesch) > 1;

				return !tempToBigDif && !windToBigDif;
			});

			Assert.IsTrue(noBigDif);
		}
	}
}