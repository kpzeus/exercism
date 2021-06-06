using System;

public static class Leap
{
    public static bool IsLeapYear(int year)
    {
        var By4 = year % 4 == 0;

        if (!By4)
            return false;

        var By100 = year % 100 == 0;

        if (By100)
        {
            return year % 400 == 0;
        }

        return true;
    }
}