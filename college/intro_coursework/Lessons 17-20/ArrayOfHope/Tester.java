import java.io.*;
import java.util.*;
public class Tester
{
    public static void main(String args[])
    {
        char ch[] = new char[26];
        for(int j = 65; j<91; j++)
        {
            int l = j - 65;
            ch[l] = ((char)(j));
        }
        for(int m=0; m<26; m++)
        {
            int k = m;
            if(k < 25)
            System.out.print(ch[k] + ", ");
            else
            System.out.print(ch[k]);
        }
    }
}
