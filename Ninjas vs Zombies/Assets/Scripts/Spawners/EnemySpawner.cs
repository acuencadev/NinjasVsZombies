using NinjasVsZombies.Managers;
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
        private float _nextSpawnTime;

        [Header("Enemies Holder")]
        [SerializeField] private Transform _enemyHolder;

        private void Update()
        {
            if (ShouldSpawn() && GameManager.instance.gameStatus == Utils.GameStatus.PLAYING)
            {
                Spawn();
            }
        }

        private bool ShouldSpawn()
        {
            return Time.time >= _nextSpawnTime;
        }

        private void Spawn()
        {
            int randomPrefabIndex = Random.Range(0, _enemyPrefabs.Length);
            Instantiate(_enemyPrefabs[randomPrefabIndex], transform.position, transform.rotation, _enemyHolder);

            float randomSpawnDelay = Random.Range(_minSpawnDelay, _maxSpawnDelay);

            _nextSpawnTime = Time.time + randomSpawnDelay;
        }
    }
}
