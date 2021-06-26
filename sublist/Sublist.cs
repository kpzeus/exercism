using System;
using System.Collections.Generic;

public enum SublistType
{
    Equal,
    Unequal,
    Superlist,
    Sublist
}

public static class Sublist
{
    public static SublistType Classify<T>(List<T> list1, List<T> list2)
        where T : IComparable
    {
        if (list1 == null || list2 == null)
        {
            throw new ArgumentException();
        }

        if (list1.Count == list2.Count)
        {
            if (list1.Count == 0)
                return SublistType.Equal;

            for (var i = 0; i < list1.Count; i++)
            {
                if (!list1[i].Equals(list2[i]))
                {
                    return SublistType.Unequal;
                }
            }

            return SublistType.Equal;
        }

        if (list1.Count < list2.Count)
        {
            return Classify2(list1, list2);
        }
        else
        {
            var x = Classify2(list2, list1);

            if (x == SublistType.Sublist)
                return SublistType.Superlist;
        }

        return SublistType.Unequal;
    }

    private static SublistType Classify2<T>(List<T> list1, List<T> list2)
    {
        var j = 0;
        var start = -1;
        if (list1.Count > 0)
        {
            for (var i = 0; i < list2.Count; i++)
            {
                if (list1[j].Equals(list2[i]))
                {
                    if (start == -1)
                    {
                        start = i;
                    }
                    j++;
                    if (j == list1.Count)
                        return SublistType.Sublist;
                }
                else
                {
                    i = start;
                    start++;
                    j = 0;
                }
            }
        }
        else
        {
            return SublistType.Sublist;
        }

        return SublistType.Unequal;
    }
}