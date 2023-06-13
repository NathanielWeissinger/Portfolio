import java.io.*;
import java.util.*;
import static java.lang.Math.*;
import static java.lang.System.out;
    public class FileNerd
{
        public static void main(String args[]) throws IOException
    {
        Scanner sf = new Scanner(new File("C:\\temp_Name\\NumData.txt"));
        int maxIndx = -1;
        String text[] = new String[100];
            while(sf.hasNext())
        {
            maxIndx++;
            text[maxIndx] = sf.nextLine();
        }
           String answer = "";
           int sum;
                for(int j = 0; j <= maxIndx; j++)
           {
               Scanner sc = new Scanner(text[j]);
               sum = 0;
               answer = "";
               int c;
               while(sc.hasNext())
               {
                   int i = sc.nextInt();
                   StringTokenizer z = new StringTokenizer(text[j], " ");
                   int e = 0;
                   while(e<1)
                   {
                   answer = answer + i;
                   e++;
                   }
                   answer = answer + " + " + i;
                   sum += i;
               }
               answer += " = " + sum;
               System.out.println(answer);
           }
        sf.close();
    }
}
