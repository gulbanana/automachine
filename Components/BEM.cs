using System.Text;

namespace Automachine.Components;

static class BEM
{
    public record struct Modifier(bool Test, string ExtraClass)
    {
        public static implicit operator Modifier((bool test, string extraClass) tuple) => new(tuple.test, tuple.extraClass);
        public static implicit operator Modifier(Enum mode) => new(true, mode.ToString().ToLowerInvariant());
    }

    private static string lastBlock = "";

    public static string Block(string baseClass, params Modifier[] modifiers)
    {
        lastBlock = baseClass;

        var classList = new StringBuilder();

        classList.Append(baseClass);

        foreach (var modifier in modifiers)
        {
            if (modifier.Test)
            {
                classList.Append(' ');
                classList.Append(baseClass);
                classList.Append("--");
                classList.Append(modifier.ExtraClass);
            }
        }

        return classList.ToString();
    }

    public static string Element(string baseClass, params (bool test, string extraClass)[] modifiers)
    {
        var classList = new StringBuilder();

        if (!string.IsNullOrWhiteSpace(lastBlock))
        {
            classList.Append(lastBlock);
            classList.Append("__");
        }

        classList.Append(baseClass);

        foreach (var modifier in modifiers)
        {
            if (modifier.test)
            {
                classList.Append(' ');
                if (!string.IsNullOrWhiteSpace(lastBlock))
                {
                    classList.Append(lastBlock);
                    classList.Append("__");
                }
                classList.Append(baseClass);
                classList.Append("--");
                classList.Append(modifier.extraClass);
            }
        }

        return classList.ToString();
    }
}
