namespace Automachine.State;

class Machine
{
    public bool PHeld;
    public double PVal;
    public string PText => PVal.ToString("000");

    public bool GHeld;
    public double GVal;
    public string GText => GVal.ToString("000");

    public void Tick(TimeSpan elapsed)
    {
        if (PHeld)
        {
            PVal += elapsed.TotalSeconds * 3;
        }
        else if (PVal > 0.0)
        {
            PVal -= elapsed.TotalSeconds;
            PVal = Math.Max(PVal, 0.0);
        }

        if (GHeld)
        {
            GVal += elapsed.TotalSeconds * 3;
        }
        else if (GVal > 0.0)
        {
            GVal -= elapsed.TotalSeconds;
            GVal = Math.Max(GVal, 0.0);
        }
    }
}