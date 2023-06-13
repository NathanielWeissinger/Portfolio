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
        ArrayList <BankAccount> aryLst = new ArrayList();
        ListIterator iter = aryLst.listIterator();
        BankAccount d = new BankAccount("default", 0);
        iter.add(d);
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
            iter.add(theAccount);
            }
        }
        while(!name.equalsIgnoreCase("EXIT"));
        BankAccount ba = (BankAccount)iter.previous();
        String maxName = ba.name;
        double maxBalance = ba.balance;
        for(iter.previous(); iter.hasPrevious(); iter.previous())
        {
            BankAccount g= (BankAccount)iter.previous();
            if(g.balance > maxBalance)
            {
                maxBalance = g.balance;
                maxName = g.name;
            }
            iter.previous();
        }
        System.out.println(""); //Prints answer
        System.out.println("The account with the largest balance belongs to: " + maxName + ".");
        System.out.println("The amount is $" + maxBalance + ".");
    }
}