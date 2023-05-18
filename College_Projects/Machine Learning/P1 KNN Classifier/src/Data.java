
/**
 * @author Nathaniel Weissinger
 * This program does simple calculations after reading the input data
 * from a file. It can parse the data into its respective letters and
 * mu weights, and can calculate the mean, RMS, and use the RMS to
 * normalize the data.
 */

import java.util.*;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import java.io.*;
import javax.imageio.*;
import java.lang.*;

public class Data
{
    int muNUM;
    int maxIndex;
    String text[];
    double all_dat[][];
    public Data(String file, int mu)
    {
        muNUM = mu;
        try
        {
            text = readFile(file);
        }
        catch(IOException e){}
        all_dat = parseData(text);
    }
    
    public double[][] getParseData()
    {
        return all_dat;
    }
    
    public String[] getText()
    {
        return text;
    }
    
    public int getMaxIndex()
    {
        return maxIndex;
    }
    
    public double[][] parseData(String[] t, String letter, int let)
    {
        //This method searches the text file for a specific letter, then returns
        //the data points in a matrix. The number of rows of the specific letter
        //that this method records maxes out at the number specified by variable 'let'.
        
        //The data here is transposed, so that the columns
        //represent the mu values, and the rows are the training data weights
        double data[][] = new double[muNUM][let];
        int index = 0;
        
        //The for loop skips over the first line, which only has the
        //mu labels
        for(int j = 1; j < maxIndex; j++)
        {
            Scanner sc = new Scanner(t[j]);
            if(sc.next().equals(letter))
            {
                while(sc.hasNext())
                {
                    for(int i = 0; i < muNUM; i++)
                    {
                        data[i][index] = sc.nextDouble();
                        
                        //vv Used for troubleshooting
                        //System.out.println(""+data[i][index]+"  "+i+"  "+index);
                    }
                }
                index++;
            }
        }
        return data;
    }
    
    public double[][] parseData(String[] t)
    {
        //This method is a duplicate of the previous, but parses the entire
        //file instead of by separate letters
        
        double data[][] = new double[muNUM][maxIndex];
        int index = 0;
        
        //The for loop skips over the first line, which only has the
        //mu labels
        for(int j = 1; j < maxIndex; j++)
        {
            Scanner sc = new Scanner(t[j]);
            sc.next();
            while(sc.hasNext())
            {
                for(int i = 0; i < muNUM; i++)
                {
                    data[i][index] = sc.nextDouble();
                    
                    //vv Used for troubleshooting
                    //System.out.println(""+data[i][index]+"  "+i+"  "+index);
                }
            }
            index++;
        }
        return data;
    }
    
    public String[] parseLetters(String[] t)
    {
        //This method saves the letters corresponding to the input data
        
        double [][] data = new double[muNUM][maxIndex];
        int index = 0;
        String [] letData = new String[maxIndex];
        //The for loop skips over the first line, which only has the
        //mu labels
        for(int j = 1; j < maxIndex; j++)
        {
            Scanner sc = new Scanner(t[j]);
            letData[j-1] = sc.next();
            
            while(sc.hasNext())
            {
                for(int i = 0; i < muNUM; i++)
                {
                    data[i][index] = sc.nextDouble();
                    
                    //vv Used for troubleshooting
                    //System.out.println(""+data[i][index]+"  "+i+"  "+index);
                }
            }
            index++;
        }
        return letData;
    }
    
    public String[] readFile(String s) throws IOException
    {
        //Reads the text file, and separates each line of text into an array
        maxIndex = 0;
        String text[] = new String[1000];
        try
        {
            Scanner sf = new Scanner(new File(s));
            while(sf.hasNext())
            {
                text[maxIndex] = sf.nextLine();
                maxIndex++;
            }
            sf.close();
        }
        catch (IOException e)
        {
            System.out.println("Could not read file.");
        }
        return text;
    }
    
    public double[] mean(double d[][])
    {
        //Calculates the mean for each mu
        
        double m[] = new double[muNUM];
        
        //d.length = muNUM = 8
        //d[i].length = numLETTERS = 10
        for(int i = 0; i < d.length; i++)
        {
            //initial value
            m[i] = 0;
            for(int j = 0; j < d[i].length; j++)
            {
                //Adds every data point
                m[i] += d[i][j];
            }
            //Divides sum by the number of data points
            m[i] = m[i]/d[i].length;
            
            //vv Used for troubleshooting
            //System.out.println(""+m[i]+"  "+i);
        }
        return m;
    }
    
    public double[] RMS(double d[][])
    {
        //Calculates the RMS value for each mu
        
        int N = maxIndex-1; //All the data, minus the first line (100)
        double rms[] = new double[muNUM];
        
        //d.length = muNUM = 8
        //d[i].length = numLETTERS = 10
        for(int i = 0; i < d.length; i++)
        {
            //initial value
            rms[i] = 0;
            for(int j = 0; j < d[i].length; j++)
            {
                //Adds the square of each data point
                rms[i] += Math.pow(d[i][j], 2);
            }
            //Square roots the sum of the squared data points and divides
            //it by the total number of data points
            rms[i] = Math.sqrt(rms[i]/N);
            
            //vv Used for troubleshooting
            //System.out.println(""+rms[i]+"  "+i);
        }
        return rms;
    }
    
    public double[][] normalize(double d[][], double rms[])
    {
        //Normalizes the data by dividing the means of each mu
        //by the RMS values of each mu
        double [][]norm = new double[muNUM][d[0].length];
        
        //d.length = muNUM = 8
        //d[i].length = numLETTERS = 10
        for(int i = 0; i < d.length; i++)
        {
            //Normalizes the means
            //norm[i] = d[i]/rms[i];
            for(int j = 0; j < d[i].length; j++)
            {
                
                //Normalizes every data point (add extra [] in front of
                //d and double in method label, as well as in norm
                norm[i][j] = d[i][j]/rms[i];
            }
            
            //vv Used for troubleshooting
            //System.out.println(""+norm[i]+"  "+i);
        }
        return norm;
    }
}
