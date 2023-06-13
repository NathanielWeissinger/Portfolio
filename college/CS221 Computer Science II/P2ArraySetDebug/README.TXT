P2: Array Set Debug
Nathaniel Weissinger
9/15/2020

OVERVIEW:

ArraySet is an array-based implementation of the SimpleSet ADT. The purpose of this project was to
find and fix all errors present in the design.


DEBUGGING:

Roughly half the tests failed right off the bat, so I searched the error codes to find the source. I
didn't look for specific error codes- only which ones the tester failed. I found that the add method
was giving problems because of so many failed tests in that region, so I read the SimpleSet
documentation for what the method was supposed to do. I found that the variable rear was supposed to
give the size of the set. So when I went back to the add method, I saw the line setArray[rear] = element;
and realized that rear wasn't getting incremented in order to accommodate for the increase in size, so
I simply added rear++ after the line setArray[rear] = element; which cleared up over 90% of the errors.

Afterwards, I looked through the error codes and found that there were numerous NullPointerExceptions
thrown from the remove tests. Again, I read through the documentation, and also put a try/catch loop
around the while loop, and found that the rest of the errors and tests that couldn't be completed were
within that method. I placed lots of print statements in random places that printed out iterations of
the loop to figure out why it was giving NullPointerExceptions, because I thought that the i variable
was incrementing incorrectly, or that the loop was accessing a null element, but in the end, it didn't
matter, because the method was performing exactly as it should have been, as stated by the interface.
And so, after reading the documentation and what the tests were looking  for, I found that the tester
was specifically looking for the method to throw a NoSuchElementException if it got hung up, so I simply
put a try/catch loop around the while loop, and threw that NoSuchElementException. Only around 11 other
errors were causing trouble after this point.

The last thing I did within the remove method was to move the rear--; line from the second to last line
of the method to within the inside if loop, because I realized that it was initially in a place where
the rear variable would decrement regardless of whether the element had been removed or not. After moving
it to within the inside if loop (so that only when an element is removed, would the rear variable
decrement), all tests passed, and everything worked as intended.