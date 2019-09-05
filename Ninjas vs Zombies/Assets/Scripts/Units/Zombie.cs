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

        protected override void Start()
        {
            Move((float)_movementDirection);
        }

        private void OnTriggerEnter2D(Collider2D other)
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
            _animator.SetTrigger("Die");

            //FIXME: Use a raycast to detect the player and animate the attack. Remove the second collider.
            _rb2d.simulated = false;

            ScoreManager.instance.IncreaseScore(_pointsPerKill);

            //FIXME: Fade out the enemy and then destroy it.
            Destroy(gameObject, 20f);
        }
    }
}