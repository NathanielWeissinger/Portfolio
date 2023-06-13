------------------------------------
PROJECT TITLE:	Circuit Tracer
CLASS:		CS221
AUTHOR:		Nathaniel Weissinger
DATE:		December 11, 2020
------------------------------------

Overview:

The Circuit Tracer is a program designed to take an input file with a grid of open and closed locations.
Given a starting and ending point, the program searches for the quickest routes to the destination, then
traces the path and displays the altered output with the new circuit path.


INCLUDED FILES:
* CircuitTracer.java - receives input files and arguments, contains search algorithm, and displays output
* CircuitBoard.java - receives input filename from CircuitTracer, parses the file, and creates a
		      character array board
* CircuitTracerTester.java - tester class for CircuitTracer
* OccupiedPositionException.java - a RuntimeException extension
* InvalidFileFormatException.java - a RuntimeException extension
* TraceState.java - records previously defined TraceState objects and creates a path through the circuit
* Storage.java - storage class for storing TraceState objects within either a queue or a stack
* README.txt - this file


Sources:
CircuitTracer:		http://cs.boisestate.edu/~cs221/projects/CircuitTracer/CircuitTracer.html


COMPILING AND RUNNING:

From the directory of the program, to compile on Onyx, type:
$ javac CircuitTracer.java

This will compile the CircuitTracer class before running.

To run the program, type:
$ java CircuitTracer

There will be three input arguments.
First: -s for using a stack storage, or -q for queue storage;
Second: -c for using the console as the output, and -g for using a GUI as the output
Third: the name of the file

The final input will look like this:
$ java CircuitTracer -s -c valid1.dat

(NOTE: The GUI has not been created, and as such, the '-g' option has been disabled)


