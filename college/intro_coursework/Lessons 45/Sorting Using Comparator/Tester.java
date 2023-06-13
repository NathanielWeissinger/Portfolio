import java.io.*;
import java.util.*;
import java.text.*; //for NumberFormat
public class Tester
{
    public static void main(String args[])
    {
        NumberFormat formatter = NumberFormat.getNumberInstance();
        formatter.setMinimumFractionDigits(2);
        formatter.setMaximumFractionDigits(2);
        String name;
        int j;
        BankAccount ba[] = new BankAccount[5]; //Create a BankAccount object array ba[ ], length 5
        Comparator comp = new BA_comparator();
        for(j =0; j < ba.length; j++)
        {
            Scanner kbReader = new Scanner(System.in);
            System.out.print("Please enter the name to whom the account belongs. ");
            name = kbReader.nextLine();
            System.out.print("Please enter the amount of the deposit. ");
            double amount = kbReader.nextDouble();
            System.out.println(""); //gives a blank line between accounts
            ba[j] = new BankAccount(name, amount); //Instantiate object ba[j] using name and amount
        }
        Arrays.sort(ba, comp); //Sort the ba array using the sort method in the Arrays class
        for(int k = 0; k < ba.length; k++)
        {
            System.out.println(ba[k].name + " >>> " + ba[k].balance); //Print the ordered array in this format
            //Harry Houdini >>> 298.44
        }
    }
}