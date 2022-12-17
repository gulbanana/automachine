namespace Automachine;

class GlobalEvents
{
    public event Action? MouseUp;

    public void TriggerMouseUp()
    {
        MouseUp?.Invoke();
    }
}
