public class LinearFunction implements LinearFunctionMethods
{
    public LinearFunction(double slope, double yIntc)
    {
        Slope = slope;
        yIntercept = yIntc;
    }
    public double getSlope()
    {
        return Slope;
    }
    public double getYintercept()
    {
        return yIntercept;
    }
    public double getRoot()
    {
        return -yIntercept/Slope;
    }
    public double getYvalue(double x)//return the y value corresponding to x
    {
        return Slope*x+yIntercept;
    }
    public double getXvalue(double y) //return the x value corresponding to y
    {
        return (y-yIntercept)/Slope;
    }
    public double Slope, yIntercept;
}