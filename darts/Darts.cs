using System;

public static class Darts
{
    public static int Score(double x, double y)
    {
        var d = Math.Pow(x * x + y * y, 0.5);

        if (d > 10) return 0;

        if (d > 5) return 1;

        if (d > 1) return 5;

        return 10;
    }
}
