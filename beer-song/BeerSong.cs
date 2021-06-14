using System;
using System.Text;

public static class BeerSong
{
    public static string Recite(int startBottles, int takeDown)
    {
        StringBuilder sb = new StringBuilder();

        for (var i = startBottles; i > 0 && takeDown > 0; i--)
        {
            sb.Append(i);
            sb.Append(" bottles of beer on the wall, ");
            sb.Append(i);
            sb.Append(" bottles of beer.\n");
            sb.Append("Take one down and pass it around, ");
            sb.Append(i-1);
            if(i-1 > 1)
                sb.Append(" bottles of beer on the wall.");
            else
                sb.Append(" bottle of beer on the wall.");
            takeDown--;

            if(takeDown > 0){
                sb.Append("\n\n");
            }
        }

        return sb.ToString();
    }
}