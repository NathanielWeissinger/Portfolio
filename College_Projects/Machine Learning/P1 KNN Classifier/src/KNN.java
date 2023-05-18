
/**
 * @author Nathaniel Weissinger
 * This program uses the Euclidean algorithm:
 * sqrt( (xa-xb)^2+(ya-yb)^2+ . . . +(za-zb)^2 )
 * to calculate the distances between the evaluation and training data
 * using the mu weights.
 * 
 * Once the distances are calculated, the distances are recorded in an array
 * of indices, and depending on which Nearest Neighbor (NN) algorithm is chosen,
 * the shortest distances are selected, and the letter weighing closest to the
 * training data is returned.
 * 
 * Although the distance and NN algorithm likely should have been kept separate,
 * I chose to keep them together in order to save on processing time. If I put
 * them into separate methods, there would have had to have been additional
 * for loops, which would have taken up more processing power than needed.
 * I opted for efficiency, although this algorithm can hardly be considered
 * efficient.
 */

import java.util.*;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import java.io.*;
import javax.imageio.*;
import java.lang.*;

public class KNN
{    
    public double[][] Euclidean(double [][] train, double [][] eval)
    {
        //Uses Euclidean distance algorithm to determine distance measurements
        //between every combination of points
        int etrow = eval.length;
        int ecol = eval[0].length;
        //int trow = train.length;  //same length as erow
        int tcol = train[0].length;
        //dist = distance between training letter for each eval point
        double [][] dist = new double[ecol][tcol];
        
        //Loops through ecols first (eval letter)
        for(int j=0; j<ecol; j++)
        {
            //Loops through tcols second (training letter)
            for(int l=0; l<tcol; l++)
            {
                //Loops through etrows third (erow=trow length, so value is combined into etrow)
                for(int i=0; i<etrow; i++)
                {
                    //Both eval and training mu values must be subtracted to obtain distance measurements
                    //Both data values loop through the mu values in sequence with each other
                    
                    //j = eval point, l = distance calculation index
                    dist[j][l] += Math.pow( eval[i][j] - train[i][l], 2 );
                }
                //MOVE THIS BOTTOM SECTION OUT OF FOR LOOP TO NEXT ONE?
                //Take the distance measurement and sqrt it
                dist[j][l] = Math.sqrt( dist[j][l] );
            }
        }
        return dist;
    }
    
    public String[] euclid_NN1(String [] train_let, double [][] train, double [][] eval)
    {
        //Same as the previous method (Euclidean), however it performs both the distance
        //and NN algorithm at the same time to improve processing speed
        //Once the algorithm determines the 100 distances, it simply determines which
        //distance is the smallest, then returns the letter classification.
        int etrow = eval.length;
        int ecol = eval[0].length;
        //int trow = train.length;  //same length as erow
        int tcol = train[0].length;
        //dist = distance between training letter for each eval point
        double [] dist = new double[ecol];
        
        String [] evalClassifier = new String[ecol];
        
        int index;
        //Loops through ecols first (eval letter)
        for(int j=0; j<ecol; j++)
        {
            //initial index values
            index = 0;
            //Loops through tcols second (training letter)
            for(int l=0; l<tcol; l++)
            {
                //Loops through etrows third (erow=trow length, so value is combined into etrow)
                for(int i=0; i<etrow; i++)
                {
                    //Both eval and training mu values must be subtracted to obtain distance measurements
                    //Both data values loop through the mu values in sequence with each other
                    
                    //sqrt((xa-xb)^2 + (ya-yb)^2 + (za-zb)^2 + ...
                    //where separate variables x, y, etc. are the mu labels
                    
                    dist[l] += Math.pow( eval[i][j] - train[i][l], 2 );
                }
                //Take the distance measurement and sqrt it
                dist[l] = Math.sqrt( dist[l] );
                
                //Checks for smallest distance measurements
                if(dist[l] <= dist[ index ])
                {
                    index = l; //saves training column index
                }
            }
            //CLASSIFIER: Saves the letter of the classifier corresponding to the index of the training
            //data letter
            evalClassifier[j] = train_let[index];
            //Used for troubleshooting vv
            System.out.println(evalClassifier[j]);
        }
        return evalClassifier;
    }
    
