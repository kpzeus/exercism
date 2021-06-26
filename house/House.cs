using System.Collections.Generic;
using System.Text;
using System;
using System.Text;
using System.Linq;

public static class House
{
    static List<string> list = new List<string>(){
        "house that Jack built.",
        "malt that lay in",
        "rat that ate",
        "cat that killed",
        "dog that worried",
        "cow with the crumpled horn that tossed",
        "maiden all forlorn that milked",
        "man all tattered and torn that kissed",
        "priest all shaven and shorn that married",
        "rooster that crowed in the morn that woke",
        "farmer sowing his corn that kept",
        "horse and the hound and the horn that belonged to",
    };

    public static string Recite(int verseNumber)
    {
        if (verseNumber < 1)
            throw new ArgumentException();

        var sb = new StringBuilder();

        sb.Append("This is");
        verseNumber--;
        while (verseNumber > -1)
        {
            sb.Append(" the ");
            sb.Append(list[verseNumber]);

            verseNumber--;
        }


        return sb.ToString();
    }

    public static string Recite(int startVerse, int endVerse)
    {
        return string
            .Join(
            "\n",
            Enumerable
            .Range(startVerse, endVerse - startVerse + 1)
            .Select(x => Recite(x)
            )).Trim('\n');
    }
}