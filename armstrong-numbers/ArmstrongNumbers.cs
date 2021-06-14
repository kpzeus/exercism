using System;
using System.Collections.Generic;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        if (number < 0)
            throw new ArgumentException();

        int d = number;
        List<int> digits = new List<int>();
        double sum = 0;

        while(d > 0)
        {
            int rem = d % 10;
            digits.Add(rem);
            d = d / 10;
        }

        int p = digits.Count;
        foreach(var x in digits)
        {
            sum += Math.Pow(x, p);
        }

        return sum == number;
    }
}