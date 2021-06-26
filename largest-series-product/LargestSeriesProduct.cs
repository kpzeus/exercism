using System.Linq;
using System;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span)
    {
        if (span < 0)
            throw new ArgumentException();

        if (digits == null)
            throw new ArgumentException();

        if (span > digits.Length)
            throw new ArgumentException();

        if (digits.ToCharArray().Any(x => !char.IsNumber(x)))
            throw new ArgumentException();

        if (span == 0)
            return 1;
        
        if (digits.Length == 0)
            return 1;

        long p = 0;

        for (var i = 0; i + span - 1 < digits.Length; i++)
        {
            long curr = digits
                .Substring(i, span)
                .ToCharArray()
                .Select(x => x - '0')
                .Aggregate(1, (product, val) => product * val);

            p = Math.Max(p, curr);
        }

        return p;
    }
}