using System;
using System.Linq;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        return string.Join(
            string.Empty,
            phrase.Split(new char[] { ' ', '-' })
            .Where(x =>
            {
                return x.FirstOrDefault(z => char.IsLetter(z)) != '\0';
            })
            .Select(
                x =>
                {
                    var val = x.FirstOrDefault(z => char.IsLetter(z));
                    return val.ToString().ToUpper();
                }
                ));
    }
}