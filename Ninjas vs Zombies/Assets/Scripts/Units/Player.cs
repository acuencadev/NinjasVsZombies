using UnityEngine;


namespace NinjasVsZombies.Units
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float _speed;

        private Vector2 lookDirection = new Vector2(1f, 0f);

        [Header("Attack")]
        [SerializeField] private float _attackDelay;
        private float _nextAttackTime;

        [SerializeField] private float _throwDelay;
        private float _nextThrowTime;

        private Animator _animator;
        private Rigidbody2D _rb2d;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rb2d = GetComponent<Rigidbody2D>();
        }

        public void Move(float xDirection)
        {

            lookDirection.Set(xDirection, 0);
            lookDirection.Normalize();

            _animator.SetFloat("Look X", lookDirection.x);
            _animator.SetFloat("Speed", lookDirection.magnitude);

            Vector2 newPos = _rb2d.position + lookDirection * _speed * Time.deltaTime;

            _rb2d.MovePosition(newPos);
        }

        public void StopMoving()
        {
            _animator.SetFloat("Speed", 0);
        }

        public void Jump()
        {
            Debug.Log("Player Jump");
        }

        public void Attack()
        {
            if (!CanAttack())
            {
                return;
            }

            _nextAttackTime = Time.time + _attackDelay;

            _animator.SetTrigger("Attack");

            Debug.Log("Player Attack");
        }

        private bool CanAttack()
        {
            return Time.time >= _nextAttackTime;
        }

        public void Throw()
        {
            if (!CanThrow())
            {
                return;
            }

            _nextAttackTime = Time.time + _throwDelay;

            _animator.SetTrigger("Throw");

            Debug.Log("Player Throw");
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