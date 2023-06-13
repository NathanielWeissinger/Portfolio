import java.io.*;
import java.util.*;
public class AscendDescend
{
    public static void main(String args[])
    {
        System.out.println("Ascend\tDescend\n");
        String name[] = {"Agnes","Alfred","Alvin","Bernard","Bill","Ezra","Herman","Lee","Mary","Thomas"};
        Arrays.sort(name);
        for(int j=0, k=9; j<name.length; j++, k--)
        {
            System.out.println(name[j] + "\t" + name[k]);
        }
    }
}
