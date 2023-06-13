****************
* Project 1: 	GridMonitor
* Class:	CS221
* Date:		08/26/2020
* Your name:	Nathaniel Weissinger
**************** 

OVERVIEW:

GridMonitor reads a text file with a prespecified format, then converts the data to a
2D matrix of doubles. There are 4 methods which then look at the surrounding data points
by summing, averaging, creating a range, and determining if any value is out of the range.
This data is used to determine if any solar cells are at risk of exploding.


INCLUDED FILES:

GridMonitor.java - source file
GridMonitorInterface.java - source file
GridMonitorTest.java - source file
negatives.txt - used for testing
oneByOne.txt - used for testing
sample.txt - used for testing
sample4x5.txt - used for testing
sampleDoubles.txt - used for testing
wideRange.txt - used for testing
README - this file


COMPILING AND RUNNING:

From the directory of the program, to compile on Onyx, type either:
$ javac GridMonitor.java
OR
$ javac GridMonitorTest.java

The first will run the output of all commands within the GridMonitor class, and
the second will run the tester class that the instructor created.

To run the programs, type:
$ java GridMonitor
OR
$ java GridMonitorTest


PROGRAM DESIGN AND IMPORTANT CONCEPTS:

In the GridMonitor class, there are six methods used, and one main tester method.
The constructor method scans the input file, then places each value into a 2D matrix.
The following five methods then return calculations based off this matrix:

getBaseGrid(): returns the original 2D array scanned from the file
getSurroundingSumGrid(): returns 2D array of the sums of the four adjacent cells
getSurroundingAvgGrid(): calls the getSurroundingSumGrid() method, and divides
			 each value by 4 to obtain the average of the four cells
getDeltaGrid(): calls the getSurroundingAvgGrid() method, then divides it by 2 so
		that the values of the cells can be compared with each other and
		not exceed 50% of the surrounding averages
getDangerGrid(): If the surrounding average +/- the delta value is exceeded, the
		 cell is given a boolean true value, indicating that it's in the
		 danger zone. Otherwise the cell is given a false value, and the
		 method returns a 2D boolean array.

The instructor provided the GridMonitorTest class to test to make sure the GridMonitor class
provided the intended output.


TESTING:

The GridMonitorTest program ran through a series of tests that covered encapsulation,
the outputs of each method, etc. All tests passed.


DISCUSSION:

I completed the programming portion of the assignment in approximately 45min.
Fixing a few errors took me approximately 15min, and for the last few errors,
I needed to ask on a forum, but the problem was solved almost immediately.
This was a very easy assignment. The hardest part was this write-up and figuring
out how to submit the assignment. This proect mainly served as a review of general
coding algorithms and structure.