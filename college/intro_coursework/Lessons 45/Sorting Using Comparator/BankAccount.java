import java.util.*;
public class BankAccount implements Comparator
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
    
    public int compare(Object firstObject, Object secondObject)
    {
        BankAccount ba1 = (BankAccount) firstObject;
        BankAccount ba2 = (BankAccount) secondObject;
        int retValue;
        if (ba1.balance < ba2.balance)
        {
            retValue = -1;
        }
        else
        {
            if (ba1.balance > ba2.balance)
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