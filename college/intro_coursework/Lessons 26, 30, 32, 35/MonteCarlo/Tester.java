import java.io.*;
import java.util.*;
import static java.lang.Math.*;
import static java.lang.System.out;
import java.util.Random.*;
public class Tester
{
    public static void main(String args[])
    {
        int sqrCount = 0;
        int cirCount = 0;
        int r = 2;
        int a = 5;
        int b = 3;
        MonteCarlo mcObj= new MonteCarlo(a, b, r);
        for(int j = 0; j<10000; j++)
        {
            double h = mcObj.nextRainDrop_x();
            double k = mcObj.nextRainDrop_y();            
            if(mcObj.insideCircle(h, k))
            {
                cirCount++;
            }
            System.out.println((cirCount*h*k)/(sqrCount*r*r));
            sqrCount++;
        }
    }
}
        