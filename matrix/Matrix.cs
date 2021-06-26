using System.Collections.Generic;
using System;
using System.Linq;

public class Matrix
{
    int[,] m = new int[0, 0];

    public Matrix(string input)
    {
        if (!string.IsNullOrEmpty(input))
        {
            var rows = input.Split('\n');
            var i = 0;
            rows.ToList().ForEach(row =>
            {
                var cols = row.Split(' ');
                var j = 0;
                if (m.GetLength(0) == 0)
                {
                    m = new int[rows.Length, cols.Length];
                }
                cols.ToList().ForEach(col =>
                {
                    m[i, j] = Convert.ToInt32(col);
                    j++;
                });
                i++;
            });
        }
    }

    public int Rows
    {
        get
        {
            return m.GetLength(0);
        }
    }

    public int Cols
    {
        get
        {
            return m.GetLength(1);
        }
    }

    public int[] Row(int row)
    {
        var x = new List<int>();
        row = row - 1;
        if (row > -1 && row < m.GetLength(0))
        {
            for (var i = 0; i < m.GetLength(1); i++)
            {
                x.Add(m[row, i]);
            }
        }

        return x.ToArray();
    }

    public int[] Column(int col)
    {
        var x = new List<int>();
        col = col - 1;
        if (col > -1 && col < m.GetLength(1))
        {
            for (var i = 0; i < m.GetLength(0); i++)
            {
                x.Add(m[i, col]);
            }
        }

        return x.ToArray();
    }
}