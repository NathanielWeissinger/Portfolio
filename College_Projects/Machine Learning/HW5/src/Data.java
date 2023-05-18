/**
 * @author Nathaniel Weissinger
 * This program does simple calculations after reading the input data
 * from a file. It can parse the data into its respective letters and
 * mu weights, and can calculate the mean, RMS, and use the RMS to
 * normalize the data.
 * 
 * Additionally, it can perform matrix calculations, such as transposition,
 * identity, inverse, multiplication, and even eigenvalue and eigenvector
 * calculations.
 * 
 * Lastly, this method performs covariance calculations based on a set of
 * input data, and is integral to the functionality of Project 2.
 */

import java.util.*;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import java.io.*;
import javax.imageio.*;
import java.lang.*;
import Jama.*;

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
    }
    
    public Data(int mu)
    {
        muNUM = mu;
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
        
        double data[][] = new double[muNUM][maxIndex-1];
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
        all_dat = data;
        return data;
    }
    
    public double[][] parseData(double[][] d, int c, int numLET)
    {
        //This method parses the data from an already parsed dataset d,
        //but returns only the c set of numLET values corresponding to the training data
        //c = class (0=a, 1=c, 2=e, 3-m, 4=n, 5=o, 6=r, 7=s, 8=x, 9=z)
        //numLET = number of values taken from set
        
        double data[][] = new double[d.length][numLET];
        
        for(int j = 0; j < numLET; j++)
        {
            for(int i = 0; i < d.length; i++)
            {
                data[i][j] = d[i][j+(10*c)];
                
                //vv Used for troubleshooting
                //System.out.print(""+data[i][j]+"  "+i+"  "+j + " ");
            }
            //System.out.print("\n");
        }
        //System.out.print("\n");
        return data;
    }
    
    public double[][] getDoubleMatrix(String[] text)
    {
        //This method reads the given text file and returns a double
        //matrix, assuming the text file only has doubles
        
        double data[][] = new double[maxIndex][muNUM];
        
        for(int i = 0; i < maxIndex; i++)
        {
            Scanner sc = new Scanner(text[i]);
            while(sc.hasNext())
            {
                for(int j = 0; j < muNUM; j++)
                {
                    data[i][j] = sc.nextDouble();
                    
                    //vv Used for troubleshooting
                    //System.out.println(""+data[i][j]+"  "+i+"  "+j);
                }
            }
        }
        return data;
    }
    
    public String[] parseLetters(String[] t)
    {
        //This method saves the letters corresponding to the input data
        
        double [][] data = new double[muNUM][maxIndex-1];
        int index = 0;
        String [] letData = new String[maxIndex-1];
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
        //Calculates the mean for each mu (after data has been transposed so that mu values are
        //displayed as rows)
        
        double m[] = new double[d.length];
        
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
    
    public double[][] covariance(double[][] d)
    {
        //Computes an 8x8 covariance matrix for an individual classes
        //Each data input letter has 8 mu rows and 10 or 20 class columns (transposed from original)
        //numLET indicates the number of data points per letter
        
        double mean[] = this.mean(d);
        int rows = d.length; //8 mu values
        int cols = d[0].length; //10 training data points, or 20 eval points per letter
        int n = cols; //number of class data points (10 training, 20 eval)
        double [][]diff = new double[rows][cols];
        double [][]cov = new double[rows][rows]; //8x8 matrix
        //Loop will subtract every point from the means
        for(int i = 0; i < rows; i++) //next data row (mu values)
        {
            for(int j = 0; j < cols; j++) //next data column (class data point)
            {
                //(x-mu)^2
                diff[i][j] = (d[i][j] - mean[i]);
                //System.out.println(diff[i][j]);
            }
        }
        
        //Creates covariance matrix for class
        for(int y = 0; y < rows; y++) //next covariance column (y mu values)
        {
            for(int x = 0; x < rows; x++) //next covariance row (x mu values)
            {
                cov[x][y] = 0;
                for(int i = 0; i < cols; i++) //next data column (class)
                {
                    //sum[ (xi - mu_x) * (yi - mu_y) ]
                    cov[x][y] += diff[x][i] * diff[y][i];
                }
                
                //Covariance divided by n-1
                cov[x][y] = cov[x][y]/(n-1);
                //System.out.print(""+cov[x][y]+" ");
            }
            //System.out.print("\n");
        }
        return cov;
    }
    
    public double[][] correlation(double[][] cov)
    {
        //Calculates correlation coefficients for all the classes based on the covariance matrix input
        
        int rows = cov.length; //number of rows (8 features)
        double [][]p = new double[rows][rows];
        for(int j=0; j<rows; j++)
        {
            for(int i=0; i<rows; i++)
            {
                //rho = sigma_xy / (sigma_x * sigma_y)
                p[i][j] = cov[i][j] / (Math.sqrt(cov[i][i]) * Math.sqrt(cov[j][j]));
                //System.out.print(""+p[i][j+(rows*c)]+" ");
            }
            //System.out.print("\n");
        }
        return p;
    }
    
    public double[] eigenvalues(double d[][])
    {
        //Returns n eigenvalues for an nxn matrix
        int rows = d.length;
        int cols = d[0].length;
        Matrix m = new Matrix(rows, cols);
        for(int j=0; j<cols; j++)
        {
            for(int i=0; i<rows; i++)
            {
                m.set(i,j,d[i][j]);
            }
        }
        EigenvalueDecomposition eigen = m.eig();
        double []ev = eigen.getRealEigenvalues();
        //double []im = eigen.getImagEigenvalues();
        return ev;
    }
    
    public double[][] eigenvectors(double d[][])
    {
        //Returns eigenvector matrix
        int rows = d.length;
        int cols = d[0].length;
        Matrix m = new Matrix(rows, cols);
        for(int j=0; j<cols; j++)
        {
            for(int i=0; i<rows; i++)
            {
                m.set(i,j,d[i][j]);
            }
        }
        EigenvalueDecomposition eigen = m.eig();
        Matrix e = eigen.getV();
        double [][]ev = new double[rows][cols];
        for(int j=0; j<cols; j++)
        {
            for(int i=0; i<rows; i++)
            {
                ev[i][j] = e.get(i,j);
            }
        }
        return ev;
    }
    
    public double[][] cofactor(double[][] d)
    {
        //Calculates cofactor of a square matrix
        //Copied from:
        //https://stackoverflow.com/questions/21153823/determining-cofactor-matrix-in-java
        double[][] result = new double[d.length][d[0].length];
        
        //checks to make sure matrix is square
        if(d.length == d[0].length)
        {
            for (int i = 0; i < result.length; i++)
            {
                for (int j = 0; j < result[i].length; j++)
                {
                    result[j][i] = (int)(Math.pow(-1, i + j) * this.determinant(removeRowCol(d, i, j)));
                }
            }
        }
        else
        {
            System.out.println("ERROR: Dimensions of matrix is not square");
        }
        return this.transpose(result);
    }

    public double[][] removeRowCol(double[][] d, int row, int col)
    {
        //Removes entire row and column from a matrix to produce another (r-1)x(c-1) matrix
        //Copied from:
        //https://stackoverflow.com/questions/21153823/determining-cofactor-matrix-in-java
        double[][] result = new double[d.length - 1][d[0].length - 1];
    
        int k = 0, l = 0;
        for (int i = 0; i < d.length; i++)
        {
            if (i == row)
            {
                continue;
            }
            for (int j = 0; j < d[i].length; j++)
            {
                if (j == col)
                {
                    continue;
                }
                result[l][k] = d[i][j];
    
                k = (k + 1) % (d.length - 1);
                if (k == 0)
                {
                    l++;
                }
            }
        }
    
        return result;
    }
    
    public double[][] identityMatrix(int n)
    {
        //Creates an identity matrix of nxn size
        double [][]id = new double[n][n];
        
        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < n; j++)
            {
                if(i==j)
                {
                    id[i][j] = 1;
                }
                else
                {
                    id[i][j] = 0;
                }
            }
        }
        return id;
    }
    
    public double[][] multiplyMatrix(double[][] A, double[][] B)
    {
        //Multiplies two matrices: one nxm, another mxn.
        //Copied from:
        //https://www.javatpoint.com/java-program-to-multiply-two-matrices
        
        Matrix Am = new Matrix(A, A.length, A[0].length);
        Matrix Bm = new Matrix(B, B.length, B[0].length);
        Matrix Cm = Am.times(Bm);
        double C[][] = Cm.getArray();
        
        return C;
    }
    
    public double[][] addMatrix(double[][] A, double[][] B)
    {
        //Multiplies two matrices: one nxm, another mxn.
        //Copied from:
        //https://www.javatpoint.com/java-program-to-multiply-two-matrices
        double C[][] = new double[A.length][A[0].length];
        
        //Checks to make sure dimensions are correct (Am=Bm, and An=Bn)
        if(A.length == B.length && A[0].length == B[0].length)
        {
            //multiplying and printing multiplication of 2 matrices    
            for(int i=0;i<A.length;i++)
            {    
                for(int j=0;j<A[0].length;j++)
                {  
                    C[i][j] = A[i][j]+B[i][j]; 
                    //Used for troubleshooting vv
                    //System.out.print(C[i][j]+" ");  //printing matrix element  
                }
                //System.out.println();//new line    
            }    
        }
        else
        {
            System.out.println("ERROR: Dimensions of matrices are incorrect");
        }
        return C;
    }
    
    public double[][] subtractMatrix(double[][] A, double[][] B)
    {
        //Multiplies two matrices: one nxm, another mxn.
        //Copied from:
        //https://www.javatpoint.com/java-program-to-multiply-two-matrices
        double C[][] = new double[A.length][A[0].length];
        
        //Checks to make sure dimensions are correct (Am=Bm, and An=Bn)
        if(A.length == B.length && A[0].length == B[0].length)
        {
            //multiplying and printing multiplication of 2 matrices    
            for(int i=0;i<A.length;i++)
            {    
                for(int j=0;j<A[0].length;j++)
                {  
                    C[i][j] = A[i][j]-B[i][j]; 
                    //Used for troubleshooting vv
                    //System.out.print(C[i][j]+" ");  //printing matrix element  
                }
                //System.out.println();//new line    
            }    
        }
        else
        {
            System.out.println("ERROR: Dimensions of matrices are incorrect");
        }
        return C;
    }
    
    public double[][] transpose(double[][] matrix)
    {
        //Transposes a matrix
        double[][] transposedMatrix = new double[matrix[0].length][matrix.length];
        for (int i=0;i<matrix.length;i++)
        {
            for (int j=0;j<matrix[i].length;j++)
            {
                transposedMatrix[j][i] = matrix[i][j];
            }
        }
        return transposedMatrix;
    }
    
    public double[][] scalarMultiplyMatrix(double[][] matrix, double k)
    {
        double[][] sM = new double[matrix.length][matrix[0].length];
        for (int i = 0; i < matrix.length; i++)
        {
            for (int j = 0; j < matrix[i].length; j++)
            {
                sM[i][j] = matrix[i][j] * k;
            }
        }
        return sM;
    }
    
    public double[][] expMatrix(double[][] matrix)
    {
        //Performs exp(matrix) to every element in the matrix
        double[][] sM = new double[matrix.length][matrix[0].length];
        for (int i = 0; i < matrix.length; i++)
        {
            for (int j = 0; j < matrix[i].length; j++)
            {
                sM[i][j] = Math.exp(matrix[i][j]);
            }
        }
        return sM;
    }
    
    public double[][] inverseMatrix(double[][] matrix)
    {
        //Calculates the inverse of a square matrix
        Matrix m = new Matrix(matrix, matrix.length, matrix[0].length);
        Matrix i = m.inverse();
        return i.getArray();
    }
    
    public static double determinant(double[][] matrix)
    {
        //Calulates determinant of an nxn matrix
        //Copied from:
        //https://gist.github.com/Cellane/398372/23a3e321daa52d4c6b68795aae093bf773ce2940
        
        double tempm[][];
        double result = 0;
        
        if(matrix.length == matrix[0].length)
        {
            if (matrix.length == 1)
            {
                result = matrix[0][0];
                return (result);
            }
        
            if (matrix.length == 2)
            {
                result = ((matrix[0][0] * matrix[1][1]) - (matrix[0][1] * matrix[1][0]));
                return (result);
            }
        
            for (int i = 0; i < matrix[0].length; i++)
            {
                tempm = new double[matrix.length - 1][matrix[0].length - 1];
                
                for (int j = 1; j < matrix.length; j++)
                {
                    for (int k = 0; k < matrix[0].length; k++)
                    {
                        if (k < i)
                        {
                            tempm[j - 1][k] = matrix[j][k];
                        }
                        else if (k > i)
                        {
                            tempm[j - 1][k - 1] = matrix[j][k];
                        }
                    }
                }
        
                result += matrix[0][i] * Math.pow (-1, (double) i) * determinant(tempm);
            }
        }
        else
        {
            System.out.println("Determinant cannot be calculated: Matrix is not nxn");
        }
        return (result);
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
