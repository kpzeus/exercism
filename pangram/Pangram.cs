using System;
using System.Collections.Generic;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return false;
        }

        input = input.ToLower();

        HashSet<char> h = new HashSet<char>();

        foreach (var item in input)
        {
            if (char.IsLetter(item))
            {
                h.Add(item);
            }            
        }

        return h.Count == 26;
    }
}
