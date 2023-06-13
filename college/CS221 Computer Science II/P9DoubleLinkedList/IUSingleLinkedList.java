import java.util.Iterator;
import java.util.ListIterator;
import java.util.*;

/**
 * Single-linked node implementation of IndexedUnsortedList.
 * An Iterator with working remove() method is implemented, but
 * ListIterator is unsupported.
 * 
 * @author 
 * 
 * @param <T> type to store
 */
public class IUSingleLinkedList<T> implements IndexedUnsortedList<T> {
	private Node<T> head, tail;
	private int size;
	private int modCount;
	
	/** Creates an empty list */
	public IUSingleLinkedList() {
		head = tail = null;
		size = 0;
		modCount = 0;
	}
	
	/** Adds element to the front of the array */
	@Override
	public void addToFront(T element) {
		// TODO 
		add(0, element);
	}

	/** Adds element to the back of the array */
	@Override
	public void addToRear(T element) {
		// TODO 
		add(size, element);
	}

	/** Adds element to the back of the array */
	@Override
	public void add(T element) {
		// TODO 
		add(size(), element);
	}

	/** Adds element after a specified target element */
	@Override
	public void addAfter(T element, T target) {
		// TODO 
		Node<T> targetNode = head;
		boolean found = false;
		Node<T> newNode = new Node<T>(element);
		if(size() == 1 && targetNode.getNext()!=null && targetNode.getElement().equals(target))
		{
		    newNode.setNext(targetNode);
		    head = newNode;
		    tail = targetNode;
		}
		else if(size() == 1 && targetNode.getNext()==null && targetNode.getElement().equals(target))
		{
		    newNode.setNext(targetNode.getNext());
                    targetNode.setNext(newNode);
                    tail = newNode;
		}
		else
		{
		    while(targetNode != null && !found)
		    {
		        if(targetNode.getElement().equals(target))
		        {
		            found = true;
		        }
		        else
		        {
		            targetNode = targetNode.getNext();
		        }
		    }
		    if(!found)
		    {
		        throw new NoSuchElementException();
		    }
		
                    newNode.setNext(targetNode.getNext());
                    targetNode.setNext(newNode);
                    if(targetNode == tail)
                    {
                	tail = newNode;
                    }
                }
		size++;
		modCount++;
	}

	/** Inserts element at a specified index */
	@Override
	public void add(int index, T element) {
		// TODO 
		Node<T> targetNode = head;
		if (index>size() || index<0)
		{
		    throw new IndexOutOfBoundsException();
		}
		Node<T> newNode = new Node<T>(element);
		if (isEmpty())
		{
		    targetNode = newNode;
		    head = targetNode;
		}
		else if(size() == 1 && index==0)
		{
		    newNode.setNext(targetNode);
		    head = newNode;
		    tail = targetNode;
		}
		else if(size() == 1 && index==1)
		{
		    newNode.setNext(targetNode.getNext());
                    targetNode.setNext(newNode);
                    tail = newNode;
		}
		else if(index==0)
		{
		    newNode.setNext(targetNode);
		    head = newNode;
		}
		else
		{
                    for(int currentIndex = 0; currentIndex<index-1; currentIndex++)
                    {
        		targetNode = targetNode.getNext();
                    }

                    newNode.setNext(targetNode.getNext());
                    targetNode.setNext(newNode);
                    if(targetNode == tail)
                    {
                	tail = newNode;
                    }
                }
        	size++;
        	modCount++;
        }

        /** Removes first element in array */
        @Override
        public T removeFirst() {
            // TODO 
            if(head!=null)
            {
                T element = head.getElement();
                return remove(element);
            }
            else
            {
                throw new NoSuchElementException();
            }
        }

        /** Removes last element in array */
        @Override
        public T removeLast() {
            // TODO 
            if(tail!=null)
            {
                T element = tail.getElement();
                return remove(element);
            }
            else if(head!=null)
            {
                T element = head.getElement();
                return remove(element);
            }
            else
            {
                throw new NoSuchElementException();
            }
        }

        /** Removes specified element in array */
        @Override
        public T remove(T element) {
                if (isEmpty()) {
                    throw new NoSuchElementException();
                }
	
        	 T retVal;
        	 if(head.getElement().equals(element))
        	 {
        	     retVal = head.getElement();
        	     head = head.getNext();
        	     if(head == null)
        	     {
        	         tail = null;
        	     }
        	 }
        	 else
        	 {
        	     Node<T> preNode = head;
        	     boolean found = false;
        	     while(preNode.getNext() != null && !found)
        	     {
        	         if(preNode.getNext().getElement().equals(element))
        	         {
        	             found = true;
        	         }
        	         else
        	         {
        	             preNode = preNode.getNext();
        	         }
        	     }
        	     
        	     if(!found)
        	     {
        	         throw new NoSuchElementException();
        	     }
        	     
        	     retVal = preNode.getNext().getElement();
        	     preNode.setNext(preNode.getNext().getNext());
        	     if(preNode.getNext() == null)
        	     {
        	         tail = preNode;
        	     }
                 }
        	 size--;
        	 modCount++;
        	 return retVal;
        }

