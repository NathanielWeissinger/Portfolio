import java.util.*;
import java.lang.*;

/**
 * Array-based implementation of IndexedUnsortedList.
 * An Iterator with working remove() method is implemented, but
 * ListIterator is unsupported. 
 * 
 * @author 
 *
 * @param <T> type to store
 */
public class IUArrayList<T> implements IndexedUnsortedList<T> {
    private static int DEFAULT_CAPACITY = 10;
    private static final int NOT_FOUND = -1;
    
    private T[] array;
    private int rear;
    private int modCount;
    
    /** Creates an empty list with default initial capacity */
    public IUArrayList() {
        this(DEFAULT_CAPACITY);
    }
    
    /** 
     * Creates an empty list with the given initial capacity
     * @param initialCapacity
     */
    @SuppressWarnings("unchecked")
    public IUArrayList(int initialCapacity) {
        DEFAULT_CAPACITY = initialCapacity;
        array = (T[])(new Object[initialCapacity]);
        rear = 0;
        modCount = 0;
    }
    
    /** Double the capacity of array */
    private void expandCapacity() {
        if(rear % DEFAULT_CAPACITY == 0 && rear != 0)
        { //tests to see if the list is at max capacity first before increasing size
            array = Arrays.copyOf(array, array.length*2);
        }
    }

    /** Adds element to the front of the array */
    @Override
    public void addToFront(T element) {
        // TODO 
        T[] tempArray = array;
        expandCapacity();
        if(rear>0)
        {
            for(int i=1; i<=rear; i++)
            { //shifts array
                array[i] = tempArray[i-1];
            }
        }
            
        array[0] = element;
        rear++;
        modCount++;
    }

    /** Adds element to the back of the array */
    @Override
    public void addToRear(T element) {
        // TODO 
        expandCapacity();
        array[rear] = element; //sets element on 1+ last element index
        rear++;
        modCount++;
    }

    /** Adds element to the back of the array */
    @Override
    public void add(T element) {
        // TODO 
        this.addToRear(element);
    }

    /** Adds element after a specified target element */
    @Override
    public void addAfter(T element, T target) {
        // TODO
        try{
        int index = NOT_FOUND;
        T[] tempArray = array;
        T temp = array[rear-1];
        boolean found = false;
        for(int i=0; i<rear; i++)
        {
            if(array[i].equals(target) && !found)
            { //finds index of target element
                index = i;
                found = true;
                expandCapacity();
            }
            if(found && i>0)
            { //shifts the rest of the array
                array[i] = tempArray[i-1];
            }
        }
        if(found)
        { //after array is shifted, the element is placed after the target
            array[rear] = temp;
            array[index+1] = element;
            rear++;
            modCount++;
        }
        else
            throw new NoSuchElementException();}catch(Exception e){throw new NoSuchElementException();}
    }

    /** Inserts element at a specified index */
    @Override
    public void add(int index, T element) {
        // TODO 
        if(index<0 || index>rear)
            throw new IndexOutOfBoundsException();
            
        T[] tempArray = array;
        expandCapacity();
        for(int i=index; i<rear; i++)
        {
            if(i>0)
            { //shifts array
                array[i] = tempArray[i-1];
            }
        }
        if(rear>0)
            array[rear] = tempArray[rear-1];
        array[index+1] = element;
        rear++;
        modCount++;
    }

    /** Removes first element in array */
    @Override
    public T removeFirst() {
        // TODO
        if(rear>0)
        {
            T element = array[0];
            for(int i=0; i<rear-1; i++)
            { //shifts array
                array[i] = array[i+1];
            }
            array[rear-1] = null;
            rear--;
            modCount++;
            return element;
        }
        else
            throw new NoSuchElementException();
    }

    /** Removes last element in array */
    @Override
    public T removeLast() {
        // TODO 
        if(rear>0)
        {
            T element = array[rear-1];
            array[rear-1] = null;
            rear--;
            modCount++;
            return element;
        }
        else
            throw new NoSuchElementException();
    }

