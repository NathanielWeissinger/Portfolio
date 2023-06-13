P4: Analysis of Algorithms
Nathaniel Weissinger
10/02/2020


OBJECTIVE:
Defend all answers based on specific references to the code.
Do not count return statements or initialization of method arguments.
You are strongly encouraged to walk through algorithms in the debugger and to add
statement-counting code to given methods to test and refine your analysis.
All growth functions must be in simplified t(n) = ____ format and order must be
presented in proper big-O notation.



ALGORITHM: find()
Q: Minimum Statements. How many statements would be executed in a call to find()
when the array size is zero (n == 0)?

A: Within the for loop inside the method, integer i is initialized to equal 0;
then, it compares the value to see if it’s less than array.length, which is zero.
At this point, since the comparison returns false, the for loop ends, meaning
only two statements were executed.
T(0) = 2


Q: Best Case Scenario. Under what conditions would the minimum possible number
of loop iterations be executed for an array where n is large?
Where would the target element be located in the array?
What is the growth function under these conditions?

A: The minimum iterations of the loop would be if the target value were to be
found at index 0, and in this case, the loop would only run through once,
regardless of array size. This is because the if loop within the for loop will
return the index (in turn, exiting the loop) once the value in question is found
at array[0]. Under those conditions, the growth rate is O(1), since there is only
that one iteration, with a total of 3 statements. i++ would not be executed.
T(n) = 3(1)


Q: Worst Case Scenario. Under what conditions would the maximum number of loop
iterations be executed for an array where n is large?
What would be necessary such that the loop cannot exit early?
What is the growth function under these conditions?

A: The maximum number of loop iterations would execute (and consequently, the
only way it couldn’t exit early) if the value isn’t found in the array, meaning
it would be looped through n times with a growth rate of O(n). If the value wasn’t
found in the array, the for loop would execute 3 statements per loop:
i<array.length, array[i] == value, and i++, in addition to the int i initialization
on the first iteration, and one additional i<array.length comparison to exit the loop.
T(n) = 3n+2


Q: Expected Average Case Scenario. Assuming a randomly ordered array of unique
elements and the target element is in the array, where would a target element be
located on average?
What is the expected average number of loop iterations for a call to find()?
What is the average growth function under these conditions?

A: Assuming normal distribution, on average, an element will be found approximately
halfway through the array, plus or minus a standard deviation σ. This means the
expected average iterations would be T(n) = n/2, but the exact average growth
function of loop iterations would be:
T(n) = n/2 ± σ(n/2)   (where σ is a number between 0 and 0.5 that reflects a certain
percentage away from the mean based on the normal distribution model)
The total amount of statements is:
T(n) = 3[n/2 ± σ(n/2)] + 2


Q: What is the runtime order (big-O) of find() based on the above growth functions?

A: The runtime order is O(n), because n is the maximum amount of times that the
loop will iterate.



ALGORITHM: replaceAll()
Q: Minimum Statements. How many statements would be executed in a call to
replaceAll() when the array size is zero (n == 0)?

A: The first statement executed would be the initialization of index, so including
the amount of statements in the find() method (2 in the for loop), there are 3
statements executed before the while loop inside the replaceAll() method. Since
the find() method will return -1, the statement in the while loop index > -1 will
immediately exit the loop, meaning there are 4 statements total.
T(0) = 4


Q: Best Case Scenario. Under what conditions would the minimum number of replaceAll()
loop iterations be executed for an array where n is large?
What would cause the replaceAll() loop to never iterate even if n is large?
What is the cost of the find() call(s) under these conditions?
What is the total growth function under these conditions?

A: The best case scenario for this method would be if the value specified couldn’t be
found, and the find() function returned -1 for the index. This is because no matter what,
the replaceAll() method will run through the entirety of the array at least once to
try to find the value specified, so the best case would be if it wasn’t found at all-
that way, it wouldn’t have to go through the while loop in the replaceAll() method and
go through the array more times.
Unfortunately, the best case cost for loop iterations in this method is the same as the
worst case for the find() method, but added by 2 more to include the index initialization
and the index > -1 comparison in the while loop:
T(n) = 3n+4
Meaning it has a Big-O of O(n) at minimum.


Q: Worst Case Scenario. Assuming newValue and oldValue are not equal, under what
conditions would the maximum number of replaceAll() loop iterations be executed for an
array where n is large? Note that every call to find() inside the replaceAll() loop is
guaranteed to iterate a different number of times, so what would the average number of
find() loop iterations be?
What is the total growth function under these conditions?

A: The worst case scenario for the method would be if every element in the array held
the value needing to be changed. Each time the find() method is called, it would iterate
through one more loop than the previous time, making a summation equal to n(n+1)/2 loops.
The Big-O notation would be O(n^2). The number of statements would be n(n+1)/2 with 3
statements per find() method and 3 statements per replaceAll() method, each with 2
additional statements that happen before and after the loop.
T(n) = 2 + [(3n+2)((3n+2)+1)]/2 => 2 + [(3n+2)(3n+3)]/2


Q: Expected Average Case Scenario. Assuming a randomly ordered array of unique elements
and oldValue is a value in the array, how many replaceAll() loop iterations will occur?
How many loop iterations in calls to find()?
What is the expected average growth function for a call to replaceAll()?

