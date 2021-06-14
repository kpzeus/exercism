using System;
using System.Collections.Generic;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        if (string.IsNullOrEmpty(word))
        {
            return true;
        }

        word = word.ToLower();

        HashSet<char> h = new HashSet<char>();

        foreach (var item in word)
        {
            if (char.IsLetter(item))
            {
                if (h.Contains(item))
                    return false;

                h.Add(item);
            }
        }

        return true;
    }
}
