using System.Linq;
using System;
using System.Collections.Generic;

public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        if (rows < 0)
            throw new ArgumentException();

        List<int[]> r = new List<int[]>();
        for (int i = 0; i < rows; i++)
        {
            int[] row = new int[i + 1];
            row[0] = row[i] = 1;
            for (int j = 1; j < i; j++)
            {
                row[j] = r[i - 1][j - 1] + r[i - 1][j];
            }
            r.Add(row);
        }
        return r;
    }

}