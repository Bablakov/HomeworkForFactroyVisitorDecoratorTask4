using Assets.Visitor.AddedScripts;
using UnityEngine;
using Zenject;

namespace Assets.Visitor
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private EnemySpawnScoreConfig _enemySpawnScoreConfig;
        [SerializeField] private EnemyFactory _enemyFactory;
        [SerializeField] private Spawner _spawner;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Spawner>().FromInstance(_spawner);
            Container.Bind<EnemyFactory>().FromInstance(_enemyFactory);
            Container.Bind<EnemySpawnScoreConfig>().FromInstance(_enemySpawnScoreConfig);
            Container.BindInterfacesAndSelfTo<SpawningEnemyScore>().AsSingle();
        }
    }
}