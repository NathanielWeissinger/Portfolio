import java.io.*;
import java.util.*;
public class Circle
{
    public Circle(double r)
    {
        radius = r;
    }
    double radius;
    public double diameter()
    {
        double d = radius * 2;
        return d;
    }
}