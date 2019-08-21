using UnityEngine;

namespace NinjasVsZombies.Spawners
{
    public class EnemySpawner : MonoBehaviour
    {
        [Header("Prefab")]
        [SerializeField] private GameObject[] _enemyPrefabs;

        [Header("Spawn Frequency")]
        [SerializeField] private float _minSpawnDelay;
        [SerializeField] private float _maxSpawnDelay;

        private float _spawnDelay;
        private float _nextThrowTime;
    }
}
