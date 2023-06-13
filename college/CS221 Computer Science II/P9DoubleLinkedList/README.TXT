------------------------------------
PROJECT 9:	Double-Linked List
CLASS:		CS221
AUTHOR:		Nathaniel Weissinger
DATE:		November 20, 2020
------------------------------------

Overview:

The Doubly Linked List (DLL) is a linked data structure consisting of connected nodes, which allows linear traversal
and sequential altering. Within the class are the ListIterator and Iterator classes, which traverse the list
once the initial DLL is initialized. The ListTester class tests if all methods are proper implementations of
the initial interface by executing hundreds of scenarios to ensure optimal quality of the data structure.


INCLUDED FILES:
* ListTester.java - tests methods in IUDoubleLinkedList and reports failures
* IndexedUnsortedList.java - interface for the doubly linked list
* IUDoubleLinkedList.java - nodal list data structure, implemented from IndexedUnsortedList
* Node.java - base class for the DLL linked nodes
* README.txt - this file


Sources:
ListIterator:		https://docs.oracle.com/javase/8/docs/api/java/util/ListIterator.html
IndexedUnsortedList:	http://cs.boisestate.edu/~cs221/projects/DoubleLinkedList/files/IndexedUnsortedList.java


COMPILING AND RUNNING:

From the directory of the program, to compile on Onyx, type:
$ javac ListTester.java

This will compile the ListTester class before running.

To run the program, type:
$ java ListTester

This will run the tester class to ensure optimal quality of the DLL data structure


PROGRAM DESIGN AND IMPORTANT CONCEPTS:

IUDoubleLinkedList:
The design of the program centers around a doubly linked list- the list is linked to
nodes to its left and right, and the current node can traverse the list using the
next() and previous() methods. Variables are initialized within the list, accepting a
variety of inputs (String, integer, Object, etc), and can be evaluated/altered using the
ListIterator or Iterator subclasses. There are other methods, such as set(E) or addToRear(E)
that essentially do the same things, but place the elements in different locations.
There are other miscellanuous methods to ensure the program works correctly, such as
isEmpty(), or other checks such as contains(E), that look into the list and return
if elements are contained within it.

IndexedUnsortedList:
This is the interface that the IUDoubleLinkedList implements. It only holds the general
structure for the methods which are utilized by the list.

ListTester:
A program provided that tests the IUDoubleLinkedList methods by providing various inputs
and analyzing the methods' responses.



TESTING:

A significant portion of the testing was performed on the IUDoubleLinkedList class using
the ListTester class. A great portion of the DLL was created from prior projects throughout
the semester, and heavily utilized the code from the SingleLinkedList. However, this new
implementation required backwards traversal through the nodes, as well as an update of the
ListIterator and Iterator classes, so most of the testing involved ensuring the code was up
to par.

The main issues that popped up were the ListIterator implementation errors- having to create
the whole class from scratch, I had to run the tester program almost constantly in order to
double check each addition. Once the class had been created, most of the errors stemmed from the
Iterator class- since both the Iterator and ListIterator were almost identical in structure, I
focused solely on the Iterator class, and copied the code to the ListIterator to make sure both
classes utilized the same formulas.
I found out pretty early on that my next() and previous() classes were causing most of the errors,
so I had to double check how I had initialized all my variables and defined everything. After that,
it was a sequential troubleshooting fiasco of identifying every test's expected output, then
altering the program to handle it accordingly.

This took several hours, but after making sure every exception was thrown in the proper place,
and the implementations lined up with the design for the project, I was finally able to get rid of
most of the errors. A few ListIterator methods weren't working as properly as I would have hoped
though, and the tester shows the errors.


DISCUSSION:

This assignment was fairly tedious. Most of the errors were borne from very specific circumstances,
such as whether a specific exception should have been thrown in a certain situation, but I ended up
figuring most of it out after referencing the source material and altering the code with trial and error.
I wasn't able to complete everything by the time the deadline came.


RESULTS:


SCENARIO: newList

toString() output: []

Section Tests: 42,  Passed: 42,  Failed: 0
Tests Run So Far: 42,  Passed: 42 (100.0%),  Failed: 0

