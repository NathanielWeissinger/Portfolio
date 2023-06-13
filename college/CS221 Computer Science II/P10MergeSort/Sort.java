import java.util.*;
/**
 * Class for sorting lists that implement the IndexedUnsortedList interface,
 * using ordering defined by class of objects in list or a Comparator.
 * As written uses Mergesort algorithm.
 *
 * @author Nathaniel Weissinger CS221
 */
public class Sort
{
    /**
     * Returns a new list that implements the IndexedUnsortedList interface. 
     * 
     * @return a new list that implements the IndexedUnsortedList interface
     */
    private static <T> IndexedUnsortedList<T> newList() 
    {
        return new WrappedDLL<T>();
    }
    
    /**
     * Sorts a list that implements the IndexedUnsortedList interface 
     * using compareTo() method defined by class of objects in list.
     * DO NOT MODIFY THIS METHOD
     * 
     * @param <T>
     *            The class of elements in the list, must extend Comparable
     * @param list
     *            The list to be sorted, implements IndexedUnsortedList interface 
     * @see IndexedUnsortedList 
     */
    public static <T extends Comparable<T>> void sort(IndexedUnsortedList<T> list) 
    {
        int size = list.size();
        int middle = size/2;
        IndexedUnsortedList<T> leftList = newList();   //splits list
        IndexedUnsortedList<T> rightList = newList();
        
        for(int i=0; i<size; i++)              //initializes left and right lists
        {
            if(i<middle && i>=0)
            {
                leftList.add(list.get(i));
            }
            else if(i>=middle && i<size)
            {
                rightList.add(list.get(i));
            }
        }
        
        if(!leftList.isEmpty() || leftList != null || !rightList.isEmpty() || rightList != null)
        {                                          //if lists aren't empty
            if(!(leftList.size()<=2 || rightList.size()<=2)) //make sure lists don't have 2 or less elements
            {
                sort(leftList);
                sort(rightList);
            }
            if(!list.isEmpty())
            mergesort(list);
        }
    }

    /**
     * Sorts a list that implements the IndexedUnsortedList interface 
     * using given Comparator.
     * DO NOT MODIFY THIS METHOD
     * 
     * @param <T>
     *            The class of elements in the list
     * @param list
     *            The list to be sorted, implements IndexedUnsortedList interface 
     * @param c
     *            The Comparator used
     * @see IndexedUnsortedList 
     */
    public static <T> void sort(IndexedUnsortedList <T> list, Comparator<T> c) 
    {
        int size = list.size();
        int middle = size/2;
        IndexedUnsortedList<T> leftList = newList();   //splits list
        IndexedUnsortedList<T> rightList = newList();
        
        for(int i=0; i<size; i++)              //initializes left and right lists
        {
            if(i<middle && i>=0)
            {
                leftList.add(list.get(i));
            }
            else if(i>=middle && i<size)
            {
                rightList.add(list.get(i));
            }
        }
        
        if(!leftList.isEmpty() || leftList != null || !rightList.isEmpty() || rightList != null)
        {                                          //if lists aren't empty
            if(!(leftList.size()<=2 || rightList.size()<=2)) //make sure lists don't have 2 or less elements
            {
                sort(leftList,c);
                sort(rightList,c);
            }
            if(!list.isEmpty())
            mergesort(list,c);
        }
    }
    
    /**
     * Mergesort algorithm to sort objects in a list 
     * that implements the IndexedUnsortedList interface, 
     * using compareTo() method defined by class of objects in list.
     * DO NOT MODIFY THIS METHOD SIGNATURE
     * 
     * @param <T>
     *            The class of elements in the list, must extend Comparable
     * @param list
     *            The list to be sorted, implements IndexedUnsortedList interface 
     */
    private static <T extends Comparable<T>> void mergesort(IndexedUnsortedList<T> list)
    {
        IndexedUnsortedList<T> tempList = newList();  //initializes ordered list
        tempList.add(list.get(0));      //adds first element from list to start analyzing the other elements
        for(int i=1; i<list.size(); i++)
        {
            int tempSize = tempList.size();
            
            for(int j=0; j<tempSize; j++)
            {
                if(tempList.get(j).compareTo(list.get(i))>=0) 
                {               //if new element is less than ordered list's element
                    tempList.add(j, list.get(i));
                    break;
                }
                else if(tempList.get(j).compareTo(list.get(i))<0 && j==tempSize-1)
                {               //if new element is larger than all other elements
                    tempList.addToRear(list.get(i));
                    break;
                }
            }
        }
        for(int i=tempList.size()-1; i>-1; i--)
        {
            list.set(i,tempList.get(i));
        }
    }
        
    /**
     * Mergesort algorithm to sort objects in a list 
     * that implements the IndexedUnsortedList interface,
     * using the given Comparator.
     * DO NOT MODIFY THIS METHOD SIGNATURE
     * 
     * @param <T>
     *            The class of elements in the list
     * @param list
     *            The list to be sorted, implements IndexedUnsortedList interface 
     * @param c
     *            The Comparator used
     */
    private static <T> void mergesort(IndexedUnsortedList<T> list, Comparator<T> c)
    {
        IndexedUnsortedList<T> tempList = newList();  //initializes ordered list
        tempList.add(list.get(0));      //adds first element from list to start analyzing the other elements
        for(int i=1; i<list.size(); i++)
        {
            int tempSize = tempList.size();
            
            for(int j=0; j<tempSize; j++)
            {
                if(c.compare(tempList.get(j),list.get(i))>=0) 
                {               //if new element is less than ordered list's element
                    tempList.add(j, list.get(i));
                    break;
                }
                else if(c.compare(tempList.get(j),list.get(i))<0 && j==tempSize-1)
                {               //if new element is larger than all other elements
                    tempList.addToRear(list.get(i));
                    break;
                }
            }
        }
        for(int i=tempList.size()-1; i>-1; i--)
        {
            list.set(i,tempList.get(i));
        }
    }
    
}