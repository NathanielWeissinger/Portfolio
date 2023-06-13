import java.util.*;
import java.lang.*;
import java.io.*;

public class GridMonitor implements GridMonitorInterface
{
    private double solarArray[][];
    private String f;
    
    /**
     * Constructor method, which scans the specified file and saves the data into a 2D matrix
     * 
     * @constructor method
     */
    public GridMonitor(String filename) throws FileNotFoundException
    {
        f = filename;
        Scanner sc = new Scanner(new File(filename));
        int i = sc.nextInt();
        int j = sc.nextInt();
        solarArray = new double[i][j];
        for(int k=0; k<i; k++)
        {
            for(int l=0; l<j; l++)
            {
                solarArray[k][l] = sc.nextDouble();
            }
        }
    }
    
    /**
     * Displays all results of every method sequentially.
     * 
     * @displays results
     */
    public static void main(String args[])
    {
        try{
            String fn = "sample.txt";
            GridMonitor gm = new GridMonitor(fn);
            double[][] tempArray1 = gm.getBaseGrid();
            double[][] tempArray2 = gm.getSurroundingSumGrid();
            double[][] tempArray3 = gm.getSurroundingAvgGrid();
            double[][] tempArray4 = gm.getDeltaGrid();
            boolean[][] tempArray5 = gm.getDangerGrid();
            int i=tempArray1.length;
            int j=tempArray1[0].length;
            System.out.println(fn+"\n");
            System.out.print("Base: \n");
            for(int k=0; k<i; k++)
            {
                for(int l=0; l<j; l++)
                {
                    System.out.print(tempArray1[k][l] + " ");
                }
                System.out.print("\n");
            }
            System.out.print("Sum: \n");
            for(int k=0; k<i; k++)
            {
                for(int l=0; l<j; l++)
                {
                    System.out.print(tempArray2[k][l] + " ");
                }
                System.out.print("\n");
            }
            System.out.print("Average: \n");
            for(int k=0; k<i; k++)
            {
                for(int l=0; l<j; l++)
                {
                    System.out.print(tempArray3[k][l] + " ");
                }
                System.out.print("\n");
            }
            System.out.print("Delta: \n");
            for(int k=0; k<i; k++)
            {
                for(int l=0; l<j; l++)
                {
                    System.out.print(tempArray4[k][l] + " ");
                }
                System.out.print("\n");
            }
            System.out.print("Danger: \n");
            for(int k=0; k<i; k++)
            {
                for(int l=0; l<j; l++)
                {
                    System.out.print(tempArray5[k][l] + " ");
                }
                System.out.print("\n");
            }
        }catch(FileNotFoundException e){System.out.println("File Not Found");}
    }
    
    /**
     * Returns the original base grid, as read from file.
     * 
     * @return base grid
     */
    public double[][] getBaseGrid()
    {
        int i=solarArray.length;
        int j=solarArray[0].length;
        double[][] tempArray = new double[i][j];
        for(int k=0; k<i; k++)
        {
            for(int l=0; l<j; l++)
            {
                tempArray[k][l] = solarArray[k][l];
            }
        }
        return tempArray;
    }
    
    /**
     * Returns a grid with the same dimensions as the base grid, but each element
     * is the sum of the 4 surrounding base elements. For elements on a grid border,
     * the base element's own value is used when looking out of bounds, as if there
     * is a mirror surrounding the grid. This method is exposed for testing.
     * 
     * @return grid containing the sum of adjacent positions
     */
    public double[][] getSurroundingSumGrid()
    {
        int i=solarArray.length;
        int j=solarArray[0].length;
        double[][] tempArray = new double[i][j];
        for(int k=0; k<i; k++)
        {
            for(int l=0; l<j; l++)
            {
                tempArray[k][l]=0;
                if((k-1)>=0)//if there's an element to the left
                {
                    tempArray[k][l]+=solarArray[k-1][l];
                }
                else
                {
                    tempArray[k][l]+=solarArray[k][l];
                }
                
                if((k+1)<i)//if there's an element to the right
                {
                    tempArray[k][l]+=solarArray[k+1][l];
                }
                else
                {
                    tempArray[k][l]+=solarArray[k][l];
                }
                
                if((l-1)>=0)//if there's an element above
                {
                    tempArray[k][l]+=solarArray[k][l-1];
                }
                else
                {
                    tempArray[k][l]+=solarArray[k][l];
                }
                
                if((l+1)<j)//if there's an element below
                {
                    tempArray[k][l]+=solarArray[k][l+1];
                }
                else
                {
                    tempArray[k][l]+=solarArray[k][l];
                }
            }
        }
        return tempArray;
    }
    
    /**
     * Returns a grid with the same dimensions as the base grid, but each element
     * is the average of the 4 surrounding base elements. This method is exposed for 
     * testing.
     * 
     * @return grid containing the average of adjacent positions
     */
    public double[][] getSurroundingAvgGrid()
    {
        int i=solarArray.length;
        int j=solarArray[0].length;
        double[][] tempArray = getSurroundingSumGrid();
        for(int k=0; k<i; k++)
        {
            for(int l=0; l<j; l++)
            {
                tempArray[k][l] = tempArray[k][l]/4.0;
            }
        }
        return tempArray;
    }
    
    /**
     * Returns a grid with the same dimensions as the base grid, but each element 
     * is the maximum delta from the average. For example, if the surrounding
     * average at some coordinate is 2.0 and the maximum delta is 50% of the average,
     * the delta value at the same coordinate in this grid will be 1.0. This method is
     * exposed for testing.
     * 
     * @return grid containing the maximum delta from average of adjacent positions
     */
    public double[][] getDeltaGrid()
    {
        int i=solarArray.length;
        int j=solarArray[0].length;
        double[][] tempArray = getSurroundingAvgGrid();
        for(int k=0; k<i; k++)
        {
            for(int l=0; l<j; l++)
            {
                //Delta value must be an absolute value
                tempArray[k][l] = Math.abs(tempArray[k][l]/2.0);
            }
        }
        return tempArray;
    }
    
    /**
     * Returns a grid with the same dimensions as the base grid, but each element
     * is a boolean value indicating if the cell is at risk. For example, if the cell
     * at a coordinate is less than the surrounding average minus its maximum delta or
     * greater than the surrounding average plus its maximum delta, the corresponding
     * coordinate in this grid will be true. If the base cell value is within the safe
     * range, however, the corresponding value in this grid will be false.
     * 
     * @return grid containing boolean values indicating whether the cell at this
     * location is in danger of exploding
     */
    public boolean[][] getDangerGrid()
    {
        double[][] avgArray = getSurroundingAvgGrid();
        double[][] dArray = getDeltaGrid();
        int i=solarArray.length;
        int j=solarArray[0].length;
        boolean[][] bArray = new boolean[i][j];
        for(int k=0; k<i; k++)
        {
            for(int l=0; l<j; l++)
            {
                //if SolarValue is outside Average +/- DeltaValue range
                if(avgArray[k][l]+dArray[k][l]<solarArray[k][l] || avgArray[k][l]-dArray[k][l]>solarArray[k][l])
                {
                    bArray[k][l] = true;
                }
                else
                {
                    bArray[k][l] = false;
                }
            }
        }
        return bArray;
    }
    
    @Override
    public String toString()    //required implemented super method
    {
        try
        {
            Scanner sc = new Scanner(new File(f));
            String str = "";
            while(sc.hasNext())
            {
                str+=sc.next() + " ";
            }
            return str.toString();  //places entire file into a new String
        }
        catch(FileNotFoundException e)
        {
            return super.toString();
        }
    }
}
