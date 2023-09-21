using ConsoleTestApp_03_Calculator.Interfaces;

namespace ConsoleTestApp_03_Calculator
{
	internal class Calculator : ICalculator
	{
		private readonly IUSD_CLP_ExchangeRateFeed _feed;
		private readonly IPrinterService _printer;
		private readonly IPostService _postService;

		public Calculator(IUSD_CLP_ExchangeRateFeed feed, IPrinterService printer, IPostService postService)
		{
			_feed = feed;
			_printer = printer;
			_postService = postService;
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

		public bool ValidatePLZ(string plz)
		{
			return _postService.ValidatePLZ(plz);
		}

		public double CollectData(IDataService dataService)
		{
			if (!dataService.Open("mydata"))
				return 0;

			var gotFirst =dataService.GetFirst(out var sum);
			if (!gotFirst)
				return 0;

			while (dataService.GetNext(out var value))
				sum += value;

			return sum;
		}
	}
}
