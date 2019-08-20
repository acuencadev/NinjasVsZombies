using NinjasVsZombies.Utils;
using UnityEngine;

namespace NinjasVsZombies.Units
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Zombie : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float _speed;
        [SerializeField] private MovementDirection _movementDirection;

        private Vector2 _lookDirection = new Vector2(1f, 0f);

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

        }

        public void Attack()
        {

        }
    }
}