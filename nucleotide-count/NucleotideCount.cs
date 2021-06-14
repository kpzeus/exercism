using System;
using System.Collections.Generic;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        var d = new Dictionary<char, int>
        {
            ['A'] = 0,
            ['C'] = 0,
            ['G'] = 0,
            ['T'] = 0
        };

        if(sequence != null)
        {
            foreach (var item in sequence)
            {
                if (!d.ContainsKey(item))
                    throw new ArgumentException();

                d[item] += 1;
            }
        }

        return d;
    }
}