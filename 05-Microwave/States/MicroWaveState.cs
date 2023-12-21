namespace MicroWaveInStatePattern_base.States;

public abstract class MicroWaveState : IMicroWaveAPI
{
    protected MicroWaveController controller;

    public MicroWaveState(MicroWaveController controller)
    {
        this.controller = controller;
    }

    public virtual void Start()
    {
    }

    public virtual void CloseDoor()
    {
    }

    public virtual void OpenDoor()
    {
    }

    public virtual void Done()
    {
    }

    protected void ChangeState(MicroWaveState state)
    {
        controller.ChangeState(state);
    }

}
