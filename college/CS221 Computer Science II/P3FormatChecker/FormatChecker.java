import java.io.*;
import java.util.*;

/**
 * @author Nathaniel Weissinger
 * This class checks for the errors in formatting from specified input
 * files, and returns whether they are valid or not.
 * The first row of the file should have the matrix dimensions: first
 * digit is the row size, second digit is the column size, separated by
 * a space. Both digits are nonnegative integers.
 * 
 * The rest of the file is a matrix with the correct rows/columns specified
 * by the first two matrix dimension identifiers. If the row/column
 * sizes are incorrect after initial specification, then the FormatChecker
 * returns an INVALID error. Otherwise, the program returns VALID.
 */
public class FormatChecker
{
    //@param  args[] are the command-line input filenames
    public static void main(String args[])
    {
        Scanner filescan = null;
        String filename = "";
        String line[];
        double grid[][];
        for(int i = 0; i<args.length; i++) {
            filename += args[i];        //input files
        }
        
        try{
            filescan = new Scanner(new File(filename));
            
            //FIRST LINE
            //@param
            int row = filescan.nextInt();
            int col = filescan.nextInt();
            line = new String[row+1];
            line[0] = filescan.nextLine();
            line[0].trim();
            if(!line[0].isEmpty()) { //isEmpty() method returns true if it's empty
                //@throws a custom Exception class:
                throw new LineException(line[0]);
            }
            
            //GRID CHECKER:
            grid = new double[row][col];
            for(int k=0; k<row; k++)
            {
                for(int l=0; l<col; l++)
                {
                    grid[k][l] = filescan.nextDouble();
                }
                line[k] = filescan.nextLine();  //if there are more unexpected
                                                //elements in the row:
                if(!line[k].isEmpty()) {
                    //@throws a custom Exception class:
                    throw new LineException(line[k]);
                }
            }
            
            //Checking outside the boundaries of the grid:
            if(filescan.hasNext()) {
                line[row]=filescan.nextLine();         //if there are unexpected
                //@throws a custom Exception class:    //additional columns
                throw new LineException(line[row]); 
            }
            
            //If there have been no exceptions thrown so far:
            System.out.println("VALID: " +filename);
            
        } catch(FileNotFoundException e) { //@returns invalid if it can't find the file
            System.out.println(e.toString()+" INVALID:" +filename + " File Not Found");
        } catch(InputMismatchException e) { //@returns invalid if the scanned number format is incorrect
            System.out.println(e.toString()+" INVALID: " +filescan.next() + " is not an integer");
        } catch(LineException e) { //@returns invalid if there are additional line items
            System.out.println(e.toString()+" INVALID: This line does not conform to boundaries");
        } finally { //closes program
            if (filescan != null){
                filescan.close();
            }
        }
        
    }
}
class LineException extends Exception
{
    /*
     * This is a custom class to indicate that there are errors
     * on the current line, typically an unexpected additional element.
     */
    //@param   args is the passed string that caused the error to be thrown
    public LineException(String args)
    {
        super(args);
    }
}
