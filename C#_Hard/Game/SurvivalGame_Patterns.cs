using System;
using System.Collections.Generic;
using System.Threading;

public interface IReusable
{
    void OnSpawn();
    void OnDespawn();
}

public class ObjectPool<T> where T : class, IReusable, new()
{
    private readonly Queue<T> _pool = new Queue<T>();

    public T Get()
    {
        T item = _pool.Count > 0 ? _pool.Dequeue() : new T();
        item.OnSpawn();
        return item;
    }

    public void ReturnToPool(T item)
    {
        item.OnDespawn();
        _pool.Enqueue(item);
    }
}

public class Bullet : IReusable
{
    public void OnSpawn() => Console.WriteLine("   -> [Pool] Đạn lấy ra khỏi kho.");
    public void OnDespawn() => Console.WriteLine("   -> [Pool] Đạn trúng đích, trả về kho.");
}

public class Player
{
    public int Health { get; private set; } = 100;
    public bool IsDead => Health <= 0;

    public event Action OnPlayerDeath;

    public void TakeDamage(int damage)
    {
        if (IsDead) return;
        Health -= damage;
        Console.WriteLine($"[Player] Bị trúng đạn! Máu còn: {Health}");

        if (IsDead)
        {
            Console.WriteLine("[Player] NGƯỜI CHƠI ĐÃ TỬ TRẬN!");
            OnPlayerDeath?.Invoke();
        }
    }
}

public interface IState
{
    void Enter(EnemyAI enemy);
    void Execute(EnemyAI enemy);
    void Exit(EnemyAI enemy);
}

public class EnemyAI
{
    public string Name { get; private set; }
    public Player Target { get; private set; }
    public float DistanceToPlayer { get; set; }

    private IState _currentState;
    private ObjectPool<Bullet> _bulletPool;

    public EnemyAI(string name, Player target, ObjectPool<Bullet> bulletPool)
    {
        Name = name;
        Target = target;
        _bulletPool = bulletPool;

        Target.OnPlayerDeath += HandlePlayerDeath;

        ChangeState(new IdleState());
    }

    public void ChangeState(IState newState)
    {
        _currentState?.Exit(this);
        _currentState = newState;
        _currentState?.Enter(this);
    }

    public void Update()
    {
        if (!Target.IsDead)
        {
            DistanceToPlayer = new Random().Next(1, 18);
            Console.WriteLine($"\n[{Name}] Khoảng cách tới Player: {DistanceToPlayer}m");
        }

        _currentState?.Execute(this);
    }

    public void Shoot()
    {
        Console.WriteLine($"[{Name}] Pew Pew!");
        var bullet = _bulletPool.Get();

        Target.TakeDamage(25);

        _bulletPool.ReturnToPool(bullet);
    }

    private void HandlePlayerDeath()
    {
        ChangeState(new CheerState());
    }
}

public class IdleState : IState
{
    public void Enter(EnemyAI enemy) => Console.WriteLine($"[{enemy.Name}] -> VÀO TRẠNG THÁI: IDLE (Đứng nhìn)");
    public void Execute(EnemyAI enemy)
    {
        if (enemy.DistanceToPlayer < 10) enemy.ChangeState(new ChaseState());
    }
    public void Exit(EnemyAI enemy) { }
}

public class ChaseState : IState
{
    public void Enter(EnemyAI enemy) => Console.WriteLine($"[{enemy.Name}] -> VÀO TRẠNG THÁI: CHASE (Đang rượt!)");
    public void Execute(EnemyAI enemy)
    {
        if (enemy.DistanceToPlayer <= 3) enemy.ChangeState(new AttackState());
        else if (enemy.DistanceToPlayer > 15) enemy.ChangeState(new IdleState());
    }
    public void Exit(EnemyAI enemy) { }
}

public class AttackState : IState
{
    public void Enter(EnemyAI enemy) => Console.WriteLine($"[{enemy.Name}] -> VÀO TRẠNG THÁI: ATTACK (Tấn công!)");
    public void Execute(EnemyAI enemy)
    {
        enemy.Shoot();
        if (enemy.DistanceToPlayer > 3) enemy.ChangeState(new ChaseState());
    }
    public void Exit(EnemyAI enemy) { }
}

public class CheerState : IState
{
    public void Enter(EnemyAI enemy) => Console.WriteLine($"[{enemy.Name}] -> VÀO TRẠNG THÁI: CHEER (Ăn mừng chiến thắng!)");
    public void Execute(EnemyAI enemy)
    {
        Console.WriteLine($"[{enemy.Name}] Nhảy múa trên xác Player muahahaha!");
    }
    public void Exit(EnemyAI enemy) { }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== KHỞI ĐỘNG GAME ===");

        Player player = new Player();
        ObjectPool<Bullet> bulletPool = new ObjectPool<Bullet>();

        List<EnemyAI> enemies = new List<EnemyAI>
        {
            new EnemyAI("Orc Đột Biến", player, bulletPool),
            new EnemyAI("Goblin Nhỏ", player, bulletPool)
        };

        int frame = 1;
        while (!player.IsDead && frame <= 10)
        {
            Console.WriteLine($"\n--- Khung hình (Frame) {frame} ---");
            foreach (var enemy in enemies)
            {
                enemy.Update();
            }

            frame++;
            Thread.Sleep(1000);
        }

        Console.WriteLine("\n=== GAME OVER ===");

        Console.WriteLine("\n--- Khung hình sau khi Game Over ---");
        foreach (var enemy in enemies)
        {
            enemy.Update();
        }

        Console.ReadLine();
    }
}