public class QuickSort
{
    public static void sort(int a[ ], int left, int right)
    {
        if (left >= right) return;
        int k = left;
        int j = right;
        int pivotValue = a[ (left + right) / 2 ]; // salient feature
        while ( k < j )
        {
        while (a[k] < pivotValue) //salient feature (pivot point)
        {
            k++;
        }
        while ( pivotValue < a[j] )
        {
            j--;
        }
        if ( k <= j)
        {
            int temp = a[k]; //swap a[k] and a[j]
            a[k] = a[j];
            a[j] = temp;
            k++;
            j--;
        }
        }
        sort(a, left, j); //salient feature (recursion)
        sort(a, k, right);
    }
}