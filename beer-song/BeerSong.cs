using System;
using System.Text;

public static class BeerSong
{
    private const string TerminateLine = "\n";
    private const string Terminate = "." + TerminateLine;
    private const string GoToStore = "Go to the store and buy some more, ";

    private static string GetBottles(int i, bool upper)
    {
        var n = "n";

        if (upper)
            n = "N";

        if (i > 1)
            return i + " bottles of beer";
        else if (i == 1)
            return i + " bottle of beer";
        else
            return n + "o more bottles of beer";
    }

    private static string OnTheWall(bool terminate)
    {
        if(terminate)
            return " on the wall.";
        else
            return " on the wall, ";
    }

    private static string PassAround(int i)
    {
        if (i > 1)
            return "Take one down and pass it around, ";
        else
            return "Take it down and pass it around, ";
    }

    public static string Recite(int startBottles, int takeDown)
    {
        StringBuilder sb = new StringBuilder();

        var i = 0;

        for (i = startBottles; i > 0 && takeDown > 0; i--)
        {
            sb.Append(GetBottles(i, false));
            sb.Append(OnTheWall(false));
            sb.Append(GetBottles(i, false));
            sb.Append(Terminate);
            sb.Append(PassAround(i));
            sb.Append(GetBottles(i - 1, false));
            sb.Append(OnTheWall(true));
            takeDown--;

            if(takeDown > 0){
                sb.Append(TerminateLine);
                sb.Append(TerminateLine);
            }
        }

        if(takeDown > 0)
        {
            sb.Append(GetBottles(0,true));
            sb.Append(OnTheWall(false));
            sb.Append(GetBottles(0, false));
            sb.Append(Terminate);
            sb.Append(GoToStore);
            sb.Append(GetBottles(99, false));
            sb.Append(OnTheWall(true));
        }

        return sb.ToString();
    }
}