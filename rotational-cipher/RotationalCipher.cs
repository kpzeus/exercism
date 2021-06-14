using System;
using System.Text;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        if (string.IsNullOrEmpty(text))
            return text;

        shiftKey = shiftKey % 26;

        StringBuilder sb = new StringBuilder();

        foreach (var i in text)
        {
            if (char.IsLetter(i))
            {
                var c = (int)i + shiftKey;

                if(char.ToLower(i) == i)
                {
                    if(c < 'a')
                    {
                        c = c + 26;
                    }
                    else if (c > 'z')
                    {
                        c = c - 26;
                    }
                }
                else
                {
                    if (c < 'A')
                    {
                        c = c + 26;
                    }
                    else if (c > 'Z')
                    {
                        c = c - 26;
                    }
                }

                sb.Append((char)c);
            }
            else
            {
                sb.Append(i);
            }            
        }

        return sb.ToString();
    }
}