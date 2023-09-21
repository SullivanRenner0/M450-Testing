using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestApp_03_Calculator.Interfaces
{
	internal interface IDataService
	{
		bool Open(string path);
		void Close();
		bool GetFirst(out double value);
		bool GetNext(out double value);
	}
}
