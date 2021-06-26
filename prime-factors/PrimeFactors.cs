using System.Collections.Generic;
using System;

public static class PrimeFactors
{
    public static long[] Factors(long number)
    {
        var r = new List<long>();

        for (var i = 2; i < number; i++)
        {
            while (number % i == 0)
            {
                r.Add(i);
                number = number / i;
            }
        }

        if (number > 1)
            r.Add(number);

        return r.ToArray();
    }
}