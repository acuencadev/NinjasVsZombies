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

        private void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");

            if (!Mathf.Approximately(horizontal, Mathf.Epsilon))
            {
                Debug.Log($"Moving to {horizontal}");
            }

            if (Input.GetKeyDown(_jumpButton))
            {
                Debug.Log("Jump!");
            }

            if (Input.GetKeyDown(_attackButton))
            {
                Debug.Log("Attack!");
            }

            if (Input.GetKeyDown(_throwButton))
            {
                Debug.Log("Throw!");
            }

            if (Input.GetKeyDown(_slideButton))
            {
                Debug.Log("Slide!");
            }
        }
    }
}
