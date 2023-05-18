
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
 * are calculated, then the data is normalized. The program then sends the data to the KNN
 * class, where it calculates the Euclidean distance between each data points' mu weights.
 * Then, the nearest neighbors are calculated, and the resulting classified letter is
 * returned.
 * 
 * The confusionMatrix method then converts the letters and data into a matrix string, which
 * outputs the correctly classified letters, the misidentified letters, and the error
 * percentage of the classification.
 */

import java.util.*;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import java.io.*;
import javax.imageio.*;
import java.lang.*;

public class PJ1
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
        
        
        numLET = 10; //10 = number of letter rows
        
        //Each of these arrays contains the rows (mu) and the training data
        //(10 columns of weights), making 8x10 arrays.
        //These arrays are not needed for calculation; however,
        //they do showcase what training data points are which
        //letters, and can be used for troubleshooting:
        double a_dat[][] = data.parseData(train_text, "a", numLET);
        double c_dat[][] = data.parseData(train_text, "c", numLET);
        double e_dat[][] = data.parseData(train_text, "e", numLET);
        double m_dat[][] = data.parseData(train_text, "m", numLET);
        double n_dat[][] = data.parseData(train_text, "n", numLET);
        double o_dat[][] = data.parseData(train_text, "o", numLET);
        double r_dat[][] = data.parseData(train_text, "r", numLET);
        double s_dat[][] = data.parseData(train_text, "s", numLET);
        double x_dat[][] = data.parseData(train_text, "x", numLET);
        double z_dat[][] = data.parseData(train_text, "z", numLET);
        
        //The RMS value needs to be calculated using all of the compiled data:
        double all_RMS[] = data.RMS(all_dat);
        
        //Normalization divides all the data by the RMS values, each
        //corresponding to their proper mu row
        double all_norm[][] = data.normalize(all_dat, all_RMS);
        
        //Read in eval1 data
        Data eval1 = new Data("eval1dat.txt", muNUM);
        String eval1_text[] = eval1.getText();
        double eval1_dat[][] = eval1.parseData(eval1_text);
        
        numLET = 20; //not used unless parsing is needed
        String eval1_let[] = eval1.parseLetters(eval1_text);
        
        //normalizes eval data using training data RMS
        double eval1_norm[][] = eval1.normalize(eval1_dat, all_RMS);
        
        //Create KNN object and run algorithm to determine nearest neighbors
        KNN k1 = new KNN();
        double k1_dist[][] = k1.Euclidean(all_norm, eval1_norm);
        String k1_nn1[] = k1.euclid_NN1(train_let, all_norm, eval1_norm);
        String k1_nn3[] = k1.euclid_NN3(train_let, all_norm, eval1_norm);
        String k1_nn5[] = k1.euclid_NN5(train_let, all_norm, eval1_norm);
        //Used for troubleshooting results vv
        /*for(int i=0; i<k1_nn1.length; i++)
        {
            System.out.println(k1_nn1[i]);
        }*/
        
        //Read in eval2 data
        Data eval2 = new Data("eval2dat.txt", muNUM);
        
        String eval2_text[] = eval2.getText();
        double eval2_dat[][] = eval2.parseData(eval2_text);
        
        numLET = 10; //not used unless parsing is needed
        String eval2_let[] = eval2.parseLetters(eval2_text);
        
        double eval2_RMS[] = eval2.RMS(eval2_dat);
        double eval2_norm[][] = eval2.normalize(eval2_dat, eval2_RMS);
        
        KNN k2 = new KNN();
        String k2_nn1[] = k2.euclid_NN1(train_let, all_norm, eval2_norm);
        String k2_nn3[] = k2.euclid_NN3(train_let, all_norm, eval2_norm);
        String k2_nn5[] = k2.euclid_NN5(train_let, all_norm, eval2_norm);
        
        //Converts double values to one String (used for matrix troubleshooting)
        //String output = dataToString(all_norm);
        //Converts String matrix to one long String with paragraph breaks
        //String output = stringMatrixToString(k1_nn1);
        
        String output = confusionMatrix("KNN1: eval1", k1_nn1, eval1_let)
                        + confusionMatrix("KNN1: eval2", k2_nn1, eval2_let)
                        + confusionMatrix("KNN3: eval1", k1_nn3, eval1_let)
                        + confusionMatrix("KNN3: eval2", k2_nn3, eval2_let)
                        + confusionMatrix("KNN5: eval1", k1_nn5, eval1_let)
                        + confusionMatrix("KNN5: eval2", k2_nn5, eval2_let);
        
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
                for(int k=0; k<rs-1; k++)
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
        double percentError = 100 * ((double)sumE/(double)(rs-1));
        double percentCorrect = 100-(double)percentError;
        convS = convS + "\n\n" + "Classification Results: " + percentCorrect + "% correct, and " + percentError + "% error\n";
        
        //Troubleshoot output vv
        System.out.println(convS);
        return convS;
    }
}
