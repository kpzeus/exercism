using System;
using System.Collections.Generic;
using System.Linq;

public class HighScores
{
    Dictionary<int, int> d = new Dictionary<int, int>();
    List<int> list = new List<int>();

    public HighScores(List<int> list)
    {
        LoadItems(list, 3);
    }

    public HighScores(List<int> list, int topN)
    {
        LoadItems(list, topN);
    }

    private void LoadItems(List<int> list, int topN)
    {
        if (list == null)
            return;

        this.list = new List<int>(list);

        this.list.ForEach(x =>
        {
            if (d.Count == topN && x > d.Keys.Max())
            {
                d.Remove(d.Keys.Min());
            }

            if (d.ContainsKey(x))
            {
                d[x] += 1;
            }
            else
            {
                d[x] = 1;
            }
        });
    }

    public List<int> Scores()
    {
        return this.list;
    }

    public int Latest()
    {
        if (this.list.Count == 0)
            throw new InvalidOperationException();

        return this.list.Last();
    }

    public int PersonalBest()
    {
        return d.Keys.Max();
    }

    public List<int> PersonalTopThree()
    {
        return this.GetTopN(3);
    }

    public List<int> PersonalTopN(int n)
    {
        return this.GetTopN(n);
    }

    private List<int> GetTopN(int n)
    {
        var top = new List<int>();

        if (d.Keys.Count == 0)
            return top;

        var max = d.Keys.Max();
        var maxCount = d[max];

        while (top.Count < n)
        {
            while (maxCount > 0 && top.Count < n)
            {
                top.Add(max);
                maxCount--;
            }

            var lowerKeys = d.Keys.Where(x => x < max);
            if (lowerKeys.Any())
            {
                max = lowerKeys.Max();
                maxCount = d[max];
            }
            else
                break;
        }

        return top;
    }
}