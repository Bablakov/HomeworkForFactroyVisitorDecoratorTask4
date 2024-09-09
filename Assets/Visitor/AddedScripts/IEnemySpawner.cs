using System;

namespace Assets.Visitor
{
    public interface IEnemySpawner
    {
        event Action<Enemy> Spawned;
    }
}