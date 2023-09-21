using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestApp_03_Calculator.Interfaces
{
	public interface ICalculator
	{
		double Add(double param1, double param2);
		double Subtract(double param1, double param2);
		double Multiply(double param1, double param2);
		double Divide(double param1, double param2);
		double ConvertUSDtoCHFR(double unit);
	}
}
