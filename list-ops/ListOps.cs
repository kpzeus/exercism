using System;
using System.Collections.Generic;
using System.Linq;

public static class ListOps
{
    public static int Length<T>(List<T> input)
    {
        var c = 0;
        foreach (var item in input)
        {
            c++;
        }
        return c;
    }

    public static List<T> Reverse<T>(List<T> input)
    {
        var c = new List<T>();
        for (int i = Length(input) - 1; i >= 0; i--)
        {
            c.Add(input[i]);
        }
        return c;
    }

    public static List<TOut> Map<TIn, TOut>(List<TIn> input, Func<TIn, TOut> map)
    {
        var c = new List<TOut>();
        foreach (var item in input)
        {
            c.Add(map(item));
        }
        return c;
    }

    public static List<T> Filter<T>(List<T> input, Func<T, bool> predicate)
    {
        var c = new List<T>();
        foreach (var item in input)
        {
            if (predicate(item))
                c.Add(item);
        }
        return c;
    }

    public static TOut Foldl<TIn, TOut>(List<TIn> input, TOut start, Func<TOut, TIn, TOut> func)
    {
        foreach (var item in input)
        {
            start = func(start, item);
        }
        return start;
    }

    public static TOut Foldr<TIn, TOut>(List<TIn> input, TOut start, Func<TIn, TOut, TOut> func)
    {
        foreach (var item in Reverse(input))
        {
            start = func(item, start);
        }
        return start;
    }

    public static List<T> Concat<T>(List<List<T>> input)
    {
        var c = new List<T>();
        foreach (var item in input)
        {
            foreach (var item2 in item)
            {
                c.Add(item2);
            }
        }
        return c;
    }

    public static List<T> Append<T>(List<T> left, List<T> right)
    {
        foreach (var item in right)
        {
            left.Add(item);
        }
        return left;
    }
}