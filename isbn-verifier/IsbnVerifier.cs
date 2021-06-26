using System;

public static class IsbnVerifier
{
    public static bool IsValid(string number)
    {
        if (number == null)
            return false;

        var v = 10;
        var sum = 0;
        var numberCount = 0;
        for (var i = 0; i < number.Length; i++)
        {
            if (number[i] != '-')
            {
                if (number[i] == 'X' && numberCount != 9)
                    return false;
                var n = number[i] - '0';
                if (number[i] == 'X')
                    n = 10;
                sum += v * n;
                v--;
                numberCount++;
            }
        }

        return
            (sum % 11) == 0
            &&
            (numberCount == 10);
    }
}