ANALYSIS:
Q: How does the choice of Storage configuration (stack vs queue) affect the sequence in which
paths are explored in the search algorithm? (This requires more than a "stacks are LIFOs
and queues are FIFOs" answer.)
A: When using a Stack, the defined algorithm will continually create new TraceState objects until
there are no options left at the end of the path, then the program works backwards along the path
line to find the best path. The queue, however, goes along all paths directly next to it first.
Essentially, the stack is like using a faster single core processor, whereas a queue is like using
a slowertri-core parallel processor (even though both will analyze the scenarios at the same speeds).
In a stack, one path is looked at at a time and backtraces, whereas a queue looks at all possible
paths at once from its starting location.

Q: Is the total number of search states (possible paths) affected by the choice of stack or queue?
A: No- the only difference is the order in which the paths are evaluated.

Q: How is memory use (the maximum number of states in Storage at one time) affected by the choice
of underlying structure?
A: The stack has a smaller memory use, because it creates a single path and backtraces before going
to a new path, whereas the queue analyzes multiple paths at once, exponentially using more memory
as the program runs. In essence, the queue is more dependent on the size of the grid, and it could
potentially use less memory if the grid were small enough.

Q: What is the Big-Oh runtime for the search algorithm? Does it reflect the maximum size of Storage?
Does it reflect the number of board positions? Does it reflect the number of paths explored?
Does it reflect the maximum path length? Is it something else?
A: I'm not entirely sure what the Big-Oh runtime is, but I would guess O(n log(n)) because the algorithm
looks at every possible path, but doesn't backtrace or cross paths with spaces marked with 'X's.
The maximum size of Storage would have to be unnaturally low for it to affect the runtime, so no, it
wouldn't really affect it. The number of board positions definitely impacts the time, since as the grid
gets larger, there will be exponentially more case scenarios. The number of paths explored is relative
to the grid size, so that also affects the runtime. However, the algorithm requires all paths to be
explored, which again means that the size of the grid is the main factor in determining runtime.
The only way to make the runtime shorter is to add more 'X' components and limit the number of possible
paths, and to make the end point as close as possible to the start point while preventing other paths.

Q: Does using one of the storage structures usually find a solution in fewer steps than the other?
Always?
A: The queue is best used when the location of the end point is close to the start point.
The stack is more efficient if the end location is further away.

Q: Does using either of the storage structures guarantee that the first solution found will be a
shortest path?
A: The queue will typically give the shortest path first, but it will take longer to obtain.


DESIGN:

CircuitTracer:

CircuitTracer(String args[])-
This method takes in the three arguments (stack/queue, console/GUI, and filename), then defines the
key objects- the CircuitBoard object, the Storage object, and the TraceState objects. This serves
as the fundamentals for the search algorithm. After the CircuitBoard is created after passing the
filename, the Storage is initialized to define how the algorithm will sequentially sort through
the matrix. Then, using TraceState objects, the paths between open spaces are recorded, and the
scenarios with the shortest paths are recorded in a List and displayed once the search is complete.

main(String args[])-
Acts as console input for the program

printUsage()-
If there are not three arguments sent through the program, this method displays instructions on
how to define the input arguments.


CircuitBoard:

CircuitBoard(String filename)-
This method takes the filename input and parses an input file into a char array. It also checks
for incorrect arguments, and throws InvalidFileFormatExceptions if there is something wrong
(such as an incorrect letter, incorrect dimensions, or other unexpected parsing errors)

CircuitBoard(CircuitBoard original)
Used for making a copy of the original board

isOpen(row, col)-
Returns whether a specific position on the board is open for a trace (as defined with the letter 'O')

makeTrace(row, col)-
Sets the location on the board as a trace (the letter 'T'), used for tracing a path from the starting
location to the end location

getBoard(), charAt(row, col), getStartingPoint(), getEndingPoint(), numRows(), numCols(), and
toString() all return the values as their names imply.


CircuitTracerTester:
A program provided that tests the CircuitTracer methods by providing various inputs
and analyzing the methods' responses.


OccupiedPositionException:
This class simply is an extension and redefines a RuntimeException


InvalidFileFormatException:
This class simply is an extension and redefines a RuntimeException


TraceState:

TraceState(startingBoard, row, col)-
Defines the first trace next to the starting point on the board by passing in a CircuitBoard object first

TraceState(previousState, row, col)-
Defines the following traces by linking them with the previous. These form a path, using an ArrayList of
Point objects, and copies the CircuitBoard object from the previous states.

adjacent(p1, p2)
Returns true if the first point is adjacent to the second point in any direction except diagonally.

isOpen(row, col), getBoard(), pathLength(), getPath(), isComplete(), getRow(), getCol(), and toString()
all return the values as their names imply.


Storage:
A modified structure class that either uses a Queue or Stack, depending on how the object is initialized.
Otherwise, it runs identically to both, and copies the methods used in each of the two structures.



TESTING:

I started by creating the CircuitBoard class, which took in the filename input and parsed the file into
a char array. I mainly copied the code from the first project of the semester, since most of it did the
same thing. However, I had to create a bunch of extra testing scenarios, so that if the grid wasn't defined
correctly, or something went wrong, the program would throw an InvalidFileFormatException. Initially, this
went smoothly, but as I tested the program further, there were a few minor errors that caused come tests
to fail. I initially created a fileScan variable that scanned the whole file, but due to the limitations
of the class, if I reached the end of a line, the class couldn't tell the difference between the whitespace
and a new line. So I had to separate the scanner into two- one that analyzed the whole file, and the second
that went through each line separately. This fixed every problem with the CircuitBoard class.

I then went onto the CircuitTracer class, which started out easy enough. I followed the instructions as
the instructor had stated, yet on the first run through, the stack overflowed, and it gave me several
errors. Come to find out, the TraceState class had a limitation- it didn't analyze previous state locations
and return whether they were part of the path. I had to manually define which locations were and were not
part of the previous state's path, and once I did that, everything compiled and ran correctly.

The last issue I came across was why every valid file failed the tests. After finding the output file format,
I altered my previous code (I had added one too many '\n' escape characters), and once I formatted it to
be identical to the output, all my tests passed perfectly.


DISCUSSION:

Most of this assignment was fairly straightforward. Creating the algorithm was fairly easy once I found the
source of the initial errors, and the design for the program was well-written. The parts that were tedious
were having to define every scenario in which an input file would be deemed invalid, as well as ensuring
the TraceState objects didn't overlap with each other and cause infinite loop errors. Relative to the
DoublyLinkedList, this assignment was quite easy.