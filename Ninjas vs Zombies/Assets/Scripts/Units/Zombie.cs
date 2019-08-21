using NinjasVsZombies.Utils;
using UnityEngine;

namespace NinjasVsZombies.Units
{
    public class Zombie : BaseUnit
    {
        [SerializeField] private MovementDirection _movementDirection;

        protected void Update()
        {
            Move((float)_movementDirection);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _animator.SetTrigger("Attack");
            }
        }

        public override void Attack()
        {
            throw new System.NotImplementedException();
        }

        public override bool CanAttack()
        {
            throw new System.NotImplementedException();
        }

        public override void Die()
        {
            throw new System.NotImplementedException();
        }
    }
}