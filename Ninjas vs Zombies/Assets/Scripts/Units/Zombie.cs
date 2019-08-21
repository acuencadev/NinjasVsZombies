﻿using NinjasVsZombies.Utils;
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
            else if (other.CompareTag("Kunai"))
            {
                Destroy(other.gameObject);
                Die();
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
            _animator.SetTrigger("Die");
            _rb2d.simulated = false;

            //FIXME: Fade out the enemy and then destroy it.
            Destroy(gameObject, 2f);
        }
    }
}