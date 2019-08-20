using UnityEngine;

namespace NinjasVsZombies.Units
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class BaseUnit : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] protected float _speed;

        protected Vector2 _lookDirection = new Vector2(1f, 0f);

        protected Animator _animator;
        protected Rigidbody2D _rb2d;

        protected virtual void Awake()
        {
            _animator = GetComponent<Animator>();
            _rb2d = GetComponent<Rigidbody2D>();
        }

        protected virtual void Start()
        {
            _animator.SetFloat("Look X", _lookDirection.x);
            _animator.SetFloat("Speed", 0f);
        }

        public abstract void Move(float xDirection);

        public abstract bool CanAttack();

        public abstract void Attack();

        public abstract void Die();
    }
}
