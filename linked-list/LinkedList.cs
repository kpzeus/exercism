using System;
using System.Collections.Generic;

public class Deque<T>
{
    List<T> l = new List<T>();

    public void Push(T value)
    {
        l.Add(value);
    }

    public T Pop()
    {
        if (l.Count == 0)
            throw new InvalidOperationException();

        var x = l[l.Count - 1];
        l.RemoveAt(l.Count - 1);
        return x;
    }

    public void Unshift(T value)
    {
        l.Insert(0, value);
    }

    public T Shift()
    {
        if (l.Count == 0)
            throw new InvalidOperationException();

        var x = l[0];
        l.RemoveAt(0);
        return x;
    }
}