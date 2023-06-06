               import  java.util.*;
    public     class   MonteCarlo
{
    private    double  h;
    private    double  k;
    private    double  r;
    private Random random = new Random();
    
    public            MonteCarlo(double h, double k, double r)
    {
        this.h = h;
        this.k = k;
        this.r = r;
    }
    
    public     double  nextRainDrop_x()
    {
        return random.nextDouble()*2*h;
    }
    
    public     double  nextRainDrop_y()
    {
        return random.nextDouble()*2*k;
    }
    
    public     boolean insideCircle(double x, double y)
    {
        return   (Math.pow(x-h, 2)+Math.pow(y-k, 2)) <= Math.pow(r, 2);
    }
}