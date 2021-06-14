using System;
using System.Text;

public static class Raindrops
{
    public static string Convert(int number)
    {
        StringBuilder sb = new StringBuilder();

        if(number % 3 == 0){
            sb.Append("Pling");
        }

         if(number % 5 == 0){
            sb.Append("Plang");
        }

         if(number % 7 == 0){
            sb.Append("Plong");
        }

        if(sb.Length == 0){
            sb.Append(number.ToString());
        }

        return sb.ToString();
    }
}