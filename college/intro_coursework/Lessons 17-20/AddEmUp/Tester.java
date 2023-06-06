import java.io.*;
import java.util.*;
public class Tester
{
    public static void main(String args[])
    {
        Scanner sc = new Scanner(System.in);
        System.out.print("Enter something like 8 + 33 + 1,345 + 137 : ");
        String s = sc.nextLine();
        Scanner sc1 = new Scanner(s);
        sc1.useDelimiter("\\s*\\+\\s*"); //look in book
        int sum = 0;
        while(sc1.hasNext())
        {
            Scanner m = new Scanner(sc1.next());
            m.useDelimiter("\\s*\\-\\s*");
            sum = sum + m.nextInt();
            while(m.hasNext())
            {
                sum = sum - m.nextInt();
            }
        }
        System.out.println("Sum is: " + sum);
    }
}
