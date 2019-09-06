using NinjasVsZombies.Utils;
using UnityEngine;

namespace NinjasVsZombies.Units
{
    public class Zombie : BaseUnit
    {
        [Header("Movement")]
        [SerializeField] private MovementDirection _movementDirection;

        [Header("Score Points")]
        [SerializeField] private int _pointsPerKill;

        [Header("Collectibles")]
        [SerializeField] private GameObject[] _collectiblesPrefabs;
        [SerializeField] private Transform _collectiblesHolder;

        [Range(0, 100)]
        [SerializeField] private float _minSpawnChance;
        [SerializeField] private float _maxSpawnChance;

        private float _spawnChance;

        private bool _isAlive;

        protected override void Start()
        {
            _isAlive = true;
            _spawnChance = Random.Range(_minSpawnChance, _maxSpawnChance);

            Move((float)_movementDirection);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_isAlive)
            {
                if (other.CompareTag("Player"))
                {
                    _animator.SetTrigger("Attack");

                    Player player = other.GetComponent<Player>();

                    if (player != null)
                    {
                        player.TakeDamage();
                    }
                }
                else if (other.CompareTag("Kunai"))
                {
                    Destroy(other.gameObject);
                    Die();
                }
            }
        }

        private bool ShouldSpawnCollectible()
        {
            float random = Random.Range(0f, 1f);

            return random <= _spawnChance;
        }

        private void SpawnRandomCollectible()
        {
            int randomIndex = Random.Range(0, _collectiblesPrefabs.Length);

            Instantiate(_collectiblesPrefabs[randomIndex], transform.position, transform.rotation, _collectiblesHolder);
        }

        public override void Move(float xDirection)
        {
            _lookDirection.Set(xDirection, 0);
            _lookDirection.Normalize();

            _animator.SetFloat("Look X", _lookDirection.x);
            _animator.SetFloat("Speed", _lookDirection.magnitude);

            Vector2 velocity = _lookDirection * _speed * Time.fixedDeltaTime;

            _rb2d.velocity = velocity;
        }

        public override void Die()
        {
            if (_isAlive)
            {
                _animator.SetTrigger("Die");

                _isAlive = false;
                _rb2d.velocity = Vector2.zero;

                ScoreManager.instance.IncreaseScore(_pointsPerKill);

                if (ShouldSpawnCollectible())
                {
                    SpawnRandomCollectible();
                }

                Destroy(gameObject, 20f);
            }
        }
    }
}