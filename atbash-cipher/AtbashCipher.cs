using System.Text;
using System;
using System.Linq;
using System.Text;

public static class AtbashCipher
{
    public static string Encode(string plainValue)
    {
        if (plainValue == null)
        {
            throw new ArgumentException();
        }

        var sb = new StringBuilder();

        var i = 0;

        plainValue.ToList().ForEach(x =>
        {
            if (char.IsLetter(x))
            {
                if (char.IsUpper(x))
                {
                    int d = x - 'A';
                    char v = (char)('Z' - d);
                    sb.Append(char.ToLower(v));
                    i++;
                }
                else
                {
                    int d = x - 'a';
                    char v = (char)('z' - d);
                    sb.Append(v);
                    i++;
                }
            }
            else
            {
                if (char.IsNumber(x))
                {
                    sb.Append(x);
                    i++;
                }
            }

            if (i == 5)
            {
                sb.Append(' ');
                i = 0;
            }
        });

        return sb.ToString().Trim();
    }

    public static string Decode(string encodedValue)
    {
        if (encodedValue == null)
        {
            throw new ArgumentException();
        }

        var sb = new StringBuilder();

        var i = 0;

        encodedValue.ToList().ForEach(x =>
        {
            if (char.IsLetter(x))
            {
                if (char.IsUpper(x))
                {
                    int d = x - 'A';
                    char v = (char)('Z' - d);
                    sb.Append(char.ToLower(v));
                    i++;
                }
                else
                {
                    int d = x - 'a';
                    char v = (char)('z' - d);
                    sb.Append(v);
                    i++;
                }
            }
            else
            {
                if (char.IsNumber(x))
                {
                    sb.Append(x);
                    i++;
                }
            }
        });

        return sb.ToString();
    }
}
