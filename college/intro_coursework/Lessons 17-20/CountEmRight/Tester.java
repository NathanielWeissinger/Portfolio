import java.io.*;
import java.util.*;
public class Tester
{
    public static void main(String args[])
    {
        Scanner s = new Scanner(System.in);
        while(true)
        {
            System.out.print("Type a sentence and press ENTER. ");
            String input = s.nextLine().toUpperCase();
            input = input + "X";
            String sp[] = input.split("S\\s*A");
            int r = sp.length -1;
            System.out.println("There are " + r + " occurrences.");
        if(input.equals("EXITX"))
        {
            break;
        }
    }
}
}
        
