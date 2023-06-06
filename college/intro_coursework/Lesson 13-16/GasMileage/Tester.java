import java.io.*;
import java.util.*;
public class Tester
{
    public static void main(String args[])
    {
        Automobile myBMW = new Automobile(24);
        myBMW.fillUp(20);
        myBMW.takeTrip(100);
        double fuel_left = myBMW.reportFuel();
        System.out.println(fuel_left);
    }
}
//no methods