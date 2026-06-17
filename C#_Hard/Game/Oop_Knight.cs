using System;
namespace knight;

class Knight
{
    private string name;
    private int hP;
    private int attackPower;

    public string Name
    {
        get => name;
        set => name = value;

    }

    public int HP
    {
        get => hP;
        set => hP = value < 0 ? 0 : value;
    }

    public int AttackPower
    {
        get => attackPower;
        set => attackPower = value;
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        System.Console.WriteLine($"{Name} vua nhan {damage} sat thuong!");
    }

    public void Attack(Knight target)
    {
        System.Console.WriteLine($"{Name} vua lao vao tan cong {target.Name} voi {AttackPower} sat thuong!");
        target.TakeDamage(AttackPower);
    }

    public void PrintStatus()
    {
        System.Console.WriteLine($"[Trang thai] {Name} - HP hien tai: {HP}");

    }
}