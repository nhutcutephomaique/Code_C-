using System;

class LinearSearchProgram
{
    static int LinearSearch(int[] arr, int target)
    {
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] == target)
                return i;
        return -1;
    }

    static void Main()
    {
        int[] arr = { 5, 3, 8, 4, 2, 7, 1, 6 };
        int target = 4;
        int index = LinearSearch(arr, target);
        Console.WriteLine(index);
    }
}
