import java.io.*;
import java.util.*;
public class Tester
{
    public static void main(String args[])
    {
        System.out.print("Enter your password: ");
        Scanner pass = new Scanner(System.in);
        String P = pass.next();
        if (P.equals("XRay"))
        {
            System.out.println("Password entered successfully.");
        }
        else
        {
            System.out.println("Incorrect password.");
        }
            
    }
}