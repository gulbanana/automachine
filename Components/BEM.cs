using System.Text;

namespace Automachine.Components;

static class BEM
{
    private static string lastBlock = "";

    public static string Block(string baseClass, params (bool test, string extraClass)[] modifiers)
    {
        lastBlock = baseClass;

        var classList = new StringBuilder();

        classList.Append(baseClass);

        foreach (var modifier in modifiers)
        {
            if (modifier.test)
            {
                classList.Append(' ');
                classList.Append(baseClass);
                classList.Append("--");
                classList.Append(modifier.extraClass);
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
