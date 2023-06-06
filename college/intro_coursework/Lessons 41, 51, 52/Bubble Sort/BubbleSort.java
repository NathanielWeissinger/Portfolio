import java.io.*;
import java.util.*;
import static java.lang.Math.*;
import static java.lang.System.out;
import java.util.Random.*;
public class BubbleSort
{
    public static void sort(int a[]) //Bubble Sort
    {
        boolean loopSomeMore;
        do
        {
            loopSomeMore = false;
        for(int j = 0; j < a.length -1; j++)
        {
            if(a[j] > a[j+1])
        {
            //swap a[j] and a[j+1]
            int temp = a[j];
            a[j] = a[j+1];
            a[j+1] = temp;
            loopSomeMore = true;
        }
        }
        }
        while(loopSomeMore);
    }
}