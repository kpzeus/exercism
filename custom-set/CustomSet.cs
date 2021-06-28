using System;
using System.Collections.Generic;
using System.Linq;

public class CustomSet
{
    List<int> l = new List<int>();

    public CustomSet(params int[] values)
    {
        l.AddRange(values);
    }

    public CustomSet Add(int value)
    {
        if (!l.Contains(value))
            l.Add(value);
        return new CustomSet(l.ToArray());
    }

    public bool Empty()
    {
        return l.Count == 0;
    }

    public bool Contains(int value)
    {
        return l.Contains(value);
    }

    public bool Subset(CustomSet right)
    {
        if (this.l.Count == 0)
            return true;

        if (right == null || right.l.Count == 0)
        {
            return false;
        }

        return l.Where(x => right.Contains(x)).Count() == this.l.Count;
    }

    public bool Disjoint(CustomSet right)
    {
        return l.Where(x => right.Contains(x)).Count() == 0;
    }

    public CustomSet Intersection(CustomSet right)
    {
        return new CustomSet(l.Where(x => right.Contains(x)).ToArray());
    }

    public CustomSet Difference(CustomSet right)
    {
        return new CustomSet(l.Where(x => !right.Contains(x)).ToArray());
    }

    public CustomSet Union(CustomSet right)
    {
        var newL = new List<int>(l);
        newL.AddRange(right.l.Distinct());
        return new CustomSet(newL.Distinct().ToArray());
    }

    public override bool Equals(object obj)
    {
        CustomSet c = obj as CustomSet;

        if (obj == null)
        {
            return false;
        }

        if (c.l.Count != this.l.Count)
            return false;

        bool mismatch = false;
        c.l.ForEach(x =>
        {
            if (!this.l.Contains(x))
            {
                mismatch = true;
            }
        });

        if (mismatch)
            return false;

        return true;
    }

    public override int GetHashCode() => l.GetHashCode();
}