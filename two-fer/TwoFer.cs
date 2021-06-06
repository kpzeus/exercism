using System;

public static class TwoFer
{
    public static string Speak()
    {
        return "One for you, one for me.";
    }

    public static string Speak(string who)
    {
        return "One for " + who + ", one for me.";
    }
}
