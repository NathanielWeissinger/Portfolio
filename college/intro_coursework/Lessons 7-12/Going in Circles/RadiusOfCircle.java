import java.io.*;
import java.util.*;
public class RadiusOfCircle
{
    public static void main(String args[])
    {
        Scanner area = new Scanner(System.in);
        System.out.print("What is the area? ");
        double num = area.nextDouble();
        double r = Math.sqrt(num/(Math.PI));
        System.out.println("Radius of your circle is " + r);
    }
}