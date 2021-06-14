using System;
using System.Collections.Generic;

public static class ResistorColorTrio
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
    public static string Label(string[] colors)
    {
        if (colors == null || colors.Length < 3)
        {
            throw new ArgumentException();
        }

        int val = 0;
        string c;

        for (int i = 0; i < 2; i++)
        {
            c = colors[i].ToLower();

            if (!map.ContainsKey(c))
                throw new ArgumentException();

            val = val * 10 + map[c];
        }

        c = colors[2].ToLower();
        if (!map.ContainsKey(c))
            throw new ArgumentException();

        var z = map[c];

        while(z > 0)
        {
            val *= 10;
            z--;
        }

        if (val >= 1000)
            return val/1000 + " kiloohms";
        else
            return val + " ohms";
    }
}
