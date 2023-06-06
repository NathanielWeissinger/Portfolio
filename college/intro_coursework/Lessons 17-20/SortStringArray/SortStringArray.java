import java.io.*;
import java.util.*;
public class SortStringArray
{
    public static void main(String args[])
    {
        String name[] = {"Agnes","Alfred","Alvin","Bernard","Bill","Ezra","Herman","Lee","Mary","Thomas"};
        Arrays.sort(name);
        for(int j=0; j<name.length; j++)
        {
            System.out.println(name[j]);
        }
    }
}