        /** Removes element at specified index in array */
        @Override
        public T remove(int index) {
        	// TODO 
                if (index>size()-1 || index<0)
		{
		    throw new IndexOutOfBoundsException();
		}
		if (isEmpty()) {
                    throw new NoSuchElementException();
                }
	
        	 T retVal;
        	 if(index==0)
        	 {
        	     retVal = head.getElement();
        	     head = head.getNext();
        	     if(head == null)
        	     {
        	         tail = null;
        	     }
        	 }
        	 else
        	 {
        	     Node<T> preNode = head;
        	     for(int currentIndex = 0; currentIndex<index-1; currentIndex++)
        	     {
        	         preNode = preNode.getNext();
        	     }
        	     
        	     retVal = preNode.getNext().getElement();
        	     preNode.setNext(preNode.getNext().getNext());
        	     if(preNode.getNext() == null)
        	     {
        	         tail = preNode;
        	     }
                 }
        	 size--;
        	 modCount++;
        	 
        	 return retVal;
        }

        /** Replaces element in array */
        @Override
        public void set(int index, T element) {
        	// TODO 
        	Node<T> current = head;
        	if (index>size()-1 || index<0 || isEmpty())
        	{
        	    throw new IndexOutOfBoundsException();
        	}
        	else
        	{
    		    for(int currentIndex = 0; currentIndex<index; currentIndex++)
    		    {
    		        current = current.getNext();
    		    }
    		}
    		current.setElement(element);
    		if(current == head)
    		{
    		    head.setElement(element);
    		}
    		else if(current == tail)
    		{
    		    tail.setElement(element);
    		}
    		modCount++;
        }
        
        /** Returns element at a specified index in array */
        @Override
        public T get(int index) {
        	// TODO 
        	Node<T> current = head;
        	if (index>size()-1 || index<0 || isEmpty())
        	{
        	    throw new IndexOutOfBoundsException();
        	}
        	else
        	{
    		    for(int currentIndex = 0; currentIndex<index; currentIndex++)
    		    {
    		        current = current.getNext();
    		    }
    		}
        	return current.getElement();
        }

        /** Returns index of specified element in array */
        @Override
        public int indexOf(T element) {
        	// TODO 
        	int index = -1;
        	int currentIndex = 0;
        	Node<T> current = head;
        	while(current != null && index<0)
        	{
        	    if(current.getElement().equals(element))
        	    {
        	        index = currentIndex;
        	    }
        	    currentIndex++;
        	    current = current.getNext();
        	}
        	
        	return index;
        }
        
        /** Returns first element in array */
        @Override
        public T first() {
        	// TODO 
        	if(head!=null)
        	return head.getElement();
        	else
        	throw new NoSuchElementException();
        }
        
        /** Returns last element in array */
        @Override
        public T last() {
        	// TODO 
        	if(tail!=null)
        	return tail.getElement();
        	else if(size()==1)
        	return head.getElement();
        	else
        	throw new NoSuchElementException();
        }
        
        /** Returns true if element is present in array */
        @Override
        public boolean contains(T target) {
        	// TODO 
        	Node<T> current = head;
        	while(current != null)
        	{
        	    if(current.getElement().equals(target))
        	    {
        	        return true;
        	    }
        	    current = current.getNext();
        	}
        	return false;
        }

        /** Returns true if array is empty */
        @Override
        public boolean isEmpty() {
        	// TODO 
        	return size()==0 || head==null;
        }
        
        /** Returns size of array */
        @Override
        public int size() {
        	// TODO 
        	return size;
        }
        
        /** Returns iterator reference */
        @Override
        public Iterator<T> iterator() {
        	return new SLLIterator();
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
                Node<T> current = head;
                String output = "[";
                if(!isEmpty())
                {
                    while(current.getNext()!=null)
                    {
                        output = output + current.getElement().toString() + ", ";
                        current = current.getNext();
                    }
                    output = output + current.getElement().toString() + "]";
                    return output;
                }
                else
                    return "[]";
        }
        
        /** Iterator for IUSingleLinkedList */
        private class SLLIterator implements Iterator<T> {
        	private Node<T> nextNode;
        	private Node<T> currentNode;
        	private int iterModCount;
        	private T nextElement;
        	
        	/** Creates a new iterator for the list */
        	public SLLIterator() {
        		nextNode = head;
        		iterModCount = modCount;
        	}
        
        	/** Returns true if there are elements past the current index in the array */
        	@Override
        	public boolean hasNext() {
        		// TODO 
        		if(iterModCount!=modCount)
        		{
        		    throw new ConcurrentModificationException();
        		}
        		if(nextNode != null)
        		{
        		    return true;
        		}
        		return false;
        	}
        
        	/** Goes to next element in array */
        	@Override
        	public T next() {
        		// TODO 
        		if(iterModCount!=modCount)
        		{
        		    throw new ConcurrentModificationException();
        		}
        		if(hasNext())
        		{
        		    currentNode = nextNode;
        		    nextElement = currentNode.getElement();
        		    nextNode = nextNode.getNext();
        		    return nextElement;
        		}
        		else
        		{
        		    throw new NoSuchElementException();
        		}
        	}
        	
        	/** Removes element at current location in array */
        	@Override
        	public void remove() {
        		// TODO
        		if(iterModCount!=modCount)
        		{
        		    throw new ConcurrentModificationException();
        		}
        		if(nextElement == null)
        		{
        		    throw new IllegalStateException();
        		}
        		else
        		{
        		    currentNode.setElement(null);
        		    nextElement = null;
        		    iterModCount++;
        		}
        		modCount++;
        	}
        }
}
