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
            Debug.Log("Player Attack");
        }

        public void Throw()
        {
            Debug.Log("Player Throw");
        }

        public void Slide()
        {
            Debug.Log("Player Slide");
        }
    }
}