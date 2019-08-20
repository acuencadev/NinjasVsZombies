using NinjasVsZombies.Utils;
using UnityEngine;

namespace NinjasVsZombies.Units
{
    public class Zombie : BaseUnit
    {
        [SerializeField] private MovementDirection _movementDirection;

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