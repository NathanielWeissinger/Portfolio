import java.io.*;
import java.util.*;
public class Automobile
{
    public double mpg;
    public double gallons = 0;
    
    public Automobile(double mileage) //24
    {
        mpg = mileage;
    }
    
    public void fillUp(int f)
    {
        gallons += f;
    }
    
    public void takeTrip(int nm)
    {
        gallons -= nm / mpg;
    }
    
    public double reportFuel()
    {
        return gallons;
    }
}
