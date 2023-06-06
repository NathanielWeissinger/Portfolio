import java.io.*;
import java.util.*;
import static java.lang.Math.*;
import static java.lang.System.out;
public class Tester
{
    public static void main(String args[])
    {
        Scanner prompt = new Scanner(System.in);
        
        System.out.print("Enter next sentence: ");
        
        String          sentence  = prompt.nextLine().toLowerCase();
        StringTokenizer tokenizer = new StringTokenizer(sentence);
        int             numTokens = tokenizer.countTokens();
        String[]        illegals  = {"hermes", "bridge", "muddy", "river", "assault", "offensive"};
        boolean         valid     = true;
        
        for ( int i = 0; i < numTokens; ++i )
        {
            String token = tokenizer.nextToken(" .,\n");
            
            for ( String illegal : illegals )
            {
                if ( token.equals(illegal) )
                {
                    valid = false;
                    break;
                }
            }

            if ( ! valid ) break;
        }
        
        System.out.println(">>>" + (valid ? "OKAY" : "REJECTED"));
    }
}