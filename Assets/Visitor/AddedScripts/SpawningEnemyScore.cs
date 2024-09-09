using Assets.Visitor.AddedScripts;
using System;

namespace Assets.Visitor
{
    public class SpawningEnemyScore : IEnemyVisitor, IDisposable
    {
        private IEnemySpawner _enemySpawner;
        private EnemySpawnScoreConfig _config;
        private int _currentScore;

        public SpawningEnemyScore(EnemySpawnScoreConfig config, IEnemySpawner enemySpawner)
        {
            _config = config;
            _enemySpawner = enemySpawner;
            Subscribe();
        }

        public bool CanSpawn => _currentScore < _config.MaxScoreSpawnEnemy;
        public int Score => _currentScore;
        
        public void Dispose()
            => Unsubscribe();

        public void Visit(Ork ork) => _currentScore += _config.Ork;

        public void Visit(Human human) => _currentScore += _config.Human;

        public void Visit(Elf elf) => _currentScore += _config.Elf;

        public void Visit(Robot robot) => _currentScore += _config.Robot;

        private void Subscribe()
            => _enemySpawner.Spawned += EnemySpawned;

        private void Unsubscribe()
            => _enemySpawner.Spawned -= EnemySpawned;

        private void EnemySpawned(Enemy enemy)
            => enemy.Accept(this);
    }
}