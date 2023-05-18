/**
 * @author Nathaniel Weissinger
 * This program formats the data, from converting data to Strings,
 * formatting the confusion matrix, and saving/outputting the data to the
 * console or to a file (labeled "output.txt").
 * 
 * The main method needs to be selected to run the program. The calculations within the
 * main method showcase many potential ways the input data can be parsed or organized
 * (for instance, a Data object can parse the training data by letter, saving only specific
 * training data letters into separate arrays, even though it is not used).
 * 
 * To begin, the input data from both the training and evaluation data are parsed
 * and put into arrays for processing. Then, the 8 RMS values for the training data
 * are calculated, then the data is normalized. 
 * 
 * Two weight matrices were imported from text files in order to run the neural network.
 * Only the first two data points of class 'a' were tested, and the corresponding data
 * was sent into the Neural Network class through its layer 1 summation and layer 2
 * activation function methods.
 * 
 * The Java console was then customized to display the outputs of the neural network.
 * 
 */

import java.util.*;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import java.io.*;
import javax.imageio.*;
import java.lang.*;
import Jama.*;

public class HW5
{
    static int muNUM;
    static int numLET; //training has 10, eval data has 20
    
    public static void main(String args[]) throws IOException
    {
        muNUM = 8; //8 = number of mu values
        //File name is inserted here vv
        Data data = new Data("traindat.txt", muNUM); 
        
        //saves data into text array
        String train_text[] = data.getText();
        //saves all values into double matrix
        double all_dat[][] = data.parseData(train_text);
        //saves all letters into a String matrix
        String train_let[] = data.parseLetters(train_text);
        
        numLET = 10; //10 = number of letter training points per class (changes depending on training or eval data)
        
        //The RMS value needs to be calculated using all of the compiled data:
        double all_RMS[] = data.RMS(all_dat);
        
        //Normalization divides all the data by the RMS values, each
        //corresponding to their proper mu row
        double all_norm[][] = data.normalize(all_dat, all_RMS);
        
        //This code obtains the data for each individual class out of all_norm:
        //classes (0=a, 1=c, 2=e, 3=m, 4=n, 5=o, 6=r, 7=s, 8=x, 9=z)
        double a_dat[][] = data.parseData(all_norm, 0, 2); //Obtains first two data points from class 'a'
        double zall_dat[][] = data.parseData(all_norm, 9, 10); //Obtains the 10 data points from class 'z'
        double z_dat[][] = new double[zall_dat.length][1];
        for(int i=0; i<zall_dat.length; i++)
        {
            z_dat[i][0] = zall_dat[i][9]; //Obtains z10 from data
        }
        
        //Imports weight matrices
        Data w1 = new Data("wji.txt", muNUM); 
        String w1_text[] = w1.getText();
        double wji[][] = w1.getDoubleMatrix(w1_text);
        
        Data w2 = new Data("wkj.txt", 4); //4 nodes
        String w2_text[] = w2.getText();
        double wkj[][] = w2.getDoubleMatrix(w2_text);
        
        //Create NeuralNetwork classifier object
        NeuralNetwork n = new NeuralNetwork();
        
        //Both a1 and a2 data points are able to be processed at the same time:
        double[][] netj_a = n.L1sum(a_dat, wji); //4x2 matrix output
        double[][] yj_a = n.L2activation(netj_a); //4x2
        double[][] netk_a = n.L1sum(yj_a, wkj); //10x2
        double[][] zk_a = n.L2activation(netk_a); //10x2
        
        //z10 processing:
        double[][] netj_z = n.L1sum(z_dat, wji); //4x1 matrix output
        double[][] yj_z = n.L2activation(netj_z); //4x1
        double[][] netk_z = n.L1sum(yj_z, wkj); //10x1
        double[][] zk_z = n.L2activation(netk_z); //10x1
        
        //Prints out data for a1 and a2
        for(int j=0; j<zk_a[0].length; j++) //loops through data points
        {
            System.out.print("a" + (j+1) + ": ");
            for(int i=0; i<zk_a.length; i++) //loops through nodes
            {
                System.out.print(zk_a[i][j] + " ");
            }
            System.out.print("\n");
        }
        String output = "a: "+dataToString(zk_a);
        
        System.out.print("z10" + ": ");
        for(int i=0; i<zk_z.length; i++) //loops through nodes
        {
            System.out.print(zk_z[i][0] + " ");
        }
        System.out.print("\n");
        output += "\nz: "+dataToString(zk_z);
        
        //Saves file to output.txt
        saveFile("output.txt", output);
    }
    
