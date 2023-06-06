import java.io.*;
import java.util.*;
import static java.lang.Math.*;
import static java.lang.System.out;
import java.util.Random.*;
public class Tester
{
    public static void main(String args[]) throws IOException
    {
        int a[][] = { {1,2,-2,0}, {-3,4,7,2}, {6,0,3,1} };
        int b[][] = { {-1,3}, {0,9}, {1,-11}, {4,-5} };
        int sum = 0;
        for(int j = 0; j<3/*a.length*/; j++) //3 rows it goes down *******
        {
            for(int k = 0; k<2/*b[0].length*/; k++) //for the column (2)
            {
                    for(int l = 0; l<4/*a[0].length*/; l++) //for each column (4 #s)
                    {
                        int x = a[j][l] * b[l][k];
                        sum = sum + x;
                    }
                    System.out.print(sum + "\t");
                    sum = 0;
            }
            System.out.print("\n");
        }
    }
}