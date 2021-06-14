using System;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand == null || secondStrand == null)
            throw new ArgumentException();

        if(firstStrand.Length != secondStrand.Length)
            throw new ArgumentException();

        firstStrand = firstStrand.ToUpper().Trim();
        secondStrand = secondStrand.ToUpper().Trim();

        int h = 0;

        for (int i = 0; i < firstStrand.Length; i++)
        {
            if(firstStrand[i] != secondStrand[i])
            {
                h++;
            }
        }

        return h;
    }
}