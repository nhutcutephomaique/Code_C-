using System;
namespace particle;

public struct Particle
{
    public float x, y;
    public float Vx, Vy;
}

public class PhysicsSimualation
{
    public static void UpdateParticles(Span<Particle> particles, float deltaiTime)
    {
        for (int i = 0; i < particles.Length; i++)
        {
            ref Particle p = ref particles[i];
            p.x += p.Vx * deltaiTime;
            p.y += p.Vy * deltaiTime;
        }
    }
}