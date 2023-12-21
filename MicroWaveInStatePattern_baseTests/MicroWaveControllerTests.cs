using Microsoft.VisualStudio.TestTools.UnitTesting;
using MicroWaveInStatePattern_base;
using MicroWaveInStatePattern_base.States;

namespace MicroWaveInStatePattern_baseTests;

[TestClass()]
public class MicroWaveControllerTests
{
    [TestMethod]
    public void Startup_Test()
    {
        var sut = new MicroWaveController();

        var state = sut.State;

        Assert.IsNotNull(state);
        Assert.IsInstanceOfType<Ready>(sut.State);

        Assert.AreEqual(MicroWaveController.SwitchState.Off, sut.Horn);
        Assert.AreEqual(MicroWaveController.SwitchState.Off, sut.Light);
        Assert.AreEqual(MicroWaveController.SwitchState.Off, sut.Heating);
    }

    [TestMethod]
    public void CookFromOff()
    {
        var sut = new MicroWaveController();
        sut.ChangeState(new Off(sut));

        sut.Start();

        var state = sut.State;
        Assert.IsNotNull(state);
        Assert.IsInstanceOfType<Off>(state);

        Assert.AreEqual(MicroWaveController.SwitchState.Off, sut.Horn);
        Assert.AreEqual(MicroWaveController.SwitchState.Off, sut.Light);
        Assert.AreEqual(MicroWaveController.SwitchState.Off, sut.Heating);
    }

    [TestMethod]
    public void CancelCooking()
    {
        var sut = new MicroWaveController();
        sut.ChangeState(new Cooking(sut));

        sut.OpenDoor();

        var state = sut.State;
        Assert.IsNotNull(state);
        Assert.IsInstanceOfType<Standby>(state);

        Assert.AreEqual(MicroWaveController.SwitchState.Off, sut.Horn);
        Assert.AreEqual(MicroWaveController.SwitchState.On, sut.Light);
        Assert.AreEqual(MicroWaveController.SwitchState.Off, sut.Heating);
    }

    [TestMethod()]
    public void MicroWaveController_Test()
    {
        throw new NotImplementedException();
    }

    [TestMethod()]
    public void ChangeState_Test()
    {
        throw new NotImplementedException();
    }

    [TestMethod()]
    public void OpenDoor_Test()
    {
        throw new NotImplementedException();
    }

    [TestMethod()]
    public void CloseDoor_Test()
    {
        throw new NotImplementedException();
    }

    [TestMethod()]
    public void Start_Test()
    {
        throw new NotImplementedException();
    }

    [TestMethod()]
    public void Done_Test()
    {
        throw new NotImplementedException();
    }

    [TestMethod()]
    public void SetHeating_Test()
    {
        throw new NotImplementedException();
    }

    [TestMethod()]
    public void SetLight_Test()
    {
        throw new NotImplementedException();
    }

    [TestMethod()]
    public void SetHorn_Test()
    {
        throw new NotImplementedException();
    }

    [TestMethod()]
    public void IncreaseTime_Test()
    {
        throw new NotImplementedException();
    }

    [TestMethod()]
    public void ResetTime_Test()
    {
        throw new NotImplementedException();
    }

    [TestMethod()]
    public void Tick_Test()
    {
        throw new NotImplementedException();
    }
}