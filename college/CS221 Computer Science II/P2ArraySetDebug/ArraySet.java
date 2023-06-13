import java.util.Arrays;
import java.util.NoSuchElementException;

/**
 * An array-based implementation of the SimpleSet interface.
 * 
 * @param <T> type to store in the set
 * 
 * @author mvail
 */
public class ArraySet<T> implements SimpleSet<T> {
    private static final int DEFAULT_CAPACITY = 3;
    private T[] setArray; //holds current elements of the set in consecutive indexes beginning with 0
    private int rear; //the next open index where a new element could be added, also the size of the set

    /**
     * Constructor - initializes new set for use
     */
    public ArraySet() {
        this(DEFAULT_CAPACITY);
    }
    
    /**
     * Constructor - initializes new set for use
     * @param initialCapacity specifies expected maximum capacity needed by the set
     */
    @SuppressWarnings("unchecked")
    public ArraySet(int initialCapacity) {
        this.setArray = (T[]) new Object[initialCapacity];
        this.rear = 0;
    }

    /**
     * Reports the number of elements in the set.
     * @return the number of elements in the set
     */
    @Override
    public int size() {
        return rear;
    }

    /**
     * Determines if the set is empty (i.e. contains no elements).
     * @return true if the set is empty, else false
     */
    @Override
    public boolean isEmpty() {
        System.out.println(rear>0);
        try{
            return !(rear > 0);}
        catch(Exception e){return true;}
    }

    /**
     * Determines if the given element is present in the set.
     * @param element the element to find
     * @return true if the element is in the set, else false
     */
    @Override
    public boolean contains(T element) {
        for (int i = 0; i < rear; i++) {
            if (setArray[i].equals(element)) {
                return true;
            }
        }
        return false;
    }

    /**
     * Adds the given element to the set, if it is not already present.
     * @param element the element to add
     */
    @Override
    public void add(T element) {
        if (!contains(element)) {
            if (rear >= setArray.length) {
                expandCapacity();
            }          
            setArray[rear] = element;
            rear++; //If an element were added, rear needs to be incremented
                    //to accurately show how large the array is
        }
    }

    /**
     * Removes the given element from the set, if present. Throws an exception if the element is not in the set. 
     * @param element element to remove
     * @return the removed element
     * @throws NoSuchElementException if element is not contained in the set
     */
    @Override
    public T remove(T element) {
        T retVal = null;
        int i=0;
        try{
            while (retVal == null && i < rear) {
                if (setArray[i].equals(element)) {
                    retVal = setArray[i];
                    
                    //shift all following elements one space forward
                    //so there are no gaps in the array
                    rear--;  //moved from the end of the method to here, that way
                             //rear would only decrement if the element were removed.
                    while (i < rear) {
                        setArray[i] = setArray[i+1];
                        i++;
                    }
                }
                i++;
            }
            if (retVal == null) {
                throw new NoSuchElementException("ArraySet");
            }
        }
        catch(Exception e)
        {
            throw new NoSuchElementException("ArraySet");
            //Throws correct exception
        }
        
        return retVal;
    }

    /* (non-Javadoc)
     * @see java.lang.Object#toString()
     */
    public String toString() {
        StringBuilder str = new StringBuilder();
        str.append("[");
        for (int i = 0; i < rear; i++) {
            str.append(setArray[i]);
            str.append(", ");
        }
        if (rear > 0) {
            str.delete(str.length()-2, str.length()); //drop trailing ", "
        }
        str.append("]");
        return str.toString();
    }
    
    /**
     * Doubles the capacity of setArray
     */
    private void expandCapacity() {
        setArray = Arrays.copyOf(setArray, setArray.length * 2);
    }
}

