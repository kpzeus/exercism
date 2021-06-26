using System;
using System.Collections.Generic;
using System.Linq;

public static class ScaleGenerator
{
    private static string[] SharpsScale = new[] { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
    private static string[] FlatsScale = new[] { "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab", "A", "Bb", "B" };
    private static string[] UseFlats = new[] { "F", "Bb", "Eb", "Ab", "Db", "Gb", "d", "g", "c", "f", "bb", "eb" };
    private static Dictionary<char, int> pics = new Dictionary<char, int> {
        {'m', 1},
        {'M', 2},
        {'A', 3}
    };

    public static string[] Chromatic(string tonic)
    {
        var s = UseFlats.Contains(tonic) ? FlatsScale : SharpsScale;
        var i = Array.IndexOf(s, UpperTonic(tonic));

        return Enumerable.Range(i, s.Length)
            .Select(x => s[x % s.Length]).ToArray();
    }

    public static string[] Interval(string tonic, string pattern)
    {
        var x = new List<int>();
        var curr = 0;
        x.Add(curr);
        foreach (char c in pattern)
        {
            if (!pics.ContainsKey(c)) throw new ArgumentException();

            curr += pics[c];
            if (curr < 12) x.Add(curr);
        }
        var scale = Chromatic(tonic);
        return x.Select(i => scale[i % scale.Length]).ToArray();
    }

    private static string UpperTonic(string t) => t.Substring(0, 1).ToUpper() + t.Substring(1);
}