P7: Test Results for an ArrayList
Nathaniel Weissinger
10/23/2020


OVERVIEW:
Test all change scenarios defined in the previous projects (P5ListTesting and
P6ListTesting2) using an Array-based implementation of IndexUnsortedList.
Iterator and ListIterator now have support.


COMPILING AND RUNNING:

From the directory of the program, to compile on Onyx, type:
$ javac ListTester.java

To run the programs, type:
$ java ListTester


RESULTS:

SCENARIO: newList

toString() output: []

Section Tests: 30,  Passed: 30,  Failed: 0
Tests Run So Far: 30,  Passed: 30 (100.0%),  Failed: 0

SCENARIO: emptyList_addToFrontA_A

toString() output: [1]

Section Tests: 44,  Passed: 44,  Failed: 0
Tests Run So Far: 74,  Passed: 74 (100.0%),  Failed: 0

SCENARIO: emptyList_addToRearA_A

toString() output: [1]

Section Tests: 44,  Passed: 44,  Failed: 0
Tests Run So Far: 118,  Passed: 118 (100.0%),  Failed: 0

SCENARIO: A_removeA_emptySet

toString() output: []

Section Tests: 30,  Passed: 30,  Failed: 0
Tests Run So Far: 148,  Passed: 148 (100.0%),  Failed: 0

SCENARIO: A_removeLast_emptySet

toString() output: []

Section Tests: 30,  Passed: 30,  Failed: 0
Tests Run So Far: 178,  Passed: 178 (100.0%),  Failed: 0

SCENARIO: A_remove0_emptySet

toString() output: []

Section Tests: 30,  Passed: 30,  Failed: 0
Tests Run So Far: 208,  Passed: 208 (100.0%),  Failed: 0

SCENARIO: A_addToFrontB_BA

toString() output: [2, 1]

Section Tests: 58,  Passed: 58,  Failed: 0
Tests Run So Far: 266,  Passed: 266 (100.0%),  Failed: 0

SCENARIO: B_addA_BA

toString() output: [2, 1]

Section Tests: 58,  Passed: 58,  Failed: 0
Tests Run So Far: 324,  Passed: 324 (100.0%),  Failed: 0

SCENARIO: B_addAfterA_B_BA

toString() output: [2, 1]

Section Tests: 58,  Passed: 58,  Failed: 0
Tests Run So Far: 382,  Passed: 382 (100.0%),  Failed: 0

SCENARIO: A_set0B_B

toString() output: [2]

Section Tests: 44,  Passed: 44,  Failed: 0
Tests Run So Far: 426,  Passed: 426 (100.0%),  Failed: 0

SCENARIO: BA_remove1_B

toString() output: [2]

Section Tests: 44,  Passed: 44,  Failed: 0
Tests Run So Far: 470,  Passed: 470 (100.0%),  Failed: 0

SCENARIO: emptyList_addToFrontA_A

toString() output: [1]

Section Tests: 44,  Passed: 44,  Failed: 0
Tests Run So Far: 514,  Passed: 514 (100.0%),  Failed: 0

SCENARIO: CA_set0B_BA

toString() output: [2, 1]

Section Tests: 58,  Passed: 58,  Failed: 0
Tests Run So Far: 572,  Passed: 572 (100.0%),  Failed: 0

SCENARIO: BAC_removeLast_BA

toString() output: [2, 1]

Section Tests: 58,  Passed: 58,  Failed: 0
Tests Run So Far: 630,  Passed: 630 (100.0%),  Failed: 0

SCENARIO: ADC_set1B_ABC

toString() output: [1, 2, 3]

Section Tests: 72,  Passed: 72,  Failed: 0
Tests Run So Far: 702,  Passed: 702 (100.0%),  Failed: 0

SCENARIO: AC_addAfterBA_ABC

toString() output: [1, 2, 3]

Section Tests: 72,  Passed: 72,  Failed: 0
Tests Run So Far: 774,  Passed: 774 (100.0%),  Failed: 0

SCENARIO: ABCD_removeD_ABC

toString() output: [1, 2, 3]

Section Tests: 72,  Passed: 72,  Failed: 0
Tests Run So Far: 846,  Passed: 846 (100.0%),  Failed: 0
---------------------------------------------------------

Total Tests Run: 846,  Passed: 846 (100.0%),  Failed: 0