using System;

class MergeSortProgram
{
    static void Merge(int[] arr, int l, int m, int r)
    {
        int n1 = m - l + 1;
        int n2 = r - m;
        int[] L = new int[n1];
        int[] R = new int[n2];
        for (int i = 0; i < n1; i++) L[i] = arr[l + i];
        for (int j = 0; j < n2; j++) R[j] = arr[m + 1 + j];
        int ii = 0, jj = 0, k = l;
        while (ii < n1 && jj < n2)
        {
            if (L[ii] <= R[jj])
            {
                arr[k++] = L[ii++];
            }
            else
            {
                arr[k++] = R[jj++];
            }
        }
        while (ii < n1) arr[k++] = L[ii++];
        while (jj < n2) arr[k++] = R[jj++];
    }

    static void MergeSort(int[] arr, int l, int r)
    {
        if (l >= r) return;
        int m = l + (r - l) / 2;
        MergeSort(arr, l, m);
        MergeSort(arr, m + 1, r);
        Merge(arr, l, m, r);
    }

    static void Main()
    {
        int[] arr = { 12, 11, 13, 5, 6, 7 };
        MergeSort(arr, 0, arr.Length - 1);
        for (int i = 0; i < arr.Length; i++)
            Console.Write(arr[i] + (i < arr.Length - 1 ? " " : ""));
        Console.WriteLine();
    }
}
