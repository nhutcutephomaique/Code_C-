using System;

namespace CSharpBasic;

// Abstraction: abstract class defines common behavior and forces derived classes to implement specific parts
public abstract class Employee
{
    private string _name;
    private double _salary;

    protected Employee(string name, double salary)
    {
        _name = name;
        _salary = salary;
    }

    // Encapsulation: private fields are hidden and accessed through properties
    public string Name
    {
        get => _name;
        private set => _name = value;
    }

    public double Salary
    {
        get => _salary;
        private set => _salary = value;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"{Name} - Salary: {Salary:C}");
    }

    // Inheritance + Polymorphism: derived classes can override this behavior
    public virtual void Work()
    {
        Console.WriteLine($"{Name} is working.");
    }

    public abstract void GetRole();
}

public class Developer : Employee
{
    public Developer(string name, double salary) : base(name, salary)
    {
    }

    public override void Work()
    {
        Console.WriteLine($"{Name} is coding.");
    }

    public override void GetRole()
    {
        Console.WriteLine($"{Name} is a Developer.");
    }
}

public class Designer : Employee
{
    public Designer(string name, double salary) : base(name, salary)
    {
    }

    public override void Work()
    {
        Console.WriteLine($"{Name} is designing UI.");
    }

    public override void GetRole()
    {
        Console.WriteLine($"{Name} is a Designer.");
    }
}

public class OopAdvancedDemo
{
    public void Run()
    {
        Console.WriteLine("=== Advanced OOP Demo ===");

        Employee developer = new Developer("An", 2000);
        Employee designer = new Designer("Binh", 1800);

        developer.ShowInfo();
        developer.Work();
        developer.GetRole();

        designer.ShowInfo();
        designer.Work();
        designer.GetRole();

        Console.WriteLine("\n4 đặc trưng OOP:");
        Console.WriteLine("- Encapsulation: dữ liệu được che giấu bằng private field + property");
        Console.WriteLine("- Inheritance: Developer và Designer kế thừa Employee");
        Console.WriteLine("- Polymorphism: cùng kiểu Employee nhưng hành vi khác nhau");
        Console.WriteLine("- Abstraction: Employee là lớp trừu tượng, chỉ định nghĩa chung");
    }
}
