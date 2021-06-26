using System;
using System.Collections.Generic;

public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        for (int i = 1; i < sum / 3; i++)
        {
            for (int j = i + 1; j < sum / 2; j++)
            {
                int k = sum - i - j;
                if (i * i + j * j == k * k)
                {
                    yield return (i, j, k);
                }
            }
        }
    }
}