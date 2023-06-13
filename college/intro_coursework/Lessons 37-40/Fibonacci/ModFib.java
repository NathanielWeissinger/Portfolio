import java.io.*;
import java.util.*;
import static java.lang.Math.*;
import static java.lang.System.out;
import java.util.Random.*;
public class ModFib
{
    public static int modFibonacci(int n)
    {
        if(n==0)
        {
            return n+3;
        }
        else if(n==1)
        {
            return n+4;
        }
        else if(n==2)
        {
            return n+6;
        }
        else
        {
            return modFibonacci(n-1) + modFibonacci(n-2) + modFibonacci(n-3);
        }
    }
}