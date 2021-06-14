using System;
using System.Collections.Generic;
using System.Text;

public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        if (subjects == null || subjects.Length < 1)
        {
            return subjects;
        }

        var result = new List<string>();

        var sb = new StringBuilder();

        if (subjects.Length > 1)
        {
            for (var i = 0; i < subjects.Length - 1; i++)
            {
                sb.Clear();
                sb.Append("For want of a ");
                sb.Append(subjects[i]);
                sb.Append(" the ");
                sb.Append(subjects[i + 1]);
                sb.Append(" was lost.");
                result.Add(sb.ToString());
            }
        }

        sb.Clear();
        sb.Append("And all for the want of a ");
        sb.Append(subjects[0]);
        sb.Append(".");
        result.Add(sb.ToString());

        return result.ToArray();
    }
}
