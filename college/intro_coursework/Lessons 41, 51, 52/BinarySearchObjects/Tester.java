import java.io.*;
import java.util.*;
import static java.lang.Math.*;
import static java.lang.System.out;
import java.util.Random.*;
public class Tester
{
    public static void main(String args[])
    {
        int i[] = {-7, 15, 21, 22, 43, 49, 51, 67, 78, 81, 84, 89, 95, 97};
        Integer iw[] = new Integer[14];
        for(int k = 0; k < 14; k++)
        {
            iw[k] = new Integer(i[k]); //Java 5.0, iw[k] = ik];
        }
        System.out.println(binarySearch(iw, new Integer(22))); //3
        //Java 5.0, System.out.println(binarySearch(iw, 22));
        System.out.println(binarySearch(iw, new Integer(89))); //11
        System.out.println(binarySearch(iw, new Integer(-100))); //-1
        System.out.println(binarySearch(iw, new Integer(72))); //-1
        System.out.println(binarySearch(iw, new Integer(102))); //-1
    }
    private static int binarySearch(Integer b[], Integer srchVal)
    {
        int srchValue = srchVal;
        int a[] = new int[b.length];
        for(int k=0; k<b.length; k++)
        {
            a[k] = b[k];
        }
        int lb = 0;
        int ub = a.length - 1;
        while(lb <= ub)
        {
        int mid = (lb + ub)/2;
        if(a[mid] == srchVal)
        {
        return mid;
        }
        else if (srchVal > a[mid])
        {
        lb = mid + 1; //set a new lowerbound
        }
        else
        {
        ub = mid -1; //set a new upper bound
        }
        }
        return -1; //srchVal not found
    }
}