    public String[] euclid_NN3(String [] train_let, double [][] train, double [][] eval)
    {
        //Performs both distance (Euclidean) and NN3 algorithms
        //Once the algorithm determines the 100 distances, it calculates and saves the indices
        //of the 3 smallest. Those 3 are then analyzed for which combinations of indices are
        //most similar or smallest, and the answers are then voted upon to determine the class.
        int etrow = eval.length;
        int ecol = eval[0].length;
        //int trow = train.length;  //same length as erow
        int tcol = train[0].length;
        //dist = distance between training letter for each eval point
        double [] dist = new double[ecol];
        
        String [] evalClassifier = new String[ecol];
        
        int index[] = new int[3];
        //Loops through ecols first (eval letter)
        for(int j=0; j<ecol; j++)
        {
            //initial index values
            index[0] = 0;
            index[1] = 0;
            index[2] = 0;
            //Loops through tcols second (training letter)
            for(int l=0; l<tcol-1; l++)
            {
                //Loops through etrows third (erow=trow length, so value is combined into etrow)
                for(int i=0; i<etrow; i++)
                {
                    //Both eval and training mu values must be subtracted to obtain distance measurements
                    //Both data values loop through the mu values in sequence with each other
                    
                    //sqrt((xa-xb)^2 + (ya-yb)^2 + (za-zb)^2 + ...
                    //where separate variables x, y, etc. are the mu labels
                    
                    dist[l] += Math.pow( eval[i][j] - train[i][l], 2 );
                }
                //Take the distance measurement and sqrt it
                dist[l] = Math.sqrt( dist[l] );
                
                //Saves first two measurements
                if(l==0)
                    index[0] = l;
                else if(l==1 && dist[ index[0] ] <= dist[ l ])
                    index[1] = l;
                else if(l==1 && dist[ l ] <= dist[ index[0] ])
                {
                    index[1] = index[0];
                    index[0] = l;
                } //For all recurring measurements after the first two, it saves the smallest:
                else if(l>1 && dist[ index[1] ] <= dist[ l ])
                    index[2] = l;
                else if(l>1 && dist[ l ] <= dist[ index[1] ] && dist[ index[0] ] <= dist[l])
                {
                    index[2] = index[1];
                    index[1] = l;
                }
                else if(l>1 && dist[ l ] <= dist[ index[0] ])
                {
                    index[2] = index[1];
                    index[1] = index[0];
                    index[0] = l;
                }
            }
            //CLASSIFIER: Saves the letter of the classifier corresponding to the index of the training
            //data letter
            int cl = index[0];
            //Compares each combination of letters.
            //If 3 or 2 distances are the same letter, the classifier chooses that letter.
            //If all are different, it chooses the one with the least distance.
            
            //All 3 are equal:
            if (train_let[ index[0] ].equals(train_let[ index[1] ])
                && train_let[ index[0] ].equals(train_let[ index[2] ]))//111
                cl = index[0];
            //If 2 are equal:
            else if(train_let[ index[0] ].equals(train_let[ index[1] ])
                    && !train_let[ index[0] ].equals(train_let[ index[2] ])) //110
                cl = index[0];
            else if(!train_let[ index[0] ].equals(train_let[ index[1] ])
                    && train_let[ index[0] ].equals(train_let[ index[2] ])) //101
                cl = index[0];
            else if(!train_let[ index[0] ].equals(train_let[ index[1] ])
                    && train_let[ index[1] ].equals(train_let[ index[2] ])) //011
                cl = index[1];
            //If none are equal, choose smallest:
            else if(!train_let[ index[0] ].equals(train_let[ index[1] ])
                    && !train_let[ index[0] ].equals(train_let[ index[2] ])
                    && !train_let[ index[1] ].equals(train_let[ index[2] ]))//012
                cl = index[0];
            
            evalClassifier[j] = train_let[cl];
            
            //Used for troubleshooting vv
            //System.out.println(evalClassifier[j]);
        }
        return evalClassifier;
    }
    
