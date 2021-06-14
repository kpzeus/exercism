using System;
using System.Text;

public static class RnaTranscription
{
    public static string ToRna(string nucleotide)
    {
        if (string.IsNullOrEmpty(nucleotide))
            return nucleotide;

        StringBuilder sb = new StringBuilder();

        foreach (var item in nucleotide)
        {
            switch (item)
            {
                case 'G':
                    sb.Append('C');
                    break;

                case 'C':
                    sb.Append('G');
                    break;

                case 'T':
                    sb.Append('A');
                    break;

                case 'A':
                    sb.Append('U');
                    break;
            }
        }

        return sb.ToString();
    }
}