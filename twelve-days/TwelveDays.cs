using System.Linq;

using System;
using System.Collections.Generic;
using System.Text;

public static class TwelveDays
{
    private static readonly IReadOnlyList<string>
        ordinals =
            new List<string>()
            {
                "first",
                "second",
                "third",
                "fourth",
                "fifth",
                "sixth",
                "seventh",
                "eighth",
                "ninth",
                "tenth",
                "eleventh",
                "twelfth"
            };

    private static readonly IReadOnlyList<string>
        gifts =
            new List<string>()
            {
                "a Partridge in a Pear Tree",
                "two Turtle Doves",
                "three French Hens",
                "four Calling Birds",
                "five Gold Rings",
                "six Geese-a-Laying",
                "seven Swans-a-Swimming",
                "eight Maids-a-Milking",
                "nine Ladies Dancing",
                "ten Lords-a-Leaping",
                "eleven Pipers Piping",
                "twelve Drummers Drumming"
            };

    public static string Recite(int verseNumber)
    {
        var sb = new StringBuilder();

        sb.Append("On the ");
        sb.Append(ordinals[verseNumber - 1]);
        sb.Append(" day of Christmas my true love gave to me: ");
        var i = verseNumber - 1;
        while (i > -1)
        {
            sb.Append(gifts[i]);
            if (i > 0)
                sb.Append(", ");
            if (i == 1)
            {
                sb.Append("and ");
            }
            i--;
        }
        sb.Append('.');

        return sb.ToString();
    }

    public static string Recite(int startVerse, int endVerse)
    {
        return string.Join("\n", Enumerable.Range(startVerse, endVerse - startVerse + 1).Select(x => Recite(x)));
    }
}
