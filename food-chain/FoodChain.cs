using System.Text;
using System;
using System.Collections.Generic;

public static class FoodChain
{
    private static readonly Dictionary<int, string> Animals = new Dictionary<int, string> {
        { 1, "fly" },
        { 2, "spider" },
        { 3, "bird" },
        { 4, "cat" },
        { 5, "dog" },
        { 6, "goat" },
        { 7, "cow" },
        { 8, "horse" }
    };

    private static readonly Dictionary<int, string> Verses = new Dictionary<int, string> {
        { 1, "I don't know why she swallowed the fly. Perhaps she'll die."},
        { 2, "It wriggled and jiggled and tickled inside her."},
        { 3, "How absurd to swallow a bird!"},
        { 4, "Imagine that, to swallow a cat!"},
        { 5, "What a hog, to swallow a dog!"},
        { 6, "Just opened her throat and swallowed a goat!"},
        { 7, "I don't know how she swallowed a cow!"},
        { 8, "She's dead, of course!"},
        { 9, "that wriggled and jiggled and tickled inside her."}
    };

    public static string Recite(int verseNumber)
    {
        var sb = new StringBuilder();

        sb.Append("I know an old lady who swallowed a " + Animals[verseNumber] + ".\n");
        sb.Append(Verses[verseNumber] + "\n");
        if (verseNumber > 1 && verseNumber < 8)
        {
            var i = verseNumber;
            while (i > 1)
            {
                sb.Append("She swallowed the " + Animals[i] + " to catch the " + Animals[i - 1]);
                if (i == 3)
                {
                    sb.Append(" " + Verses[9] + "\n");
                }
                else
                {
                    sb.Append(".\n");
                }
                i--;
            }
            sb.Append(Verses[1] + "\n");
        }

        return sb.ToString().Trim('\n');
    }

    public static string Recite(int startVerse, int endVerse)
    {
        var sb = new StringBuilder();

        while (startVerse <= endVerse)
        {
            sb.Append(Recite(startVerse));
            sb.Append("\n\n");
            startVerse++;
        }

        return sb.ToString().Trim('\n');
    }
}