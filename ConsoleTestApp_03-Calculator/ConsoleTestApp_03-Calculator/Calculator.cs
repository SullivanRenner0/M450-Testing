using ConsoleTestApp_03_Calculator.Interfaces;

namespace ConsoleTestApp_03_Calculator
{
	public class Calculator : ICalculator
	{
		private readonly IUSD_CLP_ExchangeRateFeed _feed;

		public Calculator(IUSD_CLP_ExchangeRateFeed feed)
		{
			_feed = feed;
		}

		#region Normal Operators
		public double Add(double param1, double param2)
		{
			return param1 + param2;
		}

		/// <summary>
		/// </summary>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
		/// <returns></returns>
		/// <exception cref="DivideByZeroException"></exception>
		public double Divide(double param1, double param2)
		{
			if (param2 == 0)
				throw new DivideByZeroException();

			return param1 / param2;
		}

		public double Multiply(double param1, double param2)
		{
			return param1 * param2;
		}

		public double Subtract(double param1, double param2)
		{
			return param1 - param2;
		}
		#endregion


		public double ConvertUSDtoCHFR(double unit)
		{
			return unit * this._feed.GetActualUSDValue();
		}
	}
}
