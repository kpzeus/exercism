using System;
using System.Collections.Generic;
using System.Linq;

public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        var result = new List<(int, int)>();

        if (matrix == null || matrix.Length == 0 || matrix.GetLength(0) == 0)
            return result;

        int[,] set = new int[matrix.GetLength(0), matrix.GetLength(1)];

        for (var row = 0; row < matrix.GetLength(0); row++)
        {
            var val = int.MinValue;

            for (var col = 0; col < matrix.GetLength(1); col++)
            {
                if (val < matrix[row, col])
                {
                    val = matrix[row, col];
                }
            }

            for (var col = 0; col < matrix.GetLength(1); col++)
            {
                if (val == matrix[row, col])
                {
                    set[row, col] += 1;
                }
            }
        }

        for (var col = 0; col < matrix.GetLength(1); col++)
        {
            var val = int.MaxValue;

            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                if (val > matrix[row, col])
                {
                    val = matrix[row, col];
                }
            }

            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                if (val == matrix[row, col])
                {
                    set[row, col] += 1;
                }
            }
        }

        for (var row = 0; row < matrix.GetLength(0); row++)
        {
            for (var col = 0; col < matrix.GetLength(1); col++)
            {
                if (set[row, col] == 2)
                    result.Add((row + 1, col + 1));
            }
        }

        return result.ToArray();
    }
}
