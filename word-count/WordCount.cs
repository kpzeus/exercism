using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

public static class WordCount
{
    public static IDictionary<string, int> CountWords(string phrase)
    {
        if (phrase == null)
            throw new ArgumentException();

        var result = new Dictionary<string, int>();

        phrase.Split(new char[] { ' ', '\n', ',' }).ToList().ForEach(x =>
         {
             var v = string
             .Join("",
             x
             .ToLower()
             .Trim('\'')
             .Where(c =>
             char.IsLetter(c)
             || char.IsNumber(c)
             || c == '\''
             ));

             if (v.Length > 0)
             {
                 if (!result.ContainsKey(v))
                 {
                     result.Add(v, 1);
                 }
                 else
                 {
                     result[v] += 1;
                 }
             }
         });

        return result;
    }
}