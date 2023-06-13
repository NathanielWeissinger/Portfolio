****************
* Project 3: 	FormatChecker
* Class:	CS221
* Date:		09/21/2020
* Your name:	Nathaniel Weissinger
**************** 

OVERVIEW:

FormatChecker checks for the errors in formatting from specified input
files, and returns whether they are valid or not.
The first row of the file should have the matrix dimensions: first
digit is the row size, second digit is the column size, separated by
a space. Both digits are nonnegative integers.

The rest of the file is a matrix with the correct rows/columns specified
by the first two matrix dimension identifiers. If the row/column
sizes are incorrect after initial specification, then the FormatChecker
returns an INVALID error. Otherwise, the program returns VALID.


INCLUDED FILES:

FormatChecker.java - source file
FormatChecker.class - source file
LineException.class - source file
invalid1.txt - used for testing
invalid2.txt - used for testing
invalid3.txt - used for testing
invalid4.txt - used for testing
invalid5.txt - used for testing
invalid6.txt - used for testing
invalid7.txt - used for testing
valid1.txt - used for testing
valid2.txt - used for testing
valid3.txt - used for testing
README - this file


COMPILING AND RUNNING:

From the directory of the program, to compile on Onyx, type:
$ javac FormatChecker.java

To run the programs, type:
$ java FormatChecker


PROGRAM DESIGN AND IMPORTANT CONCEPTS:

In the FormatChecker class, there is only one method used: main(String args[]).
The method scans the input file, then places each value into a 2D matrix.
The following five methods then return calculations based off this matrix:

main(String args[]): 

The instructor provided the valid and invalid test files to make sure the FormatChecker
class provided the intended output.


TESTING:

The FormatChecker program ran through a series of tests that ensured proper matrix
dimensions. All tests passed.