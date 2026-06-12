using System;
namespace multiplicationTable;

class multiplicationTableService
{
    public void multiplicationTable(int n)
    {
        for (int i = 1; i < 10; i++)
        {
            Console.WriteLine($"{n} * {i} = {n * i}");
        }
    }
}