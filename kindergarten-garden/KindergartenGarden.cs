using System;
using System.Collections.Generic;

public enum Plant
{
    Violets = 'V',
    Radishes = 'R',
    Clover = 'C',
    Grass = 'G'
}

public class KindergartenGarden
{
    Dictionary<string, List<Plant>> map = new Dictionary<string, List<Plant>>();

    List<string>
        students =
            new List<string>()
            {
                "Alice",
                "Bob",
                "Charlie",
                "David",
                "Eve",
                "Fred",
                "Ginny",
                "Harriet",
                "Ileana",
                "Joseph",
                "Kincaid",
                "Larry"
            };

    public KindergartenGarden(string diagram)
    {
        var lines = diagram.Split('\n');
        var l1 = lines[0].ToUpper();
        var l2 = lines[1].ToUpper();

        if (l1.Length != l2.Length || l1.Length % 2 != 0)
            throw new ArgumentException();

        var student = "";
        for (var i = 0; i < l2.Length; i = i + 2)
        {
            student = students[i / 2];

            if (!map.ContainsKey(student)) map.Add(student, new List<Plant>());

            map[student].Add((Plant) l1[i]);
            map[student].Add((Plant) l1[i + 1]);
            map[student].Add((Plant) l2[i]);
            map[student].Add((Plant) l2[i + 1]);
        }
    }

    public IEnumerable<Plant> Plants(string student)
    {
        return map[student];
    }
}