SCENARIO: emptyList_addToFrontA_A

toString() output: [1]
 NEXT: 1
 NEXT: 1
emptyList_addToFrontA_A_testListIterNextPreviousRemoveRemove	***FAIL***
 NEXT: 1
 NEXT: 1
emptyList_addToFrontA_A_testListIterNextPreviousSet	***FAIL***
 NEXT: 1
 NEXT: 1
 NEXT: 1
emptyList_addToFrontA_A_testListIter0NextPreviousSet	***FAIL***
emptyList_addToFrontA_A_testListIter1HasNext  	***FAIL***
emptyList_addToFrontA_A_testListIter1Next     	***FAIL***
emptyList_addToFrontA_A_testListIter1HasPrevious	***FAIL***
emptyList_addToFrontA_A_testListIter1Previous 	***FAIL***
***UNABLE TO RUN/COMPLETE emptyList_addToFrontA_A TESTS***

Section Tests: 87,  Passed: 80,  Failed: 7
Tests Run So Far: 129,  Passed: 122 (94.6%),  Failed: 7

SCENARIO: emptyList_addToRearA_A

toString() output: [1]
 NEXT: 1
 NEXT: 1
emptyList_addToRearA_A_testListIterNextPreviousRemoveRemove	***FAIL***
 NEXT: 1
 NEXT: 1
emptyList_addToRearA_A_testListIterNextPreviousSet	***FAIL***
 NEXT: 1
 NEXT: 1
 NEXT: 1
emptyList_addToRearA_A_testListIter0NextPreviousSet	***FAIL***
emptyList_addToRearA_A_testListIter1HasNext   	***FAIL***
emptyList_addToRearA_A_testListIter1Next      	***FAIL***
emptyList_addToRearA_A_testListIter1HasPrevious	***FAIL***
emptyList_addToRearA_A_testListIter1Previous  	***FAIL***
***UNABLE TO RUN/COMPLETE emptyList_addToRearA_A TESTS***

Section Tests: 87,  Passed: 80,  Failed: 7
Tests Run So Far: 216,  Passed: 202 (93.5%),  Failed: 14

SCENARIO: emptyList_addA_A

toString() output: [1]
 NEXT: 1
 NEXT: 1
emptyList_addA_A_testListIterNextPreviousRemoveRemove	***FAIL***
 NEXT: 1
 NEXT: 1
emptyList_addA_A_testListIterNextPreviousSet  	***FAIL***
 NEXT: 1
 NEXT: 1
 NEXT: 1
emptyList_addA_A_testListIter0NextPreviousSet 	***FAIL***
emptyList_addA_A_testListIter1HasNext         	***FAIL***
emptyList_addA_A_testListIter1Next            	***FAIL***
emptyList_addA_A_testListIter1HasPrevious     	***FAIL***
emptyList_addA_A_testListIter1Previous        	***FAIL***
***UNABLE TO RUN/COMPLETE emptyList_addA_A TESTS***

Section Tests: 87,  Passed: 80,  Failed: 7
Tests Run So Far: 303,  Passed: 282 (93.1%),  Failed: 21

SCENARIO: emptyList_add0A_A

toString() output: [1]
 NEXT: 1
 NEXT: 1
emptyList_add0A_A_testListIterNextPreviousRemoveRemove	***FAIL***
 NEXT: 1
 NEXT: 1
emptyList_add0A_A_testListIterNextPreviousSet 	***FAIL***
 NEXT: 1
 NEXT: 1
 NEXT: 1
emptyList_add0A_A_testListIter0NextPreviousSet	***FAIL***
emptyList_add0A_A_testListIter1HasNext        	***FAIL***
emptyList_add0A_A_testListIter1Next           	***FAIL***
emptyList_add0A_A_testListIter1HasPrevious    	***FAIL***
emptyList_add0A_A_testListIter1Previous       	***FAIL***
***UNABLE TO RUN/COMPLETE emptyList_add0A_A TESTS***

Section Tests: 87,  Passed: 80,  Failed: 7
Tests Run So Far: 390,  Passed: 362 (92.8%),  Failed: 28

