using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smart_Home.Klassen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Home.Tests
{
	[TestClass]
	internal class KuecheTests
	{
		private Haus _haus;
		private Wettersensor _sensor;
		
		[TestInitialize]
		public void Setup()
		{
			_sensor = new Wettersensor(1);
			var kueche = new Kueche();
			_haus = new Haus(_sensor, kueche);
		}



	}
}
