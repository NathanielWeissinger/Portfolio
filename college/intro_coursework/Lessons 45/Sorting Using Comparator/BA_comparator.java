import java.util.*; //necessary for Comparator interface
public class BA_comparator implements Comparator
{
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