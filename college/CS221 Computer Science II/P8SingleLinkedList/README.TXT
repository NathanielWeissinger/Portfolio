P8: SingleLinkedList
Nathaniel Weissinger
11/05/2020


OVERVIEW:
Test all change scenarios defined in the previous projects (P5ListTesting and
P6ListTesting2) using a LinkedList-based implementation of IndexUnsortedList.
A LinkedList uses Nodes, and with a SingleLinkedList, nodes are unidirectional
and can only link with the node in front of itself.


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

SCENARIO: emptyList_addA_A

toString() output: [1]

Section Tests: 44,  Passed: 44,  Failed: 0
Tests Run So Far: 162,  Passed: 162 (100.0%),  Failed: 0

SCENARIO: emptyList_add0A_A

toString() output: [1]

Section Tests: 44,  Passed: 44,  Failed: 0
Tests Run So Far: 206,  Passed: 206 (100.0%),  Failed: 0

SCENARIO: A_removeA_emptySet

toString() output: []

Section Tests: 30,  Passed: 30,  Failed: 0
Tests Run So Far: 236,  Passed: 236 (100.0%),  Failed: 0

SCENARIO: A_removeLast_emptySet

toString() output: []

Section Tests: 30,  Passed: 30,  Failed: 0
Tests Run So Far: 266,  Passed: 266 (100.0%),  Failed: 0

SCENARIO: A_remove0_emptySet

toString() output: []

Section Tests: 30,  Passed: 30,  Failed: 0
Tests Run So Far: 296,  Passed: 296 (100.0%),  Failed: 0

SCENARIO: A_addToFrontB_BA

toString() output: [2, 1]

Section Tests: 58,  Passed: 58,  Failed: 0
Tests Run So Far: 354,  Passed: 354 (100.0%),  Failed: 0

SCENARIO: B_addToRearA_BA

toString() output: [2, 1]

Section Tests: 58,  Passed: 58,  Failed: 0
Tests Run So Far: 412,  Passed: 412 (100.0%),  Failed: 0

SCENARIO: B_add1A_BA

toString() output: [2, 1]

Section Tests: 58,  Passed: 58,  Failed: 0
Tests Run So Far: 470,  Passed: 470 (100.0%),  Failed: 0

SCENARIO: B_addA_BA

toString() output: [2, 1]

Section Tests: 58,  Passed: 58,  Failed: 0
Tests Run So Far: 528,  Passed: 528 (100.0%),  Failed: 0

SCENARIO: B_addAfterA_B_BA

toString() output: [2, 1]

Section Tests: 58,  Passed: 58,  Failed: 0
Tests Run So Far: 586,  Passed: 586 (100.0%),  Failed: 0

SCENARIO: A_set0B_B

toString() output: [2]

Section Tests: 44,  Passed: 44,  Failed: 0
Tests Run So Far: 630,  Passed: 630 (100.0%),  Failed: 0

SCENARIO: BA_remove1_B

toString() output: [2]

Section Tests: 44,  Passed: 44,  Failed: 0
Tests Run So Far: 674,  Passed: 674 (100.0%),  Failed: 0

SCENARIO: emptyList_addToFrontA_A

toString() output: [1]

Section Tests: 44,  Passed: 44,  Failed: 0
Tests Run So Far: 718,  Passed: 718 (100.0%),  Failed: 0

SCENARIO: CA_set0B_BA

toString() output: [2, 1]

Section Tests: 58,  Passed: 58,  Failed: 0
Tests Run So Far: 776,  Passed: 776 (100.0%),  Failed: 0

SCENARIO: BAC_removeLast_BA

toString() output: [2, 1]

Section Tests: 58,  Passed: 58,  Failed: 0
Tests Run So Far: 834,  Passed: 834 (100.0%),  Failed: 0

SCENARIO: ADC_set1B_ABC

toString() output: [1, 2, 3]

Section Tests: 72,  Passed: 72,  Failed: 0
Tests Run So Far: 906,  Passed: 906 (100.0%),  Failed: 0

SCENARIO: AC_addAfterBA_ABC

toString() output: [1, 2, 3]

Section Tests: 72,  Passed: 72,  Failed: 0
Tests Run So Far: 978,  Passed: 978 (100.0%),  Failed: 0

SCENARIO: ABCD_removeD_ABC

toString() output: [1, 2, 3]

Section Tests: 72,  Passed: 72,  Failed: 0
Tests Run So Far: 1050,  Passed: 1050 (100.0%),  Failed: 0

SCENARIO: BC_add0A_ABC

toString() output: [1, 2, 3]

Section Tests: 72,  Passed: 72,  Failed: 0
Tests Run So Far: 1122,  Passed: 1122 (100.0%),  Failed: 0

SCENARIO: AB_addToRearC_ABC

toString() output: [1, 2, 3]

Section Tests: 72,  Passed: 72,  Failed: 0
Tests Run So Far: 1194,  Passed: 1194 (100.0%),  Failed: 0

SCENARIO: BC_addToFrontA_ABC

toString() output: [1, 2, 3]

Section Tests: 72,  Passed: 72,  Failed: 0
Tests Run So Far: 1266,  Passed: 1266 (100.0%),  Failed: 0

Iterator Concurrency Tests


Section Tests: 67,  Passed: 67,  Failed: 0
Tests Run So Far: 1333,  Passed: 1333 (100.0%),  Failed: 0
-----------------------------------------------------------

Total Tests Run: 1333,  Passed: 1333 (100.0%),  Failed: 0