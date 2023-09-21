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

		public double Add(double param1, double param2)
		{
			throw new NotImplementedException();
		}

		public double ConvertUSDtoCHFR(double unit)
		{
			return unit * this._feed.GetActualUSDValue();
		}

		public double Divide(double param1, double param2)
		{
			throw new NotImplementedException();
		}

		public double Multipy(double param1, double param2)
		{
			throw new NotImplementedException();
		}

		public double Subtract(double param1, double param2)
		{
			throw new NotImplementedException();
		}
	}
}
