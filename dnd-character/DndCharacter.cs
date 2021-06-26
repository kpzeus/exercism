using System;
using System.Collections.Generic;
using System.Linq;

public class DndCharacter
{
    public int Strength { get; }

    public int Dexterity { get; }

    public int Constitution { get; }

    public int Intelligence { get; }

    public int Wisdom { get; }

    public int Charisma { get; }

    public int Hitpoints { get; }

    private static Random rand = new Random();

    public DndCharacter()
    {
        Strength = Ability();
        Dexterity = Ability();
        Intelligence = Ability();
        Wisdom = Ability();
        Charisma = Ability();
        Constitution = Ability();

        Hitpoints = 10 + Modifier(Constitution);
    }

    public static int Modifier(int score)
    {
        var s1 = (double) 10 - score;
        var s2 = s1 / 2;
        var s3 = Math.Ceiling(s2) * -1;
        return (int) s3;
    }

    public static int Ability()
    {
        var result = 0;

        List<int> val = new List<int>();

        var i = 0;
        while (i < 4)
        {
            val.Add(rand.Next(1, 7));
            i++;
        }

        result = val.OrderByDescending(x => x).Take(3).Sum();

        return result;
    }

    public static DndCharacter Generate()
    {
        DndCharacter d = new DndCharacter();
        return d;
    }
}
