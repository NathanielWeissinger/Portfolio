import java.io.*;
import java.util.*;
import static java.lang.Math.*;
import static java.lang.System.out;
import java.util.Random.*;
public class Tester
{
    public static void main(String args[]) throws IOException
    {
        int r = 0;
        int count = 0;
        Random rndm = new Random();
        for(int j = 0; j<33; j++)
        {
            r = 71 + rndm.nextInt(29);
            System.out.print(r + " ");
            count++;
            if(count>15)
            {
                System.out.println(" ");
                count = 0;
            }
        }
    }
}
