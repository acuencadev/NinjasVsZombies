using NinjasVsZombies.Units;
using UnityEngine;

namespace NinjasVsZombies.Managers
{
    public class InputManager : MonoBehaviour
    {
        [Header("Key Bindings")]
        [SerializeField] private KeyCode _jumpButton;
        [SerializeField] private KeyCode _attackButton;
        [SerializeField] private KeyCode _throwButton;
        [SerializeField] private KeyCode _slideButton;

        private Player _player;

        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }

        private void Update()
        {
            if (GameManager.instance.gameStatus == Utils.GameStatus.PLAYING)
            {
                float horizontal = Input.GetAxis("Horizontal");

                if (!Mathf.Approximately(horizontal, Mathf.Epsilon))
                {
                    _player.Move(horizontal);
                }
                else
                {
                    _player.StopMoving();
                }

                if (Input.GetKeyDown(_jumpButton))
                {
                    _player.Jump();
                }

                if (Input.GetKeyDown(_attackButton))
                {
                    _player.Attack();
                }

                if (Input.GetKeyDown(_throwButton))
                {
                    _player.Throw();
                }

                if (Input.GetKeyDown(_slideButton))
                {
                    _player.Slide();
                }
            }
        }
    }
}
