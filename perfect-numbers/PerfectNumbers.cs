using System;
using System.Collections.Generic;
using System.Linq;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if (number < 1)
            throw new ArgumentOutOfRangeException();

        var factors = new List<int>();

        long sum = 0;

        for (int i = 1; i <= number / 2; i++)
        {
            if (number % i == 0)
            {
                factors.Add(i);
                sum += i;

                if (sum > number)
                    return Classification.Abundant;
            }
        }

        if (sum == number)
            return Classification.Perfect;        

        return Classification.Deficient;
    }
}
