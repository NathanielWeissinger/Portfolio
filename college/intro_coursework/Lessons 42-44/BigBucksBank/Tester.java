import java.io.*;
import java.util.*; //includes ArrayList
import java.text.*; //for NumberFormat

public class Tester
{
    public static void main(String args[])
    {
        NumberFormat formatter = NumberFormat.getNumberInstance( );
        formatter.setMinimumFractionDigits(2);
        formatter.setMaximumFractionDigits(2);
        String name;
        String maxName = "bankrupt";
        double maxBalance = 0;
        ArrayList aryLst = new ArrayList( );
        do
        {
            Scanner kbReader = new Scanner(System.in);
            System.out.print("Please enter the name to whom the account belongs. (\"Exit\" to abort): ");
            name = kbReader.nextLine( );
            if( !name.equalsIgnoreCase("EXIT") )
            {
            System.out.print("Please enter the amount of the deposit: ");
            double amount = kbReader.nextDouble();
            System.out.println(" "); //gives an eye-pleasing blank line
            BankAccount theAccount = new BankAccount(name, amount);
            aryLst.add(theAccount);
            }
        }
        while(!name.equalsIgnoreCase("EXIT"));
        //Search aryList and print out the name and amount of the largest bank account
        for(int j = 0; j< aryLst.size(); j++)
        {
            BankAccount ba = (BankAccount)aryLst.get(j);
            if(ba.balance > maxBalance)
            {
                maxBalance = ba.balance;
                maxName = ba.name;
            }
        }
        System.out.println(""); //Prints answer
        System.out.println("The account with the largest balance belongs to: " + maxName + ".");
        System.out.println("The amount is $" + maxBalance + ".");
    }
}