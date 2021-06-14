using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private Dictionary<int, List<string>> d = new Dictionary<int, List<string>>();

    public void Add(string student, int grade)
    {
        if (!d.ContainsKey(grade))
            d.Add(grade, new List<string>());

        d[grade].Add(student);
    }

    public IEnumerable<string> Roster()
    {
        List<string> roaster = new List<string>();

        foreach (var item in d.OrderBy(x => x.Key))
        {
            roaster.AddRange(item.Value.OrderBy(x => x));
        }

        return roaster;
    }

    public IEnumerable<string> Grade(int grade)
    {
        if(d.ContainsKey(grade))
        {
            return d[grade].OrderBy(x => x);
        }

        return new string[] { };
    }
}