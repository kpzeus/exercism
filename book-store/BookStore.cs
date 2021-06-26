using System;
using System.Collections.Generic;
using System.Linq;

public static class BookStore
{
    public static Dictionary<int, decimal> GroupPrice =
        new Dictionary<int, decimal> {
            {1, 8m},
            {2, 15.2m},
            {3, 21.6m},
            {4, 25.6m},
            {5, 30m},
        };

    public static decimal Total(IEnumerable<int> books)
    {
        var mapBase = new Dictionary<int, int>();
        books.ToList().ForEach(book =>
        {
            if (!mapBase.ContainsKey(book))
            {
                mapBase.Add(book, 1);
            }
            else
            {
                mapBase[book] += 1;
            }
        });

        var i = 5;
        decimal currTotal = decimal.MaxValue;
        var startingGroup = 5;
        while (i > 0)
        {
            var group = startingGroup--;
            decimal c = 0;
            var map = new Dictionary<int, int>(mapBase);
            var op = 5;
            while (op > 0)
            {
                while (map.Count >= group)
                {
                    c += GroupPrice[group];
                    DecrementMap(map, group);
                }
                op--;
                group--;
                if (group == 0)
                    group = 5;
            }

            currTotal = Math.Min(currTotal, c);
            i--;
        }

        return currTotal;
    }

    private static void DecrementMap(Dictionary<int, int> map, int group)
    {
        map.OrderByDescending(x => x.Value).ToList().ForEach(x =>
        {
            if (group > 0 && map[x.Key] > 0)
            {
                map[x.Key] -= 1;
                group--;
            }
        });

        for (int i = 1; i < 6; i++)
        {
            if (map.ContainsKey(i))
            {
                if (map[i] == 0)
                {
                    map.Remove(i);
                }
            }
        }
    }
}