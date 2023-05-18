
/**
 * @author Nathaniel Weissinger
 * 
 * This program takes in two sets of data: the training data, and the imported
 * weights (originally from a text file, converted into matrices).
 * L1sum is Layer 1 Summation, which performs a matrix multiplication of each
 * training data point with its respective weight value. The result is then summed
 * for each node to obtain a summation output.
 * 
 * L2activation is Layer 2 Activation Function, which sends the previous summation
 * through a premade function. In this case, the function is f(xi) = 1/(1+e^(-2xi)).
 * 
 * These methods are looped through twice: the first with the normalized training
 * data and the 'wji' set of weights, then the second time with the output of
 * the previous activation function and the 'wkj' set of weights. The result
 * is then saved as a variable 'zk' in the HW5 class.
 */

import java.util.*;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import java.io.*;
import javax.imageio.*;
import java.lang.*;

public class NeuralNetwork
{
    public double[][] L1sum(double[][] d, double[][] w)
    {
        //Layer 1 Summation
        //Receives training data and weights, multiplies them, then sums
        //them for each node (matrix multiplication)
        
        int nodes = w.length; //number of nodes
        int rows = d.length; //number of features (for both data and weights) (8)
        int cols = d[0].length; //all data points (1)
        Data data = new Data(rows);
        double[][] net = new double[nodes][cols];
        
        
        for(int j=0; j<cols; j++) //loops through each data point
        {
            for(int i=0; i<rows; i++) //loops through data row features
            {
                for(int n=0; n<nodes; n++) //loops through each node
                {
                    //Sums net vector with matrix multiplication
                    net[n][j] += d[i][j] * w[n][i];
                }
            }
            //System.out.println(net[n][0]);
        }
        return net;
    }
    
    public double[][] L2activation(double[][] net)
    {
        //Layer 2 Activation Function
        //Sends node sum net through activation function
        int nodes = net.length; //number of nodes
        int cols = net[0].length; //all data points
        double[][] y = new double[nodes][cols];
        
        for(int j=0; j<cols; j++) //loops through data points
        {
            for(int i=0; i<nodes; i++) //loops through mean values
            {
                //Activation function: f(xi) = 1/(1+e^(-2xi))
                y[i][j] = 1/(1+Math.exp(-2*net[i][j]));
                //System.out.print(y[i][j] + " ");
            }
            //System.out.print("\n");
        }
        return y;
    }
}