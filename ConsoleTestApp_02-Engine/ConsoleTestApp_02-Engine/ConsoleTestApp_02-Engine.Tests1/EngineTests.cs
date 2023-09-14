using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleTestApp_02.Enums;

namespace ConsoleTestApp_02.Tests
{
    [TestClass()]
    public class EngineTests
    {
        [TestMethod()]
        public void EngineStartTest()
        {
            var sut = new Engine();

            sut.EngineStart();

            Assert.AreEqual(EngineState.Engine_ON, sut.State);
        }
        [TestMethod()] 
        public void EngineStartTest_WhileUpdate() 
        {
            var sut = new Engine();
            sut.SetStateForTest(EngineState.Update_Mode);

            sut.EngineStart();

            Assert.AreEqual(EngineState.Update_Mode, sut.State);
        }

        [TestMethod()]
        public void DoUpdateTest()
        {
            var sut = new Engine();

            sut.DoUpdate();

            Assert.AreEqual(EngineState.Engine_OFF, sut.State);
        }


        [TestMethod()]
        public void EngineStopTest()
        {
            var sut = new Engine();

            sut.EngineStop();

            Assert.AreEqual(EngineState.Engine_OFF, sut.State);
        }

        [TestMethod()]
        public void EngineStopTest_WhileUpdate()
        {
			var sut = new Engine();
			sut.SetStateForTest(EngineState.Update_Mode);

			sut.EngineStop();
			
            Assert.AreEqual(EngineState.Update_Mode, sut.State);
		}

        [TestMethod()]
        public void UpdateCheckTest()
		{
			var sut = new Engine();

			sut.UpdateCheck();

            Assert.AreEqual(EngineState.Update_Mode, sut.State);
		}

        [TestMethod()]
        public void UpdateCheckTest_WhileOn()
		{
			var sut = new Engine();
            sut.SetStateForTest(EngineState.Engine_ON);

			sut.UpdateCheck();

            Assert.AreEqual(EngineState.Engine_ON, sut.State);
		}

        [TestMethod()]
        public void UpdateReadyTest()
        {
            var sut = new Engine();

			sut.UpdateReady();

			Assert.AreEqual(EngineState.Engine_OFF, sut.State);
        }

        [TestMethod()]
        public void UpdateReadyTest_WhileON()
        {
            var sut = new Engine();
            sut.SetStateForTest(EngineState.Engine_ON);

			sut.UpdateReady();

			Assert.AreEqual(EngineState.Engine_ON, sut.State);
        }

        [TestMethod()]
        public void UpdateReadyTest_WhileOFF()
        {
            var sut = new Engine();
            sut.SetStateForTest(EngineState.Engine_OFF);

			sut.UpdateReady();

			Assert.AreEqual(EngineState.Engine_OFF, sut.State);
        }

        [TestMethod()]
        public void VoltageLowTest()
		{
			var sut = new Engine();

			sut.VoltageLow();

			Assert.AreEqual(EngineState.Voltage_Low, sut.State);
		}
    }
}