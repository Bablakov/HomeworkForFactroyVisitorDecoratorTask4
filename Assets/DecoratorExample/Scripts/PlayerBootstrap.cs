using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBootstrap : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Awake()
    {
        _player.Initialize(new ElfHealth(new AngelHealth(new Health(50), 4, 4, this), 2));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _player.TakeDamage(6);

        if (Input.GetKeyDown(KeyCode.F))
            _player.Heal(6);
    }
}
