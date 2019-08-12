using NinjasVsZombies.Utils;
using UnityEngine;


namespace NinjasVsZombies.Units
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float _speed;

        private Vector2 _lookDirection = new Vector2(1f, 0f);

        [Header("Attack")]
        [SerializeField] private float _attackDelay;
        private float _nextAttackTime;

        [SerializeField] private Kunai _kunaiPrefab;

        [SerializeField] private float _throwDelay;
        private float _nextThrowTime;

        private Animator _animator;
        private Rigidbody2D _rb2d;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rb2d = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _animator.SetFloat("Look X", _lookDirection.x);
            _animator.SetFloat("Speed", 0f);
        }

        public void Move(float xDirection)
        {

            _lookDirection.Set(xDirection, 0);
            _lookDirection.Normalize();

            _animator.SetFloat("Look X", _lookDirection.x);
            _animator.SetFloat("Speed", _lookDirection.magnitude);

            Vector2 newPos = _rb2d.position + _lookDirection * _speed * Time.deltaTime;

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
            if (!CanThrow() || _kunaiPrefab == null)
            {
                return;
            }

            MovementDirection kunaiDirection = 
                Mathf.Approximately(_lookDirection.x, -1f) ? MovementDirection.RightToLeft : MovementDirection.LeftToRight;

            Vector2 kunaiPosition = new Vector2(transform.position.x + (_lookDirection.x * 0.5f), transform.position.y);

            Kunai newKunai = Instantiate(_kunaiPrefab, kunaiPosition, _kunaiPrefab.transform.rotation);
            newKunai._movementDirection = kunaiDirection;

            _nextAttackTime = Time.time + _throwDelay;

            _animator.SetTrigger("Throw");
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