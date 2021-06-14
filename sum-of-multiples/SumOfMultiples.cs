using System;
using System.Collections.Generic;

public static class SumOfMultiples
{
    public static int Sum(int[] vs, int v)
    {
        int sum = 0;

        HashSet<int> h = new HashSet<int>();

        int i = 0;
        while (i < v)
        {
            foreach(var d in vs)
            {
                if(d != 0 && i % d == 0)
                {
                    h.Add(i);
                    break;
                }
            }

            i++;
        }

        foreach(var m in h)
        {
            sum += m;
        }

        return sum;
    }
}