using UnityEngine;

namespace NinjasVsZombies.Collectors
{
    public class ZombieCollector : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Zombie"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}