using System;
using System.Collections.Generic;
using System.Linq;

public static class ParallelLetterFrequency
{
    public static Dictionary<char, int> Calculate(IEnumerable<string> texts)
    {
        var res = new Dictionary<char, int>();

        texts.ToList().ForEach(x =>
        {
            Calculate(x, res);
        });

        return res;
    }

    public async static void Calculate(string text, Dictionary<char, int> res)
    {
        text.ToList().ForEach(x =>
        {
            if (char.IsLetter(x))
            {
                var v = char.ToLower(x);
                if (!res.ContainsKey(v))
                {
                    res.Add(v, 1);
                }
                else
                {
                    res[v] += 1;
                }
            }
        });
    }
}