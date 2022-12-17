namespace Automachine.State
{
    public record Resource(string Color)
    {
        public bool Held { get; set; }
        public double Val { get; set; }
        public string AsLabel => Val.ToString("000");

        public void Hold(TimeSpan elapsed)
        {
            if (Held)
            {
                Val += elapsed.TotalSeconds * 3;
            }
            else if (Val > 0.0)
            {
                Val -= elapsed.TotalSeconds;
                Val = Math.Max(Val, 0.0);
            }
        }
    }
}
