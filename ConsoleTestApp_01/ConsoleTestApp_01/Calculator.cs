using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestApp_01
{
	public class Calculator : ICalculator
	{
		public double Add(double a, double b)
			=> a + b;

		public double Divide(double a, double b)
		{
			if (b == 0)
				throw new DivideByZeroException();
			return a / b;
		}

		public double Multiply(double a, double b)
			=> a * b;

		public double Subtract(double a, double b)
		=> a - b;
	}
}
