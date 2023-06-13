import java.awt.Point;
import java.io.File;
import java.io.FileNotFoundException;
import java.util.*;

/**
 * Represents a 2D circuit board as read from an input file.
 *  
 * @author Nathaniel Weissinger
 */
public class CircuitBoard {
    /** current contents of the board */
    private char[][] board;
    /** location of row,col for '1' */
    private Point startingPoint;
    /** location of row,col for '2' */
    private Point endingPoint;

    //constants you may find useful
    private final int ROWS; //initialized in constructor
    private final int COLS; //initialized in constructor
    private final char OPEN = 'O'; //capital 'o'
    private final char CLOSED = 'X';
    private final char TRACE = 'T';
    private final char START = '1';
    private final char END = '2';
    private final String ALLOWED_CHARS = "OXT12";

    /** Construct a CircuitBoard from a given board input file, where the first
     * line contains the number of rows and columns as ints and each subsequent
     * line is one row of characters representing the contents of that position.
     * Valid characters are as follows:
     *  'O' an open position
     *  'X' an occupied, unavailable position
     *  '1' first of two components needing to be connected
     *  '2' second of two components needing to be connected
     *  'T' is not expected in input files - represents part of the trace
     *   connecting components 1 and 2 in the solution
     * 
     * @param filename
     *      file containing a grid of characters
     * @throws FileNotFoundException if Scanner cannot read the file
     * @throws InvalidFileFormatException for any other format or content issue that prevents reading a valid input file
     */
    public CircuitBoard(String filename) throws FileNotFoundException { // throw FileNotFoundException if Scanner cannot read the file
        Scanner fileScan = new Scanner(new File(filename));
        String invalid = "";
        char validChars[] = ALLOWED_CHARS.toCharArray();
        try{
            ROWS = fileScan.nextInt();
            COLS = fileScan.nextInt();
            boolean start = false;
            boolean end = false;
            invalid = "" + fileScan.nextLine();
            
            if(!invalid.equals(""))
            {
                throw new InvalidFileFormatException(invalid);
            }
            
            //TODO: parse the given file to populate the char[][]
            board = new char[ROWS][COLS];
            for(int k=0; k<ROWS; k++)
            {
                String tempLine = fileScan.nextLine();
                Scanner lineScan = new Scanner(tempLine);
                for(int l=0; l<COLS; l++)
                {
                    String tempChar = lineScan.next();
                    if(tempChar.length()>1)
                    {
                        invalid = "" + tempChar;
                        throw new InvalidFileFormatException(invalid);
                    }
                    board[k][l] = tempChar.charAt(0);
                    boolean valid = false;
                    for(int c=0; c<validChars.length; c++)
                    {
                        if(board[k][l] == validChars[c])
                        {
                            valid = true;
                        }
                    }
                    if(board[k][l] == '1' && !start)
                    {
                        start = true;
                        startingPoint = new Point(k, l);
                    }
                    else if(board[k][l] == '2' && !end)
                    {
                        end = true;
                        endingPoint = new Point(k, l);
                    }
                    else if((board[k][l] == '1' && start) || (board[k][l] == '2' && end))
                    {
                        valid = false;
                    }
                    if(!valid)
                    {
                        invalid = "" + tempChar;
                        throw new InvalidFileFormatException(invalid);
                    }
                    //System.out.print(board[k][l] + " ");
                    if(l==COLS-1)
                    {
                        if(lineScan.hasNext())
                            throw new InvalidFileFormatException("EXTRA VARIABLE ON COL");
                    }
                }
                if(k==ROWS-1)
                {
                    if(fileScan.hasNext())
                        throw new InvalidFileFormatException("EXTRA VARIABLE ON ROW");
                }
                //System.out.print("\n");
                lineScan.close();
            }
            if(!start || !end)
            {
                invalid = "NO START/END";
                throw new InvalidFileFormatException(invalid);
            }
        } catch(Exception e){System.out.println("ERROR In Input File "+invalid);
            throw new InvalidFileFormatException(invalid);}
            // throw InvalidFileFormatException if any formatting or parsing issues are encountered
        fileScan.close();
    }
    
    /** Copy constructor - duplicates original board
     * 
     * @param original board to copy
     */
    public CircuitBoard(CircuitBoard original) {
        board = original.getBoard();
        startingPoint = new Point(original.startingPoint);
        endingPoint = new Point(original.endingPoint);
        ROWS = original.numRows();
        COLS = original.numCols();
    }

    /** utility method for copy constructor
     * @return copy of board array */
    private char[][] getBoard() {
        char[][] copy = new char[board.length][board[0].length];
        for (int row = 0; row < board.length; row++) {
            for (int col = 0; col < board[row].length; col++) {
                copy[row][col] = board[row][col];
            }
        }
        return copy;
    }
    
    /** Return the char at board position x,y
     * @param row row coordinate
     * @param col col coordinate
     * @return char at row, col
     */
    public char charAt(int row, int col) {
        return board[row][col];
    }
    
    /** Return whether given board position is open
     * @param row
     * @param col
     * @return true if position at (row, col) is open 
     */
    public boolean isOpen(int row, int col) {
        if (row < 0 || row >= board.length || col < 0 || col >= board[row].length) {
            return false;
        }
        return board[row][col] == OPEN;
    }
    
    /** Set given position to be a 'T'
     * @param row
     * @param col
     * @throws OccupiedPositionException if given position is not open
     */
    public void makeTrace(int row, int col) {
        if (isOpen(row, col)) {
            board[row][col] = TRACE;
        } else {
            throw new OccupiedPositionException("row " + row + ", col " + col + "contains '" + board[row][col] + "'");
        }
    }
    
    /** @return starting Point(row,col) */
    public Point getStartingPoint() {
        return new Point(startingPoint);
    }
    
    /** @return ending Point(row,col) */
    public Point getEndingPoint() {
        return new Point(endingPoint);
    }
    
    /** @return number of rows in this CircuitBoard */
    public int numRows() {
        return ROWS;
    }
    
    /** @return number of columns in this CircuitBoard */
    public int numCols() {
        return COLS;
    }

    /* (non-Javadoc)
     * @see java.lang.Object#toString()
     */
    public String toString() {
        StringBuilder str = new StringBuilder();
        for (int row = 0; row < board.length; row++) {
            for (int col = 0; col < board[row].length; col++) {
                str.append(board[row][col] + " ");
            }
            str.append("\n");
        }
        return str.toString();
    }
    
}// class CircuitBoard