SCENARIO: A_removeA_emptySet

toString() output: []

Section Tests: 42,  Passed: 42,  Failed: 0
Tests Run So Far: 432,  Passed: 404 (93.5%),  Failed: 28

SCENARIO: A_removeLast_emptySet

toString() output: []

Section Tests: 42,  Passed: 42,  Failed: 0
Tests Run So Far: 474,  Passed: 446 (94.1%),  Failed: 28

SCENARIO: A_remove0_emptySet

toString() output: []

Section Tests: 42,  Passed: 42,  Failed: 0
Tests Run So Far: 516,  Passed: 488 (94.6%),  Failed: 28

SCENARIO: A_addToFrontB_BA

toString() output: [2, 1]

Section Tests: 57,  Passed: 57,  Failed: 0
Tests Run So Far: 573,  Passed: 545 (95.1%),  Failed: 28

SCENARIO: B_addToRearA_BA

toString() output: [2, 1]

Section Tests: 57,  Passed: 57,  Failed: 0
Tests Run So Far: 630,  Passed: 602 (95.6%),  Failed: 28

SCENARIO: B_add1A_BA

toString() output: [2, 1]

Section Tests: 57,  Passed: 57,  Failed: 0
Tests Run So Far: 687,  Passed: 659 (95.9%),  Failed: 28

SCENARIO: B_addA_BA

toString() output: [2, 1]

Section Tests: 57,  Passed: 57,  Failed: 0
Tests Run So Far: 744,  Passed: 716 (96.2%),  Failed: 28

SCENARIO: B_addAfterA_B_BA

toString() output: [2, 1]

Section Tests: 57,  Passed: 57,  Failed: 0
Tests Run So Far: 801,  Passed: 773 (96.5%),  Failed: 28

SCENARIO: A_set0B_B

toString() output: [2]
 NEXT: 2
 NEXT: 2
A_set0B_B_testListIterNextPreviousRemoveRemove	***FAIL***
 NEXT: 2
 NEXT: 2
A_set0B_B_testListIterNextPreviousSet         	***FAIL***
 NEXT: 2
 NEXT: 2
 NEXT: 2
A_set0B_B_testListIter0NextPreviousSet        	***FAIL***
A_set0B_B_testListIter1HasNext                	***FAIL***
A_set0B_B_testListIter1Next                   	***FAIL***
A_set0B_B_testListIter1HasPrevious            	***FAIL***
A_set0B_B_testListIter1Previous               	***FAIL***
***UNABLE TO RUN/COMPLETE A_set0B_B TESTS***

Section Tests: 87,  Passed: 80,  Failed: 7
Tests Run So Far: 888,  Passed: 853 (96.1%),  Failed: 35

SCENARIO: BA_remove1_B

toString() output: [2]
 NEXT: 2
 NEXT: 2
BA_remove1_B_testListIterNextPreviousRemoveRemove	***FAIL***
 NEXT: 2
 NEXT: 2
BA_remove1_B_testListIterNextPreviousSet      	***FAIL***
 NEXT: 2
 NEXT: 2
 NEXT: 2
BA_remove1_B_testListIter0NextPreviousSet     	***FAIL***
BA_remove1_B_testListIter1HasNext             	***FAIL***
BA_remove1_B_testListIter1Next                	***FAIL***
BA_remove1_B_testListIter1HasPrevious         	***FAIL***
BA_remove1_B_testListIter1Previous            	***FAIL***
***UNABLE TO RUN/COMPLETE BA_remove1_B TESTS***

Section Tests: 87,  Passed: 80,  Failed: 7
Tests Run So Far: 975,  Passed: 933 (95.7%),  Failed: 42

SCENARIO: emptyList_addToFrontA_A

toString() output: [1]
 NEXT: 1
 NEXT: 1
emptyList_addToFrontA_A_testListIterNextPreviousRemoveRemove	***FAIL***
 NEXT: 1
 NEXT: 1
emptyList_addToFrontA_A_testListIterNextPreviousSet	***FAIL***
 NEXT: 1
 NEXT: 1
 NEXT: 1
