import java.io.*;
import java.util.*;
public class NameRev
{
    public static void main(String args[])
    {
        Scanner n = new Scanner(System.in);
        System.out.print("Please enter your name here: "); //Nathaniel Weissinger
        String Rname = n.nextLine();
        String name = Rname.toLowerCase();
        int namelg = name.length();
        int L;
        for(L = namelg; L > 0; L--)//for loop charAt() method
        {
            char letter = name.charAt(L - 1);
            System.out.print(letter);
        }
        System.out.print("\n");
    }
}