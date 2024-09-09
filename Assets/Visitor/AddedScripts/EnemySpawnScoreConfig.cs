using UnityEngine;

namespace Assets.Visitor.AddedScripts
{
    [CreateAssetMenu(fileName = "new EnemySpawnScoreConfig", menuName = "Configs/EnemySpawnScoreConfig")]
    public class EnemySpawnScoreConfig : ScriptableObject
    {
        [field: SerializeField, Range(0, 100)] public int Elf { get; private set; }
        [field: SerializeField, Range(0, 100)] public int Human { get; private set; }
        [field: SerializeField, Range(0, 100)] public int Ork { get; private set; }
        [field: SerializeField, Range(0, 100)] public int Robot { get; private set; }
        [field: SerializeField, Range(0, 1000)] public int MaxScoreSpawnEnemy { get; private set; }
    }
}