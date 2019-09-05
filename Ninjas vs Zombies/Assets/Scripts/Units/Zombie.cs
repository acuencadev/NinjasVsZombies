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

        private bool _isAlive;

        protected override void Start()
        {
            _isAlive = true;
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

                //FIXME: Fade out the enemy and then destroy it.
                Destroy(gameObject, 20f);
            }
        }
    }
}