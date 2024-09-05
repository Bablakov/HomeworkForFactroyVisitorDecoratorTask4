using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;

    private void Awake()
    {
        _spawner.StartWork();   
    }
}
