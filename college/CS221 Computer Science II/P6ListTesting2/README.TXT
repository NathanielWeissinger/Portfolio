P6: Test Results for an IndexedUnsortedList
Nathaniel Weissinger
10/15/2020


OVERVIEW:
Test at least 21 change scenarios defined in the previous project (P5ListTesting).
NOTE: The Iterator and ListIterator have not been implemented, and are supposed to
fail in the Iterator Concurrency Tests.


COMPILING AND RUNNING:

From the directory of the program, to compile on Onyx, type:
$ javac ListTester.java

To run the programs, type:
$ java ListTester


RESULTS:

SCENARIO: newList

toString() output: []

Section Tests: 29,  Passed: 29,  Failed: 0
Tests Run So Far: 29,  Passed: 29 (100.0%),  Failed: 0

SCENARIO: emptyList_addToFrontA_A

toString() output: [1]

Section Tests: 43,  Passed: 43,  Failed: 0
Tests Run So Far: 72,  Passed: 72 (100.0%),  Failed: 0

SCENARIO: A_removeA_emptySet

toString() output: []

Section Tests: 29,  Passed: 29,  Failed: 0
Tests Run So Far: 101,  Passed: 101 (100.0%),  Failed: 0

SCENARIO: A_addToFrontB_BA

toString() output: [2, 1]

Section Tests: 41,  Passed: 41,  Failed: 0
Tests Run So Far: 142,  Passed: 142 (100.0%),  Failed: 0

SCENARIO: B_addA_BA

toString() output: [2, 1]

Section Tests: 41,  Passed: 41,  Failed: 0
Tests Run So Far: 183,  Passed: 183 (100.0%),  Failed: 0

SCENARIO: B_addAfterA_B_BA

toString() output: [2, 1]

Section Tests: 41,  Passed: 41,  Failed: 0
Tests Run So Far: 224,  Passed: 224 (100.0%),  Failed: 0

SCENARIO: BA_remove1_B

toString() output: [2]

Section Tests: 43,  Passed: 43,  Failed: 0
Tests Run So Far: 267,  Passed: 267 (100.0%),  Failed: 0

SCENARIO: emptyList_addToFrontA_A

toString() output: [1]

Section Tests: 43,  Passed: 43,  Failed: 0
Tests Run So Far: 310,  Passed: 310 (100.0%),  Failed: 0

SCENARIO: CA_set0B_BA

toString() output: [2, 1]

Section Tests: 41,  Passed: 41,  Failed: 0
Tests Run So Far: 351,  Passed: 351 (100.0%),  Failed: 0

SCENARIO: BAC_removeLast_BA

toString() output: [2, 1]

Section Tests: 41,  Passed: 41,  Failed: 0
Tests Run So Far: 392,  Passed: 392 (100.0%),  Failed: 0

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
A_set0B_testIterNextConcurrent                	***FAIL***
A_set0B_testIterRemoveConcurrent              	***FAIL***
A_addB_testIterHasNextConcurrent              	***FAIL***
A_remove0_testIterHasNextConcurrent           	***FAIL***

Section Tests: 67,  Passed: 54,  Failed: 13
Tests Run So Far: 459,  Passed: 446 (97.2%),  Failed: 13
---------------------------------------------------------

Total Tests Run: 459,  Passed: 446 (97.2%),  Failed: 13