    public String[] euclid_NN5(String [] train_let, double [][] train, double [][] eval)
    {
        //Performs both distance (Euclidean) and NN5 algorithms.
        //Once the algorithm determines the 100 distances, it calculates and saves the indices
        //of the 5 smallest. Those 5 are then analyzed for which combinations of indices are
        //most similar or smallest, and the answers are then voted upon to determine the class.
        int etrow = eval.length;
        int ecol = eval[0].length;
        //int trow = train.length;  //same length as erow
        int tcol = train[0].length;
        //dist = distance between training letter for each eval point
        double [] dist = new double[ecol];
        
        String [] evalClassifier = new String[ecol];
        
        int index[] = new int[5];
        //Loops through ecols first (eval letter)
        for(int j=0; j<ecol; j++)
        {
            //initial index values
            index[0] = 0;
            index[1] = 0;
            index[2] = 0;
            index[3] = 0;
            index[4] = 0;
            //Loops through tcols second (training letter)
            for(int l=0; l<tcol-1; l++)
            {
                //Loops through etrows third (erow=trow length, so value is combined into etrow)
                for(int i=0; i<etrow; i++)
                {
                    //Both eval and training mu values must be subtracted to obtain distance measurements
                    //Both data values loop through the mu values in sequence with each other
                    
                    //sqrt((xa-xb)^2 + (ya-yb)^2 + (za-zb)^2 + ...
                    //where separate variables x, y, etc. are the mu labels
                    
                    dist[l] += Math.pow( eval[i][j] - train[i][l], 2 );
                }
                //Take the distance measurement and sqrt it
                dist[l] = Math.sqrt( dist[l] );
                
                //Saves first four measurements
                if(l==0)
                    index[0] = l;
                else if(l==1 && dist[ index[0] ] <= dist[ l ])
                    index[1] = l;
                else if(l==1 && dist[ l ] <= dist[ index[0] ])
                {
                    index[1] = index[0];
                    index[0] = l;
                } 
                else if(l==2 && dist[ index[1] ] <= dist[ l ])
                    index[2] = l;
                else if(l==2 && dist[ l ] <= dist[ index[1] ] && dist[ index[0] ] <= dist[l])
                {
                    index[2] = index[1];
                    index[1] = l;
                }
                else if(l==2 && dist[ l ] <= dist[ index[0] ])
                {
                    index[2] = index[1];
                    index[1] = index[0];
                    index[0] = l;
                }
                else if(l==3 && dist[ index[2] ] <= dist[ l ])
                    index[3] = l;
                else if(l==3 && dist[ l ] <= dist[ index[2] ] && dist[ index[1] ] <= dist[l])
                {
                    index[3] = index[2];
                    index[2] = l;
                }
                else if(l==3 && dist[ l ] <= dist[ index[1] ] && dist[ index[0] ] <= dist[l])
                {
                    index[3] = index[2];
                    index[2] = index[1];
                    index[1] = l;
                }
                else if(l==3 && dist[ l ] <= dist[ index[0] ])
                {
                    index[3] = index[2];
                    index[2] = index[1];
                    index[1] = index[0];
                    index[0] = l;
                }
                //For all recurring measurements after the first four, it saves the smallest:
                else if(l>3 && dist[ index[2] ] <= dist[ l ])
                    index[4] = l;
                else if(l>3 && dist[ l ] <= dist[ index[3] ] && dist[ index[2] ] <= dist[l])
                {
                    index[4] = index[3];
                    index[3] = l;
                }
                else if(l>3 && dist[ l ] <= dist[ index[2] ] && dist[ index[1] ] <= dist[l])
                {
                    index[4] = index[3];
                    index[3] = index[2];
                    index[2] = l;
                }
                else if(l>3 && dist[ l ] <= dist[ index[1] ] && dist[ index[0] ] <= dist[l])
                {
                    index[4] = index[3];
                    index[3] = index[2];
                    index[2] = index[1];
                    index[1] = l;
                }
                else if(l>3 && dist[ l ] <= dist[ index[0] ])
                {
                    index[4] = index[3];
                    index[3] = index[2];
                    index[2] = index[1];
                    index[1] = index[0];
                    index[0] = l;
                }
            }
            //CLASSIFIER: Saves the letter of the classifier corresponding to the index of the training
            //data letter
            int cl = index[0];
            //Compares each combination of letters.
            //If 5, 4, 3, or 2 distances are the same letter, the classifier chooses that letter.
            //If there are two different combinations of two that are the same, it chooses
            //the two with the lowest indices (smallest distance)
            //If all are different, it chooses the one with the least distance.
            
            //All 5 are equal:
            if (train_let[ index[0] ].equals(train_let[ index[1] ])
                && train_let[ index[0] ].equals(train_let[ index[2] ])
                && train_let[ index[0] ].equals(train_let[ index[3] ])
                && train_let[ index[0] ].equals(train_let[ index[4] ]))//11111
                {
                    cl = index[0];
                    //System.out.println("all" +  train_let[ index[0] ]);
                }
                
            //If 4 are equal:
            else if(train_let[ index[0] ].equals(train_let[ index[1] ])
                    && train_let[ index[0] ].equals(train_let[ index[2] ])
                    && train_let[ index[0] ].equals(train_let[ index[3] ])
                    && !train_let[ index[0] ].equals(train_let[ index[4] ])) //11110
                {
                    cl = index[0];
                    //System.out.println("4" + train_let[ index[0] ]);
                }
            else if(train_let[ index[0] ].equals(train_let[ index[1] ])
                    && train_let[ index[0] ].equals(train_let[ index[2] ])
                    && !train_let[ index[0] ].equals(train_let[ index[3] ])
                    && train_let[ index[0] ].equals(train_let[ index[4] ])) //11101
                {
                    cl = index[0];
                    //System.out.println("4" + train_let[ index[0] ]);
                }
            else if(train_let[ index[0] ].equals(train_let[ index[1] ])
                    && !train_let[ index[0] ].equals(train_let[ index[2] ])
                    && train_let[ index[0] ].equals(train_let[ index[3] ])
                    && train_let[ index[0] ].equals(train_let[ index[4] ])) //11011
                {
                    cl = index[0];
                    //System.out.println("4" + train_let[ index[0] ]);
                }
            else if(!train_let[ index[0] ].equals(train_let[ index[1] ])
                    && train_let[ index[0] ].equals(train_let[ index[2] ])
                    && train_let[ index[0] ].equals(train_let[ index[3] ])
                    && !train_let[ index[0] ].equals(train_let[ index[4] ])) //10111
                {
                    cl = index[0];
                    //System.out.println("4" + train_let[ index[0] ]);
                }
            else if(!train_let[ index[0] ].equals(train_let[ index[1] ])
                    && train_let[ index[1] ].equals(train_let[ index[2] ])
                    && train_let[ index[1] ].equals(train_let[ index[3] ])
                    && train_let[ index[1] ].equals(train_let[ index[4] ])) //01111
                {
                    cl = index[1];
                    //System.out.println("4" + train_let[ index[1] ]);
                }
                
            //If 3 are equal:
            else if(train_let[ index[0] ].equals(train_let[ index[1] ])
                    && train_let[ index[0] ].equals(train_let[ index[2] ])
                    && !train_let[ index[0] ].equals(train_let[ index[3] ])
                    && !train_let[ index[0] ].equals(train_let[ index[4] ])) //11100
                {
                    cl = index[0];
                    //System.out.println("3" + train_let[ index[0] ]);
                }
            else if(train_let[ index[0] ].equals(train_let[ index[1] ])
                    && !train_let[ index[0] ].equals(train_let[ index[2] ])
                    && train_let[ index[0] ].equals(train_let[ index[3] ])
                    && !train_let[ index[0] ].equals(train_let[ index[4] ])) //11010
                {
                    cl = index[0];
                    //System.out.println("3" + train_let[ index[0] ]);
                }
            else if(!train_let[ index[0] ].equals(train_let[ index[1] ])
                    && train_let[ index[0] ].equals(train_let[ index[2] ])
                    && train_let[ index[0] ].equals(train_let[ index[3] ])
                    && !train_let[ index[0] ].equals(train_let[ index[4] ])) //10110
                {
                    cl = index[0];
                    //System.out.println("3" + train_let[ index[0] ]);
                }
            else if(!train_let[ index[1] ].equals(train_let[ index[0] ])
                    && train_let[ index[1] ].equals(train_let[ index[2] ])
                    && train_let[ index[1] ].equals(train_let[ index[3] ])
                    && !train_let[ index[1] ].equals(train_let[ index[4] ])) //01110
                {
                    cl = index[1];
                    //System.out.println("3" + train_let[ index[1] ]);
                }
            else if(train_let[ index[0] ].equals(train_let[ index[1] ])
                    && !train_let[ index[0] ].equals(train_let[ index[2] ])
                    && !train_let[ index[0] ].equals(train_let[ index[3] ])
                    && train_let[ index[0] ].equals(train_let[ index[4] ])) //11001
                {
                    cl = index[0];
                    //System.out.println("3" + train_let[ index[0] ]);
                }
            else if(!train_let[ index[0] ].equals(train_let[ index[1] ])
                    && !train_let[ index[0] ].equals(train_let[ index[2] ])
                    && train_let[ index[0] ].equals(train_let[ index[3] ])
                    && train_let[ index[0] ].equals(train_let[ index[4] ])) //10011
                {
                    cl = index[0];
                    //System.out.println("3" + train_let[ index[0] ]);
                }
            else if(!train_let[ index[2] ].equals(train_let[ index[0] ])
                    && !train_let[ index[2] ].equals(train_let[ index[1] ])
                    && train_let[ index[2] ].equals(train_let[ index[3] ])
                    && train_let[ index[2] ].equals(train_let[ index[4] ])) //00111
                {
                    cl = index[2];
                    //System.out.println("3" + train_let[ index[2] ]);
                }
            else if(!train_let[ index[0] ].equals(train_let[ index[1] ])
                    && train_let[ index[0] ].equals(train_let[ index[2] ])
                    && !train_let[ index[0] ].equals(train_let[ index[3] ])
                    && train_let[ index[0] ].equals(train_let[ index[4] ])) //10101
                {
                    cl = index[0];
                    //System.out.println("3" + train_let[ index[0] ]);
                }
            else if(!train_let[ index[1] ].equals(train_let[ index[0] ])
                    && train_let[ index[1] ].equals(train_let[ index[2] ])
                    && !train_let[ index[1] ].equals(train_let[ index[3] ])
                    && train_let[ index[1] ].equals(train_let[ index[4] ])) //01101
                {
                    cl = index[1];
                    //System.out.println("3" + train_let[ index[1] ]);
                }
            else if(!train_let[ index[1] ].equals(train_let[ index[0] ])
                    && !train_let[ index[1] ].equals(train_let[ index[2] ])
                    && train_let[ index[1] ].equals(train_let[ index[3] ])
                    && train_let[ index[1] ].equals(train_let[ index[4] ])) //01011
                {
                    cl = index[1];
                    //System.out.println("3" + train_let[ index[1] ]);
                }
                
            //If 2 pairs are equal:                
            else if(train_let[ index[0] ].equals(train_let[ index[1] ])
                    && train_let[ index[2] ].equals(train_let[ index[3] ])
                    && !train_let[ index[0] ].equals(train_let[ index[4] ])
                    && !train_let[ index[2] ].equals(train_let[ index[4] ])
                    && !train_let[ index[0] ].equals(train_let[ index[2] ])) //11220
                {
                    cl = index[0];
                    //System.out.println("p2" + train_let[ index[0] ]);
                }
            else if(train_let[ index[0] ].equals(train_let[ index[1] ])
                    && train_let[ index[2] ].equals(train_let[ index[4] ])
                    && !train_let[ index[0] ].equals(train_let[ index[3] ])
                    && !train_let[ index[2] ].equals(train_let[ index[3] ])
                    && !train_let[ index[0] ].equals(train_let[ index[2] ])) //11202
                {
                    cl = index[0];
                    //System.out.println("p2" + train_let[ index[0] ]);
                }
            else if(train_let[ index[0] ].equals(train_let[ index[1] ])
                    && train_let[ index[3] ].equals(train_let[ index[4] ])
                    && !train_let[ index[0] ].equals(train_let[ index[2] ])
                    && !train_let[ index[3] ].equals(train_let[ index[2] ])
                    && !train_let[ index[0] ].equals(train_let[ index[3] ])) //11022
                {
                    cl = index[0];
                    //System.out.println("p2" + train_let[ index[0] ]);
                }
            else if(train_let[ index[0] ].equals(train_let[ index[2] ])
                    && train_let[ index[3] ].equals(train_let[ index[4] ])
                    && !train_let[ index[0] ].equals(train_let[ index[1] ])
                    && !train_let[ index[3] ].equals(train_let[ index[1] ])
                    && !train_let[ index[0] ].equals(train_let[ index[3] ])) //10122
                {
                    cl = index[0];
                    //System.out.println("p2" + train_let[ index[0] ]);
                }
            else if(train_let[ index[1] ].equals(train_let[ index[2] ])
                    && train_let[ index[3] ].equals(train_let[ index[4] ])
                    && !train_let[ index[1] ].equals(train_let[ index[0] ])
                    && !train_let[ index[3] ].equals(train_let[ index[0] ])
                    && !train_let[ index[1] ].equals(train_let[ index[3] ])) //01122
                {
                    cl = index[1];
                    //System.out.println("p2" + train_let[ index[1] ]);
                }
            else if(train_let[ index[0] ].equals(train_let[ index[2] ])
                    && train_let[ index[1] ].equals(train_let[ index[3] ])
                    && !train_let[ index[0] ].equals(train_let[ index[4] ])
                    && !train_let[ index[1] ].equals(train_let[ index[4] ])
                    && !train_let[ index[0] ].equals(train_let[ index[1] ])) //12120
                {
                    cl = index[0];
                    //System.out.println("p2" + train_let[ index[0] ]);
                }
            else if(train_let[ index[0] ].equals(train_let[ index[3] ])
                    && train_let[ index[1] ].equals(train_let[ index[2] ])
                    && !train_let[ index[0] ].equals(train_let[ index[4] ])
                    && !train_let[ index[1] ].equals(train_let[ index[4] ])
                    && !train_let[ index[0] ].equals(train_let[ index[1] ])) //12210
                {
                    cl = index[1];
                    //System.out.println("p2" + train_let[ index[1] ]);
                }
            else if(train_let[ index[0] ].equals(train_let[ index[4] ])
                    && train_let[ index[1] ].equals(train_let[ index[2] ])
                    && !train_let[ index[0] ].equals(train_let[ index[3] ])
                    && !train_let[ index[1] ].equals(train_let[ index[3] ])
                    && !train_let[ index[0] ].equals(train_let[ index[1] ])) //12201
                {
                    cl = index[1];
                    //System.out.println("p2" + train_let[ index[1] ]);
                }
            else if(train_let[ index[0] ].equals(train_let[ index[4] ])
                    && train_let[ index[1] ].equals(train_let[ index[3] ])
                    && !train_let[ index[0] ].equals(train_let[ index[2] ])
                    && !train_let[ index[1] ].equals(train_let[ index[2] ])
                    && !train_let[ index[0] ].equals(train_let[ index[1] ])) //12021
                {
                    cl = index[1];
                    //System.out.println("p2" + train_let[ index[1] ]);
                }
            else if(train_let[ index[0] ].equals(train_let[ index[4] ])
                    && train_let[ index[2] ].equals(train_let[ index[3] ])
                    && !train_let[ index[0] ].equals(train_let[ index[1] ])
                    && !train_let[ index[2] ].equals(train_let[ index[1] ])
                    && !train_let[ index[0] ].equals(train_let[ index[2] ])) //10221
                {
                    cl = index[2];
                    //System.out.println("p2" + train_let[ index[2] ]);
                }
            else if(train_let[ index[0] ].equals(train_let[ index[3] ])
                    && train_let[ index[2] ].equals(train_let[ index[4] ])
                    && !train_let[ index[0] ].equals(train_let[ index[1] ])
                    && !train_let[ index[2] ].equals(train_let[ index[1] ])
                    && !train_let[ index[0] ].equals(train_let[ index[2] ])) //10212
                {
                    cl = index[0];
                    //System.out.println("p2" + train_let[ index[0] ]);
                }
            else if(train_let[ index[0] ].equals(train_let[ index[3] ])
                    && train_let[ index[1] ].equals(train_let[ index[4] ])
                    && !train_let[ index[0] ].equals(train_let[ index[2] ])
                    && !train_let[ index[1] ].equals(train_let[ index[2] ])
                    && !train_let[ index[0] ].equals(train_let[ index[1] ])) //12012
                {
                    cl = index[0];
                    //System.out.println("p2" + train_let[ index[0] ]);
                }
            else if(train_let[ index[0] ].equals(train_let[ index[2] ])
                    && train_let[ index[1] ].equals(train_let[ index[4] ])
                    && !train_let[ index[0] ].equals(train_let[ index[3] ])
                    && !train_let[ index[1] ].equals(train_let[ index[3] ])
                    && !train_let[ index[0] ].equals(train_let[ index[1] ])) //12102
                {
                    cl = index[0];
                    //System.out.println("p2" + train_let[ index[0] ]);
                }
                
            //If 2 are equal:
            else if(train_let[ index[0] ].equals(train_let[ index[1] ])
                    && !train_let[ index[0] ].equals(train_let[ index[2] ])
                    && !train_let[ index[0] ].equals(train_let[ index[3] ])
                    && !train_let[ index[0] ].equals(train_let[ index[4] ])
                    && !train_let[ index[2] ].equals(train_let[ index[3] ])
                    && !train_let[ index[2] ].equals(train_let[ index[4] ])
                    && !train_let[ index[3] ].equals(train_let[ index[4] ])) //11234
                {
                    cl = index[0];
                    //System.out.println("2" + train_let[ index[0] ]);
                }
            else if(train_let[ index[0] ].equals(train_let[ index[2] ])
                    && !train_let[ index[0] ].equals(train_let[ index[1] ])
                    && !train_let[ index[0] ].equals(train_let[ index[3] ])
                    && !train_let[ index[0] ].equals(train_let[ index[4] ])
                    && !train_let[ index[1] ].equals(train_let[ index[3] ])
                    && !train_let[ index[1] ].equals(train_let[ index[4] ])
                    && !train_let[ index[3] ].equals(train_let[ index[4] ])) //12134
                {
                    cl = index[0];
                    //System.out.println("2" + train_let[ index[0] ]);
                }
            else if(train_let[ index[0] ].equals(train_let[ index[3] ])
                    && !train_let[ index[0] ].equals(train_let[ index[1] ])
                    && !train_let[ index[0] ].equals(train_let[ index[2] ])
                    && !train_let[ index[0] ].equals(train_let[ index[4] ])
                    && !train_let[ index[1] ].equals(train_let[ index[2] ])
                    && !train_let[ index[1] ].equals(train_let[ index[4] ])
                    && !train_let[ index[2] ].equals(train_let[ index[4] ]))//12314
                {
                    cl = index[0];
                    //System.out.println("2" + train_let[ index[0] ]);
                }
            else if(train_let[ index[0] ].equals(train_let[ index[4] ])
                    && !train_let[ index[0] ].equals(train_let[ index[1] ])
                    && !train_let[ index[0] ].equals(train_let[ index[2] ])
                    && !train_let[ index[0] ].equals(train_let[ index[3] ])
                    && !train_let[ index[1] ].equals(train_let[ index[2] ])
                    && !train_let[ index[1] ].equals(train_let[ index[3] ])
                    && !train_let[ index[2] ].equals(train_let[ index[3] ]))//12341
                {
                    cl = index[0];
                    //System.out.println("2" + train_let[ index[0] ]);
                }
            else if(train_let[ index[1] ].equals(train_let[ index[2] ])
                    && !train_let[ index[1] ].equals(train_let[ index[0] ])
                    && !train_let[ index[1] ].equals(train_let[ index[3] ])
                    && !train_let[ index[1] ].equals(train_let[ index[4] ])
                    && !train_let[ index[0] ].equals(train_let[ index[3] ])
                    && !train_let[ index[0] ].equals(train_let[ index[4] ])
                    && !train_let[ index[3] ].equals(train_let[ index[4] ])) //21134
                {
                    cl = index[1];
                    //System.out.println("2" + train_let[ index[1] ]);
                }
            else if(train_let[ index[1] ].equals(train_let[ index[3] ])
                    && !train_let[ index[1] ].equals(train_let[ index[0] ])
                    && !train_let[ index[1] ].equals(train_let[ index[2] ])
                    && !train_let[ index[1] ].equals(train_let[ index[4] ])
                    && !train_let[ index[0] ].equals(train_let[ index[2] ])
                    && !train_let[ index[0] ].equals(train_let[ index[4] ])
                    && !train_let[ index[2] ].equals(train_let[ index[4] ]))//21314
                {
                    cl = index[1];
                    //System.out.println("2" + train_let[ index[1] ]);
                }
            else if(train_let[ index[1] ].equals(train_let[ index[4] ])
                    && !train_let[ index[1] ].equals(train_let[ index[0] ])
                    && !train_let[ index[1] ].equals(train_let[ index[2] ])
                    && !train_let[ index[1] ].equals(train_let[ index[3] ])
                    && !train_let[ index[0] ].equals(train_let[ index[2] ])
                    && !train_let[ index[0] ].equals(train_let[ index[3] ])
                    && !train_let[ index[2] ].equals(train_let[ index[3] ]))//21341
                {
                    cl = index[1];
                    //System.out.println("2" + train_let[ index[1] ]);
                }
            else if(train_let[ index[2] ].equals(train_let[ index[3] ])
                    && !train_let[ index[2] ].equals(train_let[ index[0] ])
                    && !train_let[ index[2] ].equals(train_let[ index[1] ])
                    && !train_let[ index[2] ].equals(train_let[ index[4] ])
                    && !train_let[ index[0] ].equals(train_let[ index[1] ])
                    && !train_let[ index[0] ].equals(train_let[ index[4] ])
                    && !train_let[ index[1] ].equals(train_let[ index[4] ]))//23114
                {
                    cl = index[2];
                    //System.out.println("2" + train_let[ index[2] ]);
                }
            else if(train_let[ index[2] ].equals(train_let[ index[4] ])
                    && !train_let[ index[2] ].equals(train_let[ index[0] ])
                    && !train_let[ index[2] ].equals(train_let[ index[1] ])
                    && !train_let[ index[2] ].equals(train_let[ index[3] ])
                    && !train_let[ index[0] ].equals(train_let[ index[1] ])
                    && !train_let[ index[0] ].equals(train_let[ index[3] ])
                    && !train_let[ index[1] ].equals(train_let[ index[3] ]))//23141
                {
                    cl = index[2];
                    //System.out.println("2" + train_let[ index[2] ]);
                }
            else if(train_let[ index[3] ].equals(train_let[ index[4] ])
                    && !train_let[ index[3] ].equals(train_let[ index[0] ])
                    && !train_let[ index[3] ].equals(train_let[ index[1] ])
                    && !train_let[ index[3] ].equals(train_let[ index[2] ])
                    && !train_let[ index[0] ].equals(train_let[ index[1] ])
                    && !train_let[ index[0] ].equals(train_let[ index[2] ])
                    && !train_let[ index[1] ].equals(train_let[ index[2] ]))//23411
                {
                    cl = index[3];
                    //System.out.println("2" + train_let[ index[3] ]);
                }
            
            //If none are equal, choose smallest:
            else if(!train_let[ index[0] ].equals(train_let[ index[1] ])
                    && !train_let[ index[0] ].equals(train_let[ index[2] ])
                    && !train_let[ index[0] ].equals(train_let[ index[3] ])
                    && !train_let[ index[0] ].equals(train_let[ index[4] ])
                    && !train_let[ index[1] ].equals(train_let[ index[2] ])
                    && !train_let[ index[1] ].equals(train_let[ index[3] ])
                    && !train_let[ index[1] ].equals(train_let[ index[4] ])
                    && !train_let[ index[2] ].equals(train_let[ index[3] ])
                    && !train_let[ index[2] ].equals(train_let[ index[4] ])
                    && !train_let[ index[3] ].equals(train_let[ index[4] ])) //12345
                {
                    cl = index[0];
                    //System.out.println("1" + train_let[ index[0] ]);
                }
            
            evalClassifier[j] = train_let[cl];
            
            //Used for troubleshooting vv
            //System.out.println(evalClassifier[j]);
        }
        return evalClassifier;
    }
}
