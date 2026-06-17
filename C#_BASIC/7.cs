using System;
namespace switchCase;

class swithCase
{
    private void switchCase()
    {
        int n = 4;
        switch (n)
        {
            case 1:
                System.Console.WriteLine("Monday");
                break;
            case 2:
                System.Console.WriteLine("Tuesday");
                break;
            case 3:
                System.Console.WriteLine("thursday");
                break;
            case 4:
                System.Console.WriteLine("Sartuday;");
                break;

            default:
                System.Console.WriteLine("Khong co ngay phu hop");
                break;
        }
    }
}