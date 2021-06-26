using System.Text;
using System.Collections.Generic;
using System;
using System.Linq;

public static class RomanNumeralExtension
{
    static string GetNumeral(int digit) => digit switch
    {
        1 => "I",
        2 => "II",
        3 => "III",
        4 => "IV",
        5 => "V",
        6 => "VI",
        7 => "VII",
        8 => "VIII",
        9 => "IX",
        _ => ""
    };

    static string GetPower(int power) => power switch
    {
        10 => "X",
        50 => "L",
        100 => "C",
        500 => "D",
        1000 => "M",
        _ => ""
    };

    public static string ToRoman(this int value)
    {
        if (value < 1 || value > 3000)
            throw new ArgumentException();

        var sb = new StringBuilder();
        var v = 0;

        if (value >= 1000)
        {
            v = value / 1000;
            while (v > 0)
            {
                sb.Append(GetPower(1000));
                v--;
            }
            value = value % 1000;
        }

        if (value >= 500)
        {
            if (value > 899)
            {
                sb.Append(GetPower(100));
                sb.Append(GetPower(1000));
                value = value - 900;
            }
            else
            {
                sb.Append(GetPower(500));
                value = value - 500;
                v = value / 100;
                while (v > 5)
                {
                    sb.Append(GetNumeral(100));
                    value = value - 100;
                    v--;
                }
            }

        }

        if (value >= 100)
        {
            if (value > 399)
            {
                sb.Append(GetPower(100));
                sb.Append(GetPower(500));
            }
            else
            {
                v = value / 100;
                while (v > 0)
                {
                    sb.Append(GetPower(100));
                    v--;
                }
            }
            value = value % 100;
        }

        if (value >= 50)
        {
            if (value > 89)
            {
                sb.Append(GetPower(10));
                sb.Append(GetPower(100));
                value = value - 90;
            }
            else
            {
                sb.Append(GetPower(50));
                value = value - 50;
                v = value / 10;
                while (v > 5)
                {
                    sb.Append(GetNumeral(10));
                    value = value - 10;
                    v--;
                }
            }
        }

        if (value >= 10)
        {
            if (value > 39)
            {
                sb.Append(GetPower(10));
                sb.Append(GetPower(50));
            }
            else
            {
                v = value / 10;
                while (v > 0)
                {
                    sb.Append(GetPower(10));
                    v--;
                }
            }
            value = value % 10;
        }

        if (value > 0)
        {
            sb.Append(GetNumeral(value));
        }

        return sb.ToString();
    }
}