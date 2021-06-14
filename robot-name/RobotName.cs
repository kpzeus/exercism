using System;
using System.Collections.Generic;

public class Robot
{
    private static HashSet<string> names = new HashSet<string>();

    private string name;

    private Random rand = new Random();

    public string Name
    {
        get
        {
            if (this.name == null)
            {
                this.Reset();
            }

            return this.name;
        }
    }

    public void Reset()
    {
        var newName = this.GetNewName();

        while (names.Contains(newName))
        {
            newName = this.GetNewName();
        }

        names.Add(newName);

        this.name = newName;
    }

    private string GetNewName()
    {
        var c1 = ((char)this.rand.Next('A', 'Z')).ToString();
        var c2 = ((char)this.rand.Next('A', 'Z')).ToString();
        var d = this.rand.Next(100, 999);

        return c1 + c2 + d;
    }
}