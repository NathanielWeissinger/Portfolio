import java.io.*;
import java.util.*;
import static java.lang.Math.*;
import static java.lang.System.out;
import java.util.Random.*;
public class Tester
{
    public static void main(String args[]) throws IOException
    {
        Scanner input = new Scanner(System.in);
        boolean tf = false;
        while(tf = false)
        {
            System.out.println("Input file name: ");
            String inputfilename = input.next();
        try
        {
            FileInput.readTheFile(inputfilename);
        }
        catch(IOException e)
        {
            System.out.println("Incorrect file name. Try again.");
            break;
        }
        finally
        {
            System.out.println("It worked.");
            tf = true;
        }
    }
}
}

