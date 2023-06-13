import java.awt.Point;
import java.util.*;
import java.io.*;

/**
 * Search for shortest paths between start and end points on a circuit board
 * as read from an input file using either a stack or queue as the underlying
 * search state storage structure and displaying output to the console or to
 * a GUI according to options specified via command-line arguments.
 * 
 * @author Nathaniel Weissinger
 */
public class CircuitTracer {

    /** launch the program
     * @param args three required arguments:
     *  first arg: -s for stack or -q for queue
     *  second arg: -c for console output or -g for GUI output
     *  third arg: input file name 
     */
    public static void main(String[] args) {
        if (args.length != 3) {
            printUsage();
            System.exit(1);
        }
        try {
            new CircuitTracer(args); //create this with args
        } catch (Exception e) {
            e.printStackTrace();
            System.exit(1);
        }
    }

    /** Print instructions for running CircuitTracer from the command line. */
    private static void printUsage() {
        //TODO: print out clear usage instructions when there are problems with
        System.out.println("Enter 3 String command arguments, each with quotations and separated by commas."+
            "\n\nThe first argument will be either -s or -q, which defines the underlying "+
            "\n\tsearch state storage structure as either a stack or a queue."+
            "\nThe second argument will be either -c or -g, which specifies "+
            "\n\twhether the output will be through the console or the GUI."+
            "\nThe third argument will be the name of the file, including its extension.");
        // any command line args
    }
    
    /** 
     * Set up the CircuitBoard and all other components based on command
     * line arguments.
     * 
     * @param args command line arguments passed through from main()
     */
    private CircuitTracer(String[] args) {
        //TODO: parse command line args
        boolean arg0 = false;
        boolean arg1 = false;
        if(args[0].equals("-s"))
        {
            arg0 = true;
        }
        else if(args[0].equals("-q"))
        {
            arg0 = false;
        }
        else
        {
            System.out.println("FIRST ARGUMENT INVALID\nENTER EITHER \"-s\" or \"-q\"");
            System.exit(0);
        }
        
        if(args[1].equals("-c"))
        {
            arg1 = true;
        }
        else if(args[1].equals("-g"))
        {
            arg1 = false;
            System.out.println("GUI Disabled. Please retry by changing the second argument to \"-c\".");
            System.exit(0);
        }
        else
        {
            System.out.println("SECOND ARGUMENT INVALID\nENTER EITHER \"-c\" or \"-g\"");
            System.exit(0);
        }
        
        String filename = args[2];
        Storage stateStore;
        try{
            //TODO: initialize the Storage to use either a stack or queue
            if(arg0)
                stateStore = new Storage(Storage.DataStructure.stack);
            else
                stateStore = new Storage(Storage.DataStructure.queue);
            
            if(arg1)
            {
                //CONSOLE OUTPUT
                //TODO: read in the CircuitBoard from the given file
                CircuitBoard cb = new CircuitBoard(filename);
                //TODO: run the search for best paths
                ArrayList <TraceState>bestPaths = new <TraceState>ArrayList();
                TraceState startTrace;// = new TraceState(cb, cb.getStartingPoint().x, cb.getStartingPoint().y);
                if(cb.isOpen(cb.getStartingPoint().x+1, cb.getStartingPoint().y))
                {
                    startTrace = new TraceState(cb, cb.getStartingPoint().x+1, cb.getStartingPoint().y);
                    stateStore.store(startTrace);
                }
                if(cb.isOpen(cb.getStartingPoint().x-1, cb.getStartingPoint().y))
                {
                    startTrace = new TraceState(cb, cb.getStartingPoint().x-1, cb.getStartingPoint().y);
                    stateStore.store(startTrace);
                }
                if(cb.isOpen(cb.getStartingPoint().x, cb.getStartingPoint().y+1))
                {
                    startTrace = new TraceState(cb, cb.getStartingPoint().x, cb.getStartingPoint().y+1);
                    stateStore.store(startTrace);
                }
                if(cb.isOpen(cb.getStartingPoint().x, cb.getStartingPoint().y-1))
                {
                    startTrace = new TraceState(cb, cb.getStartingPoint().x, cb.getStartingPoint().y-1);
                    stateStore.store(startTrace);
                }
                
                while (!stateStore.isEmpty())
                {
                    TraceState nextTrace = (TraceState)stateStore.retrieve();
                    if(nextTrace.isComplete())
                    {
                        if(bestPaths.isEmpty())
                        {
                            bestPaths.add(nextTrace);
                        }
                        else
                        {
                            for(int i=0; i<bestPaths.size(); i++)
                            {
                                if(nextTrace.pathLength() == bestPaths.get(i).pathLength())
                                {
                                    bestPaths.add(nextTrace);
                                    break;
                                }
                                else if(nextTrace.pathLength() < bestPaths.get(i).pathLength())
                                {
                                    bestPaths.clear();
                                    bestPaths.add(nextTrace);
                                }
                            }
                        }
                    }
                    else
                    {
                        if(nextTrace.isOpen(nextTrace.getRow()+1, nextTrace.getCol()) && !nextTrace.getPath().get(nextTrace.getPath().size()-1).equals(new Point(nextTrace.getRow()+1, nextTrace.getCol())))
                        {
                            TraceState newTrace = new TraceState(nextTrace, nextTrace.getRow()+1, nextTrace.getCol());
                            stateStore.store(newTrace);
                        }
                        if(nextTrace.isOpen(nextTrace.getRow()-1, nextTrace.getCol())  && !nextTrace.getPath().get(nextTrace.getPath().size()-1).equals(new Point(nextTrace.getRow()-1, nextTrace.getCol())))
                        {
                            TraceState newTrace = new TraceState(nextTrace, nextTrace.getRow()-1, nextTrace.getCol());
                            stateStore.store(newTrace);
                        }
                        if(nextTrace.isOpen(nextTrace.getRow(), nextTrace.getCol()+1)  && !nextTrace.getPath().get(nextTrace.getPath().size()-1).equals(new Point(nextTrace.getRow(), nextTrace.getCol()+1)))
                        {
                            TraceState newTrace = new TraceState(nextTrace, nextTrace.getRow(), nextTrace.getCol()+1);
                            stateStore.store(newTrace);
                        }
                        if(nextTrace.isOpen(nextTrace.getRow(), nextTrace.getCol()-1)  && !nextTrace.getPath().get(nextTrace.getPath().size()-1).equals(new Point(nextTrace.getRow(), nextTrace.getCol()-1)))
                        {
                            TraceState newTrace = new TraceState(nextTrace, nextTrace.getRow(), nextTrace.getCol()-1);
                            stateStore.store(newTrace);
                        }
                    }
                }
                for(int i=0; i<bestPaths.size(); i++)
                {
                    for(int j=0; j<bestPaths.get(i).getBoard().numRows(); j++)
                    {
                        for(int k=0; k<bestPaths.get(i).getBoard().numCols(); k++)
                        {
                            System.out.print(""+bestPaths.get(i).getBoard().charAt(j,k)+" ");
                        }
                        System.out.print("\n");
                    }
                    System.out.print("\n");
                }
            }
            else
            {
                //RUN GUI
                //TODO: output results to console or GUI, according to specified choice
            }
        }catch(FileNotFoundException e){System.out.println(filename + " File Not Found"); }
    }
    
} // class CircuitTracer
