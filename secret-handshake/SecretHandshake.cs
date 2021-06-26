using System;
using System.Collections.Generic;
using System.Collections.Generic;

public static class SecretHandshake
{
    public static string[] Commands(int commandValue)
    {
        var result = new List<string>();

        var revCount = (commandValue / 16) % 2;
        var n = commandValue % 16;

        if (n / 8 > 0) result.Add("jump");

        n = n % 8;

        if (n / 4 > 0) result.Add("close your eyes");

        n = n % 4;

        if (n / 2 > 0) result.Add("double blink");

        n = n % 2;

        if (n > 0) result.Add("wink");

        if (revCount == 0) result.Reverse();

        return result.ToArray();
    }
}
