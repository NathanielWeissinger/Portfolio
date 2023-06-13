import java.io.*;
import java.util.*;
public class Tester
{
    public static void main(String args[])
    {
        BankAccount myAccount = new BankAccount(1000, "Sally Jones");
        Scanner amount = new Scanner(System.in);
        System.out.print("Deposit: ");
        double d = amount.nextInt();
        System.out.print("Withdraw: ");
        double w = amount.nextInt();
        myAccount.deposit(d);
        myAccount.withdraw(w);
        System.out.println("The Sally Jones account is $" + myAccount.balance);
    }
}