emptyList_addToFrontA_A_testListIter0NextPreviousSet	***FAIL***
emptyList_addToFrontA_A_testListIter1HasNext  	***FAIL***
emptyList_addToFrontA_A_testListIter1Next     	***FAIL***
emptyList_addToFrontA_A_testListIter1HasPrevious	***FAIL***
emptyList_addToFrontA_A_testListIter1Previous 	***FAIL***
***UNABLE TO RUN/COMPLETE emptyList_addToFrontA_A TESTS***

Section Tests: 87,  Passed: 80,  Failed: 7
Tests Run So Far: 1062,  Passed: 1013 (95.4%),  Failed: 49

SCENARIO: CA_set0B_BA

toString() output: [2, 1]

Section Tests: 57,  Passed: 57,  Failed: 0
Tests Run So Far: 1119,  Passed: 1070 (95.6%),  Failed: 49

SCENARIO: BAC_removeLast_BA

toString() output: [2, 1]

Section Tests: 57,  Passed: 57,  Failed: 0
Tests Run So Far: 1176,  Passed: 1127 (95.8%),  Failed: 49

SCENARIO: ADC_set1B_ABC

toString() output: [1, 2, 3]

Section Tests: 71,  Passed: 71,  Failed: 0
Tests Run So Far: 1247,  Passed: 1198 (96.1%),  Failed: 49

SCENARIO: AC_addAfterBA_ABC

toString() output: [1, 2, 3]

Section Tests: 71,  Passed: 71,  Failed: 0
Tests Run So Far: 1318,  Passed: 1269 (96.3%),  Failed: 49

SCENARIO: ABCD_removeD_ABC

toString() output: [1, 2, 3]

Section Tests: 71,  Passed: 71,  Failed: 0
Tests Run So Far: 1389,  Passed: 1340 (96.5%),  Failed: 49

SCENARIO: BC_add0A_ABC

toString() output: [1, 2, 3]

Section Tests: 71,  Passed: 71,  Failed: 0
Tests Run So Far: 1460,  Passed: 1411 (96.6%),  Failed: 49

SCENARIO: AB_addToRearC_ABC

toString() output: [1, 2, 3]

Section Tests: 71,  Passed: 71,  Failed: 0
Tests Run So Far: 1531,  Passed: 1482 (96.8%),  Failed: 49

SCENARIO: BC_addToFrontA_ABC

toString() output: [1, 2, 3]

Section Tests: 71,  Passed: 71,  Failed: 0
Tests Run So Far: 1602,  Passed: 1553 (96.9%),  Failed: 49

Iterator Concurrency Tests

A_iter1NextRemove_testIter2HasNext            	***FAIL***
A_removeFirst_testIterHasNextConcurrent       	***FAIL***
A_removeLast_testIterHasNextConcurrent        	***FAIL***
A_removeA_testIterHasNextConcurrent           	***FAIL***
A_addToFrontB_testIterHasNextConcurrent       	***FAIL***
A_addToRearB_testIterHasNextConcurrent        	***FAIL***
A_addAfterAB_testIterHasNextConcurrent        	***FAIL***
A_add0B_testIterHasNextConcurrent             	***FAIL***
A_set0B_testIterHasNextConcurrent             	***FAIL***
A_addB_testIterHasNextConcurrent              	***FAIL***
A_remove0_testIterHasNextConcurrent           	***FAIL***

Section Tests: 67,  Passed: 56,  Failed: 11
Tests Run So Far: 1669,  Passed: 1609 (96.4%),  Failed: 60

ListIterator Concurrency Tests

emptyList_ListIter1AddA_testListIter2NextIndex	***FAIL***
emptyList_ListIter1AddA_testListIter2PreviousIndex	***FAIL***
***UNABLE TO RUN/COMPLETE test_ListIterConcurrency***

Section Tests: 56,  Passed: 54,  Failed: 2
Tests Run So Far: 1725,  Passed: 1663 (96.4%),  Failed: 62
-----------------------------------------------------------

Total Tests Run: 1725,  Passed: 1663 (96.4%),  Failed: 62