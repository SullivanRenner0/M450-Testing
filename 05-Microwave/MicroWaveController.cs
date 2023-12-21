using MicroWaveInStatePattern_base.States;

namespace MicroWaveInStatePattern_base;


public class MicroWaveController
{
    public enum SwitchState { On, Off }
    public SwitchState Light { get; private set; } = SwitchState.Off;
    public SwitchState Heating { get; private set; } = SwitchState.Off;
    public SwitchState Horn { get; private set; } = SwitchState.Off;

    private int _reminingTime = 0;

    public MicroWaveState State { get; private set; }
    public MicroWaveController()
    {
        State = new Off(this);
        ChangeState(new Ready(this));
    }

    public void ChangeState(MicroWaveState state)
    {
        State = state;
    }

    public void OpenDoor()
    {
        State.OpenDoor();
    }

    public void CloseDoor()
    {
        State.CloseDoor();
    }

    public void Start()
    {
        State.Start();
    }

    public void Done()
    {
        State.Done();
    }

    public void SetHeating(SwitchState on)
    {
        Heating = on;
        Console.WriteLine($"Heating {Heating}");
    }
    public void SetLight(SwitchState on)
    {
        Light = on;
        Console.WriteLine($"Light {Light}");
    }

    public void SetHorn(SwitchState on)
    {
        Horn = on;
        Console.WriteLine($"Horn {Horn}");
    }

    public void IncreaseTime()
    {
        _reminingTime += 10;
    }

    public void ResetTime()
    {
        _reminingTime = 0;
    }

    public void Tick()
    {
        _reminingTime -= 1;
    }
}
