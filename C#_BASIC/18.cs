using System;

class BinarySearchProgram
{
    static int BinarySearch(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (arr[mid] == target)
                return mid;
            if (arr[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return -1;
    }

    static void Main()
    {
        int[] arr = { 1, 2, 4, 5, 7, 8, 10 };
        int target = 5;
        int index = BinarySearch(arr, target);
        Console.WriteLine(index);
    }
}
