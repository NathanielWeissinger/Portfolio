import java.io.*;
import java.util.*;
import static java.lang.Math.*;
import static java.lang.System.out;
import java.util.Random.*;
public class Tester
{
    public static void main(String args[]) throws IOException
    {
        double r = 0;
        int count = 0;
        Random rndm = new Random();
        for(int j = 0; j<27; j++)
        {
            r = 99.78 + (47.44 * rndm.nextDouble());
            
            System.out.print(r + " ");
        }
    }
}
