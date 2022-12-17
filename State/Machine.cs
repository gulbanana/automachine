namespace Automachine.State;

class Machine
{
    public readonly Resource X = new("rebeccapurple");
    public readonly Resource Y = new("yellowgreen");
    public readonly Resource Goal1 = new("red");

    public void Tick(TimeSpan elapsed)
    {
        X.Hold(elapsed);
        Y.Hold(elapsed);
        Goal1.Val = X.Val * Y.Val;
    }
}
