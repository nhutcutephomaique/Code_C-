
using System;
public static class Sorting
{
    public static void CountingSort(int[] arr)
    {
        if (arr == null || arr.Length <= 1) return;

        int min = arr[0];
        int max = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < min) min = arr[i];
            if (arr[i] > max) max = arr[i];
        }

        int range = max - min + 1;
        int[] count = new int[range];

        for (int i = 0; i < arr.Length; i++)
            count[arr[i] - min]++;
        int idx = 0;
        for (int i = 0; i < range; i++)
        {
            while (count[i]-- > 0)
                arr[idx++] = i + min;
        }
    }
}
