using ConsoleTestApp_02.Enums;
using ConsoleTestApp_02.Interfaces;

namespace ConsoleTestApp_02
{
	internal class Engine : IEngineControl
	{

		public EngineState State { get; private set; }

		public void SetStateForTest(EngineState state)
		{
			State = state;
		}

		public Engine()
		{
			Console.WriteLine("going online");
			State = EngineState.Engine_OFF;
		}

		public void EngineStart()
		{
			if (State != EngineState.Engine_OFF)
				return;// throw new InvalidOperationException("Engine must be off to start");

			Console.WriteLine("Starting Engine");
			State = EngineState.Engine_ON;
		}

		public void EngineStop()
		{
			if (State != EngineState.Engine_ON)
				return;// throw new InvalidOperationException("Engine must be on to stop");

			Console.WriteLine("Stopping Engine");
			State = EngineState.Engine_OFF;
		}

		public void UpdateCheck()
		{
			if (State != EngineState.Engine_OFF)
				return;// throw new InvalidOperationException("Engine must be to update");

			Console.WriteLine("Checking Update");
			State = EngineState.Update_Mode;
		}

		public void UpdateReady()
		{
			if (State != EngineState.Update_Mode)
				return;// throw new InvalidOperationException("Engine must be in update mode to update");

			Console.WriteLine("Update done");
			State = EngineState.Engine_OFF;
		}
		public void DoUpdate()
		{
			if (State != EngineState.Update_Mode)
				return; //throw new InvalidOperationException("Engine must be in update mode to update");

			Console.WriteLine("Doing Update");
		}
		public void VoltageLow()
		{
			Console.WriteLine("going offline");
			State = EngineState.Voltage_Low;
		}
	}

}
