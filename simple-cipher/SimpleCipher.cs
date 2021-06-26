using System.Text;
using System;

public class SimpleCipher
{
    string key;

    public SimpleCipher()
    {
        this.key = "aaaaaaaaaaaaaaaaaa";
    }

    public SimpleCipher(string key)
    {
        this.key = key;
    }

    public string Key
    {
        get
        {
            return this.key;
        }
    }

    public string Encode(string plaintext)
    {
        var sb = new StringBuilder();

        var i = 0;

        foreach (var c in plaintext)
        {
            if (char.IsLetter(c))
            {
                var newValue = (int)c + (key[i] - 'a');
                if (newValue < 'a')
                    newValue += 26;
                if (newValue > 'z')
                    newValue -= 26;
                sb.Append((char)newValue);
                i++;
                if (i == key.Length)
                    i = 0;
            }
            else
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }

    public string Decode(string ciphertext)
    {
        var sb = new StringBuilder();

        var i = 0;

        foreach (var c in ciphertext)
        {
            if (char.IsLetter(c))
            {
                var newValue = (int)c - (key[i] - 'a');
                if (newValue < 'a')
                    newValue += 26;
                if (newValue > 'z')
                    newValue -= 26;
                sb.Append((char)newValue);
                i++;
                if (i == key.Length)
                    i = 0;
            }
            else
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }
}