using System;
using System.Collections.Generic;
using System.Linq;

public static class ResistorColor
{
    public static Dictionary<string, int> map = new Dictionary<string, int>()
    {
        { "black", 0 },
        { "brown", 1 },
        { "red", 2 },
        { "orange", 3 },
        { "yellow", 4 },
        { "green", 5 },
        { "blue", 6 },
        { "violet", 7 },
        { "grey", 8 },
        { "white", 9 }
    };

    public static int ColorCode(string color)
    {
        if (string.IsNullOrEmpty(color))
            throw new ArgumentException();

        color = color.ToLower().Trim();

        if (!map.ContainsKey(color))
            throw new ArgumentException();

        return map[color];
    }

    public static string[] Colors()
    {
        return map.Keys.ToArray();
    }
}