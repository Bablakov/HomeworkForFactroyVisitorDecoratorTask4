using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnCooldown;

    [SerializeField] private List<Transform> _spawnPoints;

    [SerializeField] private EnemyFactory _enemyFactory;

    private Coroutine _spawn;

    public void StartWork()
    {
        StopWork();

        _spawn = StartCoroutine(Spawn());
    }

    public void StopWork()
    {
        if(_spawn != null)
            StopCoroutine(_spawn);
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            EnemyType selectedEnemyType = (EnemyType)Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length);
            Vector3 spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)].position;
            Enemy enemy = _enemyFactory.Get(selectedEnemyType, spawnPoint);
            yield return new WaitForSeconds(_spawnCooldown);
        }
    }
}
