namespace MicroWaveInStatePattern_base.States;

public class Cooking : MicroWaveState
{
    public Cooking(MicroWaveController controller)
        : base(controller)
    {
        controller.SetLight(MicroWaveController.SwitchState.On);
        controller.SetHeating(MicroWaveController.SwitchState.On);
    }

    public override void Done()
    {
        controller.SetHorn(MicroWaveController.SwitchState.On);
        controller.ChangeState(new Ready(controller));
    }

    public override void OpenDoor()
    {
        controller.ChangeState(new Standby(controller));
    }

    public override void Start()
    {
        controller.ChangeState(new Cooking(controller));
    }
}