using NinjasVsZombies.Utils;
using UnityEngine;

namespace NinjasVsZombies.Units
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Kunai : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float _speed;
        public MovementDirection _movementDirection;

        private Rigidbody2D _rb2d;

        private void Awake()
        {
            _rb2d = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            if (_movementDirection == MovementDirection.LeftToRight)
            {
                _rb2d.velocity = Vector2.right * _speed;
            }
            else if (_movementDirection == MovementDirection.RightToLeft)
            {
                _rb2d.velocity = Vector2.left * _speed;
                GetComponent<SpriteRenderer>().flipY = true;
            }
        }
    }
}