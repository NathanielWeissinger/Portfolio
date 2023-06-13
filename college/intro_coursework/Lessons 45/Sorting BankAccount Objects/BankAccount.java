import java.util.*;
public class BankAccount implements Comparable
{
    public BankAccount(String nm, double amt)
    {
        name = nm;
        balance = amt;
    }
    public void deposit(double dp)
    {
        balance = balance + dp;
    }
    public void withdraw(double wd)
    {
        balance = balance - wd;
    }
    public String name;
    public double balance;
    
    public int compareTo(Object obj)
    {
        BankAccount ba = (BankAccount) obj;
        int retValue;
        if (name.compareTo(ba.name)<0)//balance < ba.balance)
        {
            retValue = -1;
        }
        else
        {
            if (name.compareTo(ba.name)<0)//balance > ba.balance)
            {
                retValue = 1;
            }
            else
            {
                retValue = 0;
            }
        }
        return retValue;
    }
}