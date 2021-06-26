using System;
using System.Collections.Generic;

public static class Sieve
{
    public static int[] Primes(int limit)
    {
        if (limit < 2) throw new ArgumentOutOfRangeException();

        List<int> primes = new List<int>();
        HashSet<int> nonPrimes = new HashSet<int>();

        for (var i = 2; i <= limit; i++)
        {
            if (!nonPrimes.Contains(i)) primes.Add(i);

            var j = i;
            while (j <= limit)
            {
                j = j + i;
                nonPrimes.Add(j);
            }
        }

        return primes.ToArray();
    }
}
