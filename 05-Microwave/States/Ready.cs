namespace MicroWaveInStatePattern_base.States;

public class Ready : MicroWaveState
{
    public Ready(MicroWaveController controller)
        : base(controller)
    {
        controller.SetLight(MicroWaveController.SwitchState.Off);
        controller.SetHeating(MicroWaveController.SwitchState.Off);
    }

    public override void Start()
    {
        controller.ChangeState(new Cooking(controller));
    }

    public override void OpenDoor()
    {
        controller.SetHorn(MicroWaveController.SwitchState.Off);
        controller.ChangeState(new Standby(controller));
    }

}
