namespace MicroWaveInStatePattern_base.States;

public class Standby : MicroWaveState
{
    public Standby(MicroWaveController controller)
        : base(controller)
    {

        controller.SetHeating(MicroWaveController.SwitchState.Off);
        controller.SetLight(MicroWaveController.SwitchState.On);
    }

    public override void CloseDoor()
    {
        controller.ChangeState(new Ready(controller));
    }
}