    /** Removes specified element in array */
    @Override
    public T remove(T element) {
        int index = indexOf(element);
        if (index == NOT_FOUND) {
            throw new NoSuchElementException();
        }
        
        T retVal = array[index];
        rear--;
        //shift elements
        for (int i = index; i < rear; i++) {
            array[i] = array[i+1];
        }
        array[rear] = null;
        modCount++;
        
        return retVal;
    }

    /** Removes element at specified index in array */
    @Override
    public T remove(int index) {
        // TODO 
        if(index<0 || index>=rear)
            throw new IndexOutOfBoundsException();
        
        T element = array[index];
        for (int i = index; i < rear-1; i++) {
            array[i] = array[i+1];
        }
        array[rear-1] = null;
        rear--;
        modCount++;
        return element;
    }

    /** Replaces element in array */
    @Override
    public void set(int index, T element) {
        // TODO 
        if(index<0 || index>=rear)
        {
            throw new IndexOutOfBoundsException();
        }
        array[index] = element;
        modCount++;
    }

    /** Returns element at a specified index in array */
    @Override
    public T get(int index) {
        // TODO 
        if(index<0 || index>=rear || rear<=0)
        {
            throw new IndexOutOfBoundsException();
        }
        else
            return array[index];
    }

    /** Returns index of specified element in array */
    @Override
    public int indexOf(T element) {
        int index = NOT_FOUND;
        
        if (!isEmpty()) {
            int i = 0;
            while (index == NOT_FOUND && i < rear) {
                if (element.equals(array[i])) {
                    index = i;
                } else {
                    i++;
                }
            }
        }
        return index;
    }

    /** Returns first element in array */
    @Override
    public T first() {
        // TODO 
        if(rear>0)
            return array[0];
        else
            throw new NoSuchElementException();
    }

    /** Returns last element in array */
    @Override
    public T last() {
        // TODO 
        if(rear>0)
            return array[rear-1];
        else
            throw new NoSuchElementException();
    }

    /** Returns true if element is present in array */
    @Override
    public boolean contains(T target) {
        return (indexOf(target) != NOT_FOUND);
    }

    /** Returns true if array is empty */
    @Override
    public boolean isEmpty() {
        // TODO
        return rear==0;
    }

    /** Returns size of array */
    @Override
    public int size() {
        // TODO 
        return rear;
    }

    /** Returns iterator reference */
    @Override
    public Iterator<T> iterator() {
        return new ALIterator();
    }

    @Override
    public ListIterator<T> listIterator() {
        throw new UnsupportedOperationException();
    }

    @Override
    public ListIterator<T> listIterator(int startingIndex) {
        throw new UnsupportedOperationException();
    }
    
    /** Returns a String of the array elements */
    @Override
    public String toString() {
        // TODO
        if(rear>0)
        {
            String output = "[";
            for(int i=0; i<rear-1; i++)
            {
                output = output + array[i] + ", ";
            }
            output = output + array[rear-1] + "]";
            return output;
        }
        else
        {
            return "[]";
        }
    }

    /** Iterator for IUArrayList */
    private class ALIterator implements Iterator<T> {
        private int nextIndex;
        private int iterModCount;
        private boolean retNext = false;
        
        /** Initializes iterator */
        public ALIterator() {
            nextIndex = 0;
            iterModCount = modCount;
        }
        
        /** Tests to see if array has been modified */
        public void test() {
            if(iterModCount !=modCount)
                throw new ConcurrentModificationException();
            else if(!retNext)
                throw new IllegalStateException();
        }

        /** Returns true if there are elements past the current index in the array */
        @Override
        public boolean hasNext() {
            // TODO
            //test();
            if(nextIndex<rear) //array[nextIndex]!=null)
                return true;
            else
                return false;
        }

        /** Goes to next element in array */
        @Override
        public T next() {
            // TODO
            if(hasNext())
            {
                nextIndex++;
                //modCount++;
                retNext=true;
                test();
                return array[nextIndex-1];
            }
            else
                throw new NoSuchElementException();
        }
        
        /** Removes element at current location in array */
        @Override
        public void remove() {
            // TODO
            test();
            if(retNext)
                array[nextIndex-1] = null;
            else
                throw new IllegalStateException();
            iterModCount++;
            modCount++;
            retNext = false;
        }
    }
}
