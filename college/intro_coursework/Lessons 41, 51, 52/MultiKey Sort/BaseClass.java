import java.io.*;
import java.util.*;
import java.text.*;
import static java.lang.Math.*;
import static java.lang.System.out;
import java.util.Random.*;
public class BaseClass
{
    public static void main( String args[] ) throws IOException
    {
        Scanner sf = new Scanner(new File("c:\\temp_Name\\Names_ages.txt"));
        int maxIndx = -1; //-1 so when we increment below, the first index is 0
        String text[] = new String[100]; //To be safe, declare more than we need
        
        //String ages[] = new String[12];
        //StringTokenizer t[];
        while(sf.hasNext( ))
        {
            maxIndx++;
            text[maxIndx] = sf.nextLine( );
        }
        sf.close( );
        
        
        String names[] = new String[maxIndx];
        for(int OrginName = 0; OrginName < maxIndx; OrginName++) //Alphabetically
        {
            StringTokenizer t = new StringTokenizer(text[OrginName], " ");
            String x = t.nextToken();
            String y = t.nextToken();
            
            names[OrginName] = x + ", " + y;
        }
        Arrays.sort(names);
        
        String newnames[] = names;
        for(int q = 0; q<names.length; q++) //Analyzes Ages
        {
            StringTokenizer t = new StringTokenizer(text[q], " ");
            String x = t.nextToken();
            String y = t.nextToken();
            int y2 = Integer.parseInt(y);
            
            StringTokenizer u = new StringTokenizer(text[q+1], " ");
            String a = u.nextToken();
            String b = u.nextToken();
            int b2 = Integer.parseInt(b);
            
            if(x.equals(a))
            {
                if(y2 < b2)
                {
                    String temp = y;
                    y = b;
                    b = temp;
                    newnames[q] = x + ", " + y;
                    newnames[q+1] = a + ", " + b;
                    System.out.println(newnames[q]);
                }
                else if(y2 == b2)
                {
                    
                }
                else if(y2 > b2)
                {
                    
                }
            }
        }
        for(int count = 0; count<names.length; count++)
        {
            //System.out.println(newnames[count]);
        }
    }

        public static void sort(int a[])
        {
            MultiKeySort.sort(a);
        }
}