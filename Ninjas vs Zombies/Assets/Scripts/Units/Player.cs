using NinjasVsZombies.Utils;
using UnityEngine;


namespace NinjasVsZombies.Units
{
    public class Player : BaseUnit
    {
        [Header("Attack")]
        [SerializeField] private float _attackDelay;
        private float _nextAttackTime;

        [SerializeField] private Transform _attackPos;
        [SerializeField] private Vector2 _attackArea;
        [SerializeField] private LayerMask _whatIsEnemy;

        [Header("Throw Attack")]
        [SerializeField] private Kunai _kunaiPrefab;

        [SerializeField] private float _throwDelay;
        private float _nextThrowTime;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(_attackPos.position, _attackArea);
        }

        public override bool CanAttack()
        {
            return Time.time >= _nextAttackTime;
        }

        public override void Attack()
        {
            if (!CanAttack())
            {
                return;
            }

            _nextAttackTime = Time.time + _attackDelay;

            _animator.SetTrigger("Attack");
        }

        public override void Die()
        {
            throw new System.NotImplementedException();
        }

        public void StopMoving()
        {
            _animator.SetFloat("Speed", 0);
        }

        public void Jump()
        {
            Debug.Log("Player Jump");
        }

        public void DamageEnemiesOnAttack()
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(_attackPos.position, _attackArea, 0f, _whatIsEnemy);

            foreach (Collider2D collider in enemiesToDamage)
            {
                collider.GetComponent<Zombie>().Die();
            }
        }

        public void Throw()
        {
            if (!CanThrow() || _kunaiPrefab == null)
            {
                return;
            }

            _nextThrowTime = Time.time + _throwDelay;

            _animator.SetTrigger("Throw");
        }

        public void ThrowKunai()
        {
            MovementDirection kunaiDirection =
                Mathf.Approximately(_lookDirection.x, -1f) ? MovementDirection.RightToLeft : MovementDirection.LeftToRight;

            Vector2 kunaiPosition = new Vector2(transform.position.x + (_lookDirection.x * 0.5f), transform.position.y);

            Kunai newKunai = Instantiate(_kunaiPrefab, kunaiPosition, _kunaiPrefab.transform.rotation);
            newKunai._movementDirection = kunaiDirection;
        }

        private bool CanThrow()
        {
            return Time.time >= _nextThrowTime;
        }

        public void Slide()
        {
            Debug.Log("Player Slide");
        }
    }
}