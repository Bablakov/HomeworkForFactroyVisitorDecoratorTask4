using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Assets.Visitor
{
    public class Spawner : MonoBehaviour, IEnemyDeathNotifier, IEnemySpawner, IInitializable
    {
        public event Action<Enemy> Notified;
        public event Action<Enemy> Spawned;

        [SerializeField] private float _spawnCooldown;
        [SerializeField] private List<Transform> _spawnPoints;

        private EnemyFactory _enemyFactory;
        private List<Enemy> _spawnedEnemies = new List<Enemy>();
        private SpawningEnemyScore _spawningEnemyScore;

        private Coroutine _spawn;

        [Inject]
        private void Construct(EnemyFactory enemyFacotory, SpawningEnemyScore spawningEnemyScore)
        {
            _enemyFactory = enemyFacotory;
            _spawningEnemyScore = spawningEnemyScore;
        }

        public void Initialize()
            => StartWork();

        public void StartWork()
        {
            StopWork();
            Debug.Log("StartSpawn");
            _spawn = StartCoroutine(Spawn());
        }

        public void StopWork()
        {
            if (_spawn != null)
            {
                Debug.Log("StopSpawn");
                StopCoroutine(_spawn);
            }
        }

        public void KillRandomEnemy()
        {
            if (_spawnedEnemies.Count == 0)
                return;

            _spawnedEnemies[Random.Range(0, _spawnedEnemies.Count)].Kill();
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                if( _spawningEnemyScore.CanSpawn == false)
                {
                    StopWork();
                    yield return new WaitForSeconds(_spawnCooldown);
                }
                else
                {
                    Enemy enemy = _enemyFactory.Get((EnemyType)Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
                    enemy.MoveTo(_spawnPoints[Random.Range(0, _spawnPoints.Count)].position);
                    enemy.Died += OnEnemyDied;
                    _spawnedEnemies.Add(enemy);
                    Spawned?.Invoke(enemy);
                    Debug.Log($"CurrentScore {_spawningEnemyScore.Score}");
                
                    yield return new WaitForSeconds(_spawnCooldown);
                }
            }
        }

        private void OnEnemyDied(Enemy enemy)
        {
            Notified?.Invoke(enemy);
            enemy.Died -= OnEnemyDied;
            _spawnedEnemies.Remove(enemy);
        }
    }
}
