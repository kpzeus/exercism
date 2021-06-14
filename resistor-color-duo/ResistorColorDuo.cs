using System;
using System.Collections.Generic;

public static class ResistorColorDuo
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

    public static int Value(string[] colors)
    {
        if(colors == null || colors.Length < 2)
        {
            throw new ArgumentException();
        }

        int val = 0;

        for (int i = 0; i < 2; i++)
        {
            var c = colors[i].ToLower();

            if (!map.ContainsKey(c))
                throw new ArgumentException();

            val = val * 10 + map[c];
        }

        return val;
    }
}
