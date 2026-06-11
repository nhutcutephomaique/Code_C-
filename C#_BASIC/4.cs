using System;
using System.Security.Cryptography.X509Certificates;
namespace Condition;

class ConditionService
{
    public bool Condition(int n)
    {
        if (n % 2 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string quadraticEquation(float a, float b)
    {
        if (a == 0 && b == 0)
        {
            return "countless experiences";
        }

        if (a == 0 && b != 0)
        {
            return "ineffective";
        }

        float x = -b / a;
        return $"equation has a unique solution {x}";
    }


}