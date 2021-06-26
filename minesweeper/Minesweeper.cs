using System;

public static class Minesweeper
{
    public static string[] Annotate(string[] input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < input[0].Length; j++)
            {
                if (input[i][j] == '*')
                    continue;

                var c = 0;

                c = countRows(input, i, j);

                if (c > 0)
                {
                    var s = input[i].ToCharArray();
                    s[j] = (char)(c + '0');
                    input[i] = new string(s);
                }
            }
        }

        return input;
    }

    private static int countRows(string[] input, int i, int j)
    {
        var c = 0;

        if (i > 0)
        {
            c += countRowElements(input[i - 1], j);
        }
        c += countRowElements(input[i], j);
        if (i < input.Length - 1)
        {
            c += countRowElements(input[i + 1], j);
        }

        return c;
    }

    private static int countRowElements(string input, int j)
    {
        var c = 0;

        if (j > 0 && input[j - 1] == '*')
        {
            c++;
        }

        if (input[j] == '*')
        {
            c++;
        }

        if (j < input.Length - 1 && input[j + 1] == '*')
        {
            c++;
        }

        return c;
    }
}
