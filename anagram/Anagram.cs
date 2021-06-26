using System.Linq;
using System.Collections.Generic;
using System;

public class Anagram
{
    Dictionary<char, int> map = new Dictionary<char, int>();
    string baseWord;

    public Anagram(string baseWord)
    {
        if (string.IsNullOrEmpty(baseWord))
            throw new ArgumentException();

        this.baseWord = baseWord.ToLower();

        baseWord.ToCharArray().ToList().ForEach(x =>
        {
            var v = char.ToLower(x);
            if (!map.ContainsKey(v))
            {
                map.Add(v, 1);
            }
            else
            {
                map[v] += 1;
            }
        });
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        var result = new List<string>();

        potentialMatches.ToList().ForEach(x =>
        {
            if (x.Length == this.baseWord.Length)
            {
                if (x.ToLower() == this.baseWord)
                    return;
                var m = new Dictionary<char, int>(map);
                x.ToCharArray().ToList().ForEach(c =>
                {
                    var v = char.ToLower(c);
                    if (!m.ContainsKey(v))
                        return;

                    m[v] -= 1;

                    if (m[v] == -1)
                        return;
                });
                if (!m.Select(x => x.Value).Any(x => x != 0))
                    result.Add(x);
            }
        });

        return result.ToArray();
    }
}