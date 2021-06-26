using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class CryptoSquare
{
    public static string NormalizedPlaintext(string plaintext)
    {
        if (plaintext is null)
        {
            throw new ArgumentNullException(nameof(plaintext));
        }

        return new string(plaintext
            .Where(x => char.IsLetter(x) || char.IsDigit(x))
            .Select(x => char.ToLower(x)).ToArray());
    }

    public static IEnumerable<string> PlaintextSegments(string plaintext)
    {
        if (plaintext is null)
        {
            throw new ArgumentNullException(nameof(plaintext));
        }

        plaintext = NormalizedPlaintext(plaintext);

        var l = plaintext.Length;

        var result = new List<string>();

        var dim = GetDim(plaintext);
        var r = dim.Item1;
        var c = dim.Item2;

        var i = 0;
        while (i + c < l)
        {
            result.Add(plaintext.Substring(i, c));
            i += c;
        }
        var last = plaintext.Substring(i, l - i);
        last = last + string.Join("", Enumerable.Repeat(' ', c - last.Length));
        result.Add(last);

        return result;
    }

    public static string Encoded(string plaintext)
    {
        if (plaintext is null)
        {
            throw new ArgumentNullException(nameof(plaintext));
        }

        var seg = PlaintextSegments(plaintext).ToList();

        var result = new StringBuilder();

        if (seg.Count > 0)
        {
            var r = 0;
            var c = 0;
            while (c < seg[0].Length)
            {
                r = 0;
                while (r < seg.Count)
                {
                    result.Append(seg[r][c]);
                    r++;
                }
                c++;
            }
        }

        return result.ToString().Trim();
    }

    public static string Ciphertext(string plaintext)
    {
        if (plaintext is null)
        {
            throw new ArgumentNullException(nameof(plaintext));
        }

        plaintext = NormalizedPlaintext(plaintext);

        var result = new StringBuilder();

        if (plaintext.Length > 0)
        {
            var dim = GetDim(plaintext);
            var r = dim.Item1;
            var c = dim.Item2;

            var encoded = Encoded(plaintext);

            var i = 0;
            while (i + r < encoded.Length)
            {
                result.Append(encoded.Substring(i, r));
                result.Append(' ');
                i += r;
            }
            var last = encoded.Substring(i, encoded.Length - i);
            result.Append(last);
            if (last.Length != r)
                result.Append(' ');
        }

        return result.ToString();
    }

    private static (int, int) GetDim(string text)
    {
        var r = 1;
        var c = 1;

        bool t = true;

        while (c * r < text.Length)
        {
            if (t)
                c++;
            else
                r++;

            t = !t;
        }

        return (r, c);
    }
}