using System;
using System.Collections.Generic;
using System.Linq;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        var newDict = new Dictionary<string, int>();
        
        if (old == null) 
            return newDict;

        foreach (var score in old.Keys)
        {
            foreach (var letter in old[score])
            {
                newDict.Add(letter.ToLower(), score);
            }
        }

        return newDict;
    }
}
