namespace Automachine.State;

class Machine
{
    public readonly Resource X = new("rebeccapurple");
    public readonly Resource Y = new("yellowgreen");
    public readonly Resource Goal1 = new("red");
    public bool Phase1;

    public void Tick(TimeSpan elapsed)
    {
        if (Phase1 && Goal1.Val < 150)
        {
            X.Held = true;
            Y.Held = true;
        }

        if (Phase1 && Goal1.Val > 175)
        {
            X.Held = false;
            Y.Held = false;
        }

        X.Hold(elapsed);
        Y.Hold(elapsed);
        Goal1.Val = X.Val * Y.Val;

        if (!Phase1 && Goal1.Val >= 150 && Goal1.Val <= 175)
        {
            Phase1 = true;
        }
    }
}
