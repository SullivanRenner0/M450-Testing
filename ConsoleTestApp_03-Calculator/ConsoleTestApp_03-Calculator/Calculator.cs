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

		public int Add(int param1, int param2)
		{
			throw new NotImplementedException();
		}

		public int ConvertUSDtoCHFR(int unit)
		{
			return unit * this._feed.GetActualUSDValue();
		}

		public int Divide(int param1, int param2)
		{
			throw new NotImplementedException();
		}

		public int Multipy(int param1, int param2)
		{
			throw new NotImplementedException();
		}

		public int Subtract(int param1, int param2)
		{
			throw new NotImplementedException();
		}
	}
}