    public static void saveFile(String filename, String text)
    {
        //Saves a String (text) to a text file named (filename)
        //If file already exists, the previous one is overwritten
        try //Creates file
        {
            File name = new File(filename);
            if (name.createNewFile())
            {
                System.out.println("File created: " + name.getName());
            }
            else
            {
                System.out.println("File already exists.");
            }
        }
        catch (IOException e)
        {
            System.out.println("A file error occurred.");
            e.printStackTrace();
        }
        
        try //Writes to file
        {
            FileWriter fw = new FileWriter(filename);
            fw.write(text);
            fw.close();
            System.out.println("Successfully wrote to the file.");
        }
        catch (IOException e)
        {
            System.out.println("A writing error occurred.");
            e.printStackTrace();
        }
    }
    
    public static String dataToString(double data[][])
    {
        //Converts data matrix into one long String
        int rowsize = data.length;
        int colsize = data[0].length;
        String convS = "";
        
        for(int i=0; i<rowsize; i++)
        {
            for(int j=0; j<colsize; j++)
            {
                convS = convS + String.valueOf(data[i][j]) + "\t";
            }
            convS = convS + "\n";
        }
        return convS;
    }
    public static String dataToString(double data[])
    {
        //Converts data matrix into one long String
        //Same as previous method, but with single-dimension arrays
        int rowsize = data.length;

        String convS = "";
        
        for(int i=0; i<rowsize; i++)
        {
            convS = convS + String.valueOf(data[i]) + "\n";
        }
        return convS;
    }
    public static String stringMatrixToString(String str[])
    {
        //Converts data matrix into one long String
        //Same as previous method, but with single-dimension arrays
        int rowsize = str.length;

        String convS = "";
        
        for(int i=0; i<rowsize; i++)
        {
            convS = convS + str[i] + "\n";
        }
        return convS;
    }
    
    public static String confusionMatrix(String title, String results[], String eval[])
    {
        //Saves the input data into a matrix, determining which letters are classified
        //correctly and incorrectly. The data is then formatted so that it is
        //easily viewable via the Java console or via an output text file.
        String letters[] = {"a", "c", "e", "m", "n", "o", "r", "s", "x", "z"};
        int lets = letters.length;
        int rs = results.length;
        int es = eval.length; //rs and es should be the same length
        
        //RESULTS MATRIX (10x10):
        int resM [][] = new int[lets][lets];
        //Initialize array to have starting values of 0:
        for(int a=0; a<lets; a++)
        {
            for(int b=0; b<lets; b++)
            {
                resM[a][b] = 0;
            }
        }
        
        //Loops through each type of letter classification:
        for(int i=0; i<lets; i++)
        {
            for(int j=0; j<lets; j++)
            {
                //Loops through results:
                for(int k=0; k<rs; k++)
                {
                    //If the results match the row and the eval (correct answer) matches the column:
                    if( results[k].equals(letters[i]) && eval[k].equals(letters[j]) )
                    {
                        resM[j][i] += 1;
                    }
                }
            }
        }
        
        //Title
        String convS = "\t\t\t\t\t" + title + "\n\t\t\t\t\tDecision\n\t\t";
        
        //First row of letters
        for(int i=0; i<lets; i++)
        {
            convS = convS + letters[i] + "\t";
        }
        
        //Error checking and confusion matrix generation:
        convS += "error I";
        int errorI[] = new int[lets];
        int errorII[] = new int[lets];
        int sumE = 0; //sum of errorI
        for(int a=0; a<lets; a++)
        {
            convS = convS + "\n\t" + letters[a] + "\t";
            //initial value for row error I:
            errorI[a] = 0;
            for(int b=0; b<lets; b++)
            {
                if(resM[a][b] != 0 && a!=b)
                {
                    errorI[a] += resM[a][b];
                }
                
                convS = convS + resM[a][b] + "\t";
            }
            sumE += errorI[a];
            convS = convS + errorI[a];
        }
        
        //Last row: checking for errorII and summing errorI:
        convS = convS + "\n" + "error II:";
        for(int c=0; c<lets; c++)
        {
            
            errorII[c] = 0;
            for(int d=0; d<lets; d++)
            {
                errorII[c] += resM[d][c];
            }
            errorII[c] = errorII[c] - resM[c][c];
            convS = convS + "\t" + errorII[c];
        }
        
        convS = convS + "\t" + sumE; //errorII
        
        //RESULTS:
        double percentError = 100 * ((double)sumE/(double)(rs));
        double percentCorrect = 100-(double)percentError;
        convS = convS + "\n\n" + "Classification Results: " + percentCorrect + "% correct, and " + percentError + "% error\n";
        
        //Troubleshoot output vv
        System.out.println(convS);
        return convS;
    }
}
