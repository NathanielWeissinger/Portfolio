public class MultiKeySort
{
    public static void sort(int a[])
    {
        int min;
        int minIndex;
        for(int i = 0;i < a.length; ++i)
        {
            min = a[i];
            minIndex = i;
                for (int j = i + 1; j < a.length; ++j) // Find minimum
                {
                    if (a[j] < min) //salient feature
                    {
                        min = a[j];
                        minIndex = j;
                    }
                }
            a[minIndex] = a[i]; // swap
            a[i] = min;
        }
    }
}