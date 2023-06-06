import java.io.*;
import java.util.*;
public class Tester
{
    public static void main(String args[])
    {
        Scanner integer = new Scanner(System.in);
        System.out.print("Please enter an integer: ");
        int input = integer.nextInt();
        do
        {
            double d = Math.sqrt(input);
            System.out.print(d);
            break;
        }
        while(input != 0);
    }
}