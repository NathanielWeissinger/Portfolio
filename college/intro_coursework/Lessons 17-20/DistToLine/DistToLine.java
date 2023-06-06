import java.io.*;
import java.util.*;
import static java.lang.Math.*;
import static java.lang.System.out;
public class DistToLine
{
    static double A, B, C, a, b;
    public static double getDist()
    {
        double result = (Math.abs((A * a) + (B * b) + C)/(Math.sqrt(Math.pow(A, 2) + Math.pow(B, 2))));
        Scanner values = new Scanner(System.in);
        System.out.print("Enter the A value for the line: ");
        A = values.nextInt();
        System.out.print("Enter the B value for the line: ");
        B = values.nextInt();
        System.out.print("Enter the C value for the line: ");
        C = values.nextInt();
        System.out.print("Enter the x coordinate of the point: ");
        a = values.nextInt();
        System.out.print("Enter the y coordinate of the point: ");
        b = values.nextInt();
        System.out.print("Distance from the point to the line is: " + result + "\n");
        return (Math.abs((A * a) + (B * b) + C)/(Math.sqrt(Math.pow(A, 2) + Math.pow(B, 2))));
    }
}
