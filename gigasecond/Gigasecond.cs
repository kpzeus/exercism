using System;

public static class Gigasecond
{
    const double Giga = 1000 * 1000 * 1000;

    public static DateTime Add(DateTime moment)
    {
        if (moment == null)
            return moment;

        return moment.AddSeconds(Giga);
    }
}