A: Assuming there would only be one oldValue in the array, replaceAll() should only go
through 1 iteration in its while loop, meaning that the find() method will be called
twice- first in its initialization of index, and the second within the while loop.
That second iteration will return -1 if there was only 1 value within the array that
matched oldValue, but to calculate the growth function, let’s use variable a as the
number of values that match oldValue in the array. This means that the same growth
function from the find() method can be used, but just multiplied by the variable a, and
also multiplied by 3 to account for the 3 statements per loop. The whole function then
needs to be added by 3n to indicate the one last time the while loop runs through the
find() method, only for it to return -1, then added by 2 to account for the
initialization of index and the comparison index > -1 inside the while loop:
T(n) = a{ 3[n/2 ± σ(n/2)] +2 } + 3n +2  (where σ is a number between 0 and 0.5 that
reflects a certain percentage away from the mean based on the normal distribution model,
and a is the number of times value is found in the array)


Q: What is the runtime order (big-O) of replaceAll() based on the above growth functions?

A: The growth function maximum is 3n^2+3n, meaning the Big-O runtime would be O(n^2).



ALGORITHM: sortIt()
Q: Minimum Statements. How many statements would be executed in a call to sortIt() when
the array size is zero (n == 0) or one (n == 1)?

A: If the array size is 0 or 1, the for loop will only execute two commands- the
initialization of next = 1, and the comparison next < array.length. Once that comparison
returns false, the for loop will end, and then there are no other statements.
T(0) = 2


Q: Best Case Scenario. The sortIt() outer loop depends only on n, but the inner loop is
sensitive to the ordering of elements in the array and the current index of the outer loop.
Under what conditions would the minimum number of inner loop iterations occur when n is large?
What is the growth function under these conditions?

A: In order for the least amount of inner loops to occur, the conditions for the while loop
must not be met. In this case, the value variable needs to be greater than array[index-1]
for every iteration, meaning that the list is already sorted. Therefore, the least amount
of times that the loops would execute would just be iterating through the for loop once,
or n times. Every time the loop iterates, there are 6 statements that the loop performs:
next<array.length, initialization of value and index, the while loop condition check,
array[index]=value, and next++. Before the for loop starts, next is initialized, and right
before the loop ends, it checks the condition next < array.length once more, meaning there
are 2 additional statements. The total growth function under these conditions is:
T(n) = 6n + 2


Q: Worst Case Scenario. The sortIt() outer loop depends only on n, but the inner loop is
sensitive to the ordering of elements in the array and the current index of the outer loop.
Under what conditions would the maximum number of inner loop iterations occur for an array
where n is large?
What is the average number of inner loop iterations per outer loop iteration?
What is the growth function under these conditions?

A: The maximum times the loop would iterate would be if the list were sorted in reverse order.
Because of how the while loop is structured, it will start at index 1, move the previous
index to the current index, and decrement the index number, essentially moving backwards
along the array. In this worst case scenario, the loop will move to the beginning every
single time, and the while loop will always execute at least once. Once it reaches index 0,
the condition index>0 in the while loop will be false, and then the value will be placed at
index=0. Therefore, the loops will iterate n(n-1)/2 times, with the minimum n value being 2
so that the first for loop will execute at least once. It’s subtracted by 1 because in both
loops, the index at 0 is not an iteration; thus we take the formula n(n+1)/2 and replace n
with n-1, making the formula: [(n-1)((n-1)+1)]/2 => n(n-1)/2. This formula was proved after
testing a few arrays ordered in reverse.
With each of the for loop iterations, there are 5 statements, with 2 more added to account
for the initialization of next and the condition check on the last iteration next<array.length.
With each of the while loop iterations, there is one condition check per for loop, and two
statements per loop, plus one condition check for when the conditions aren’t met. The equation
for the outside for loop is 5n+2, and the inside while loop is 3n+1. Substituting these
together into the formula n(n-1)/2 (with n-1 being the iterations for the outside for loop),
we get a growth formula of:
T(n) = [((5n+2)-1)(3n+1)]/2 => [(5n+1)(3n+1)]/2

SIDE NOTE: Within the while loop, there are technically two condition checks: index > 0, and
value < array[index-1]. However, I count this as one statement, because in one line, you
can set a variable to equal hundreds of variables and conditions, and it would still be
considered one statement. Take a bitwise logical operator for example- if every 0 and 1
comparison between each number was compared and counted as its own statement, we would have
possibly hundreds of ‘statements’ per line of code. We’d have to analyze statements by the
machine code, which is completely out of the question. Even though there are multiple condition
checks, this is only one line of code, and therefore one statement.


Q: Expected Average Case Scenario. Assuming a random array of unique elements, what is the
expected average number of inner loop iterations per outer loop iteration?
How does it compare to the worst case?
What is the growth function under these conditions?

A: This is quite a bit trickier to model. The average number of while loop iterations per
for loop iteration would be dependent on the position within the for loop, but within each
iteration, the maximum number of times the while loop can iterate would be n times, assuming
it’s at the last element in the for loop, and the last element is the smallest element in the
array, meaning the index would have to go all the way back to the beginning of the array in
order to place the element. But since this only can happen at the end, the average would be n/2.
However, that average also assumes that the entire list is in reverse order- some elements might
not even go through the while loop, because they are already in their correct positions. So, as
a fair generalization, dividing this value by 2 again (n/4) should give a relatively accurate
assumption for modeling the while loop.
Assuming a random distribution of elements, the outside for loop will still have to go through
every element except the first, so we can add (n-1) to the growth. Putting the two together,
and substituting the previous values for statements per loop iteration into this formula, the
growth function then can be defined as:
T(n) = [(5n+1)(3n+1)]/8


Q: What is the runtime order (big-O) of sortIt() based on the above growth functions?

A: The maximum value for the growth function is 15n^2, meaning that the Big-O runtime would be
O(n^2).