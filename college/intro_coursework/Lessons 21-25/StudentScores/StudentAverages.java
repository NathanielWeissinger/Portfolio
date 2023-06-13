import java.io.*;
import java.util.*;
import static java.lang.Math.*;
import static java.lang.System.out;
public class StudentAverages
{
   public static void main(String args[]) throws IOException
   {
        Scanner file         = new Scanner(new File("F:/Nathaniel/GIGADRIVE/NathanielW/Lessons 21-25/StudentScores.txt"));
        int maxIndex = -1;
        String numInText[] =  new String[100];
        while(file.hasNext())
        {
           maxIndex++;
           numInText[maxIndex] = file.nextLine();
        }
           for(int j = 0; j<=maxIndex; j++)
           {
                 int sum         = 0;
                 Scanner txt     = new Scanner(numInText[j]);
                 String name     = txt.next();
                 int z           = 0;
                 while(txt.hasNextInt())
                 {
                     sum += txt.nextInt();
                     z = z+1;
                 }
           System.out.println(name + ", average = " + (int)(((double)sum/z) + 0.5));
        }
       file.close();
    }
}