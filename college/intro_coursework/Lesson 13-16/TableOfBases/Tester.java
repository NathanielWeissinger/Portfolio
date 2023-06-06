import java.io.*;
import java.util.*;
public class Tester
{
    public static void main(String args[])
    {
        int j;
        for(j=65; j<=90; j++)
        {
            System.out.println(j + " " + (Integer.toString(j, 2)) + " " + (Integer.toString(j, 8)) + " " + (Integer.toString(j, 16)) + " " + ((char)(j)));
        }
    }
}