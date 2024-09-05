using System;
using UnityEngine;

namespace Assets.Visitor
{
    public class Score
    {
        public int Value => _enemyVisiter.Score;

        private IEnemyDeathNotifier _enemyDeathNotifier;
        private EnemyVisiter _enemyVisiter;

        public Score(IEnemyDeathNotifier deathNotifier)
        {
            _enemyDeathNotifier = deathNotifier;
            _enemyDeathNotifier.Notified += OnEnemyKilled;

            _enemyVisiter = new EnemyVisiter();
        }

        public void OnEnemyKilled(Enemy enemy)
        {
            enemy.Accept(_enemyVisiter);
            Debug.Log($"Счет: {Value}");
        }

        private class EnemyVisiter : IEnemyVisitor
        {
            public int Score { get; private set; }

            public void Visit(Ork ork) => Score += 20;

            public void Visit(Human human) => Score += 5;

            public void Visit(Elf elf) => Score += 10;

            public void Visit(Robot robot) => Score += 25;
        }
    }
}



