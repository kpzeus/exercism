using System;
using System.Collections.Generic;

public static class ProteinTranslation
{
    private static readonly Dictionary<string, string>
        map =
            new Dictionary<string, string>()
            {
                { "AUG", "Methionine" },
                { "UUU", "Phenylalanine" },
                { "UUC", "Phenylalanine" },
                { "UUA", "Leucine" },
                { "UUG", "Leucine" },
                { "UCU", "Serine" },
                { "UCC", "Serine" },
                { "UCA", "Serine" },
                { "UCG", "Serine" },
                { "UAU", "Tyrosine" },
                { "UAC", "Tyrosine" },
                { "UGU", "Cysteine" },
                { "UGC", "Cysteine" },
                { "UGG", "Tryptophan" }
            };

    public static string[] Proteins(string strand)
    {
        var result = new List<string>();

        if (strand == null || strand.Length < 3 || strand.Length % 3 != 0)
            return result.ToArray();

        for (var i = 0; i < strand.Length; i = i + 3)
        {
            var key = strand.Substring(i, 3).ToUpper();
            if (key == "UAA" || key == "UAG" || key == "UGA") break;

            if (!map.ContainsKey(key)) throw new ArgumentException();

            result.Add(map[key]);
        }

        return result.ToArray();
    }
}
