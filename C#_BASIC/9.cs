using System;
namespace DSA;

class minVal
{
    static void Main(string[] args)
    {
        int[] array_min = { 2, 7, 4, 2, 8, 12, 5 };
        int minValaue = array_min[0];
        foreach (int i in array_min)
        {
            if (i < minValaue)
            {
                minValaue = i;
            }
        }
        System.Console.WriteLine(minValaue);
    }
}