using System;
using System.Text;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        if(string.IsNullOrEmpty(phoneNumber))
            throw new ArgumentException();
        
        StringBuilder sb = new StringBuilder();

        foreach (var c in phoneNumber)
        {
            if(char.IsLetter(c))
                throw new ArgumentException();
            
            if(char.IsNumber(c))
                sb.Append(c);
        }

        if(sb.Length < 10 || sb.Length > 11)
            throw new ArgumentException();

        if(sb.Length == 11){
            if(sb[0] == '1'){
                sb.Remove(0,1);
            } 
            else
            {
                throw new ArgumentException();
            }
        }

        if(sb[0] == '0' || sb[0] == '1')
            throw new ArgumentException();

        if(sb[3] == '0' || sb[3] == '1')
            throw new ArgumentException();          

        return sb.ToString();
    }
}