import java.io.*;
import java.util.*;
public class Tester
{
    public static void main(String args[])
    {
        System.out.print("Enter an integer: ");
        Scanner wo = new Scanner(System.in);
        int woo = wo.nextInt();
        if (woo % 2 == 0)
        {
            System.out.println("The integer " + woo + " is even.");
        }
        else
        {
            System.out.println("The integer " + woo + " is odd.");
        }
    }
}
