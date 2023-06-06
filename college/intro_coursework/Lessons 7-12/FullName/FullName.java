import java.io.*;
import java.util.*;
public class FullName
{
    public static void main(String args[])
    {
        Scanner name = new Scanner(System.in);
        System.out.print("What is your first name? ");
        String first_name = name.next();
        System.out.print("What is your last name? ");
        String last_name = name.next();
        System.out.println("Your full name is " + first_name + " " + last_name + ".");
    }
}