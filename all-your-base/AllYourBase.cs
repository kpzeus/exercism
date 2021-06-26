using System.Collections.Generic;
using System;

public static class AllYourBase
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        if (inputBase < 2 || outputBase < 2)
            throw new ArgumentException();

        var d = 0;
        var ib = 1;
        for (int i = inputDigits.Length - 1; i > -1; i--)
        {
            if (inputDigits[i] > inputBase - 1 || inputDigits[i] < 0)
                throw new ArgumentException();
            d = d + (inputDigits[i] * ib);
            ib = ib * inputBase;
        }

        var o = new List<int>();

        while (d > 0)
        {
            var r = d % outputBase;
            o.Insert(0, r);
            d = d / outputBase;
        }

        if (o.Count == 0)
            o.Add(0);

        return o.ToArray();